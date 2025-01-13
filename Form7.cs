using System;
using System.Data;
using System.Data.SqlClient;
using System.Timers;
using System.Windows.Forms;

namespace bseu_yoklama_sistemi1
{
    public partial class Form7 : Form
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=bseu;Integrated Security=True;";
        private DateTime expirationTime;
        SqlConnection baglanti = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=bseu;Integrated Security=True;");

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            lbllgiris.Text = $"Hoş geldiniz, {Program.CurrentTeacherNameSurname}!"; // Kullanıcı adını göster

            // Kullanıcının derslerini ComboBox'a ekle
            LoadUserCourses();
        }

        private void LoadUserCourses()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ders_kodu, ders_adi FROM dbo.Dersler WHERE akademisyen_id = (SELECT akademisyen_id FROM dbo.Akademisyen_giris WHERE id = @id)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", Program.CurrentTeacher);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // Ders kodlarını ve adlarını ComboBox'a ekle
                        comboBox1.Items.Clear(); // Önceki elemanları temizle
                        while (reader.Read())
                        {
                            string dersKodu = reader["ders_kodu"].ToString();
                            string dersAdi = reader["ders_adi"].ToString();
                            comboBox1.Items.Add($"{dersKodu} ({dersAdi})");
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dersler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Şu anki formu gizle ve Form3'e dön
            this.Hide();
            Form3 geriForm = new Form3(); // Kullanıcı adını Form3'e ilet
            geriForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ders seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen ders kodunu ve adını al
            string selectedItem = comboBox1.Text;

            if (string.IsNullOrEmpty(selectedItem))
            {
                MessageBox.Show("Lütfen bir ders seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string kod = GenerateRandomCode(); // Rastgele kod oluştur
            expirationTime = DateTime.Now.AddMinutes(2); // 2 dakika süre belirle

            try
            {
                // Sadece ders kodunu almak için parçalıyoruz
                string selectedCourseCode = comboBox1.SelectedValue.ToString();

                // Kod veritabanına kaydedilir
                SaveCodeToDatabase(selectedCourseCode, kod, expirationTime);

                // Dersi ilgili tüm yoklama verilerini sil
                DeleteAllAttendanceForCourse(selectedCourseCode);

                MessageBox.Show($"Ders Kodu: {selectedItem}\nOluşturulan Kod: {kod}\nBu kod 2 dakika boyunca geçerlidir.",
                                "Kod Oluşturuldu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                StartCodeExpirationTimer(2); // Kod süresinin bitişi için zamanlayıcı başlat
                comboBox1.SelectedIndex = -1; // ComboBox'u sıfırla
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kod oluşturulamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Dersle ilgili tüm yoklama verilerini silme fonksiyonu
        private void DeleteAllAttendanceForCourse(string courseCode)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // dbo.Kod tablosundaki ders_kodu ile eşleşen kod_id'leri al
                    string getCodeIdsQuery = "SELECT id FROM dbo.Kod WHERE ders_kodu = @courseCode";
                    using (SqlCommand getCodeIdsCommand = new SqlCommand(getCodeIdsQuery, connection))
                    {
                        getCodeIdsCommand.Parameters.AddWithValue("@courseCode", courseCode);

                        using (SqlDataReader reader = getCodeIdsCommand.ExecuteReader())
                        {
                            List<int> codeIds = new List<int>();
                            while (reader.Read())
                            {
                                codeIds.Add(reader.GetInt32(0)); // Kod ID'leri listeye ekle
                            }
                            reader.Close();

                            // Eğer eşleşen kod_id'ler varsa dbo.Yoklama'dan sil
                            if (codeIds.Count > 0)
                            {
                                // Dinamik olarak IN parametrelerini oluştur
                                string paramPlaceholders = string.Join(",", codeIds.Select((id, index) => $"@param{index}"));

                                string deleteQuery = $"DELETE FROM dbo.Yoklama WHERE kod_id IN ({paramPlaceholders})";
                                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                                {
                                    // Dinamik parametreleri komuta ekle
                                    for (int i = 0; i < codeIds.Count; i++)
                                    {
                                        deleteCommand.Parameters.AddWithValue($"@param{i}", codeIds[i]);
                                    }

                                    deleteCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yoklama verileri silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string GenerateRandomCode()
        {
            Random random = new Random();
            return random.Next(1000, 10000).ToString(); // 4 haneli kod
        }

        private void SaveCodeToDatabase(string dersKodu, string kod, DateTime süre)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO dbo.Kod (ders_kodu, kod, süre, akademisyen_id) VALUES (@dersKodu, @kod, @süre, @akademisyen_id)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dersKodu", dersKodu);
                        command.Parameters.AddWithValue("@kod", kod);
                        command.Parameters.AddWithValue("@süre", süre);
                        command.Parameters.AddWithValue("@akademisyen_id", Program.CurrentTeacher);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Veritabanına kaydedilemedi: " + ex.Message);
            }
        }

        private void StartCodeExpirationTimer(int durationMinutes)
        {
            System.Timers.Timer timer = new System.Timers.Timer
            {
                Interval = durationMinutes * 60 * 1000, // Dakikayı milisaniyeye çevir
                AutoReset = false // Timer'ın yalnızca bir kez çalışmasını sağla
            };

            timer.Elapsed += (s, e) =>
            {
                // UI thread üzerinde MessageBox'ı göstermek için Invoke kullan
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show("Kodun süresi doldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));

                // Timer'ı temizle
                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ComboBox'tan bir ders seçilip seçilmediğini kontrol et
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ders seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen dersin adını alır
            string selectedCourse = comboBox1.Text;

            // Kodun süresini 2 dakikaya ayarla ve zamanlayıcıyı başlat
            expirationTime = DateTime.Now.AddMinutes(2);
            StartCodeExpirationTimer(2);

            // Bilgilendirme mesajı göster
            MessageBox.Show($"Seçilen Ders: {selectedCourse}\n2 dakikalık süre başladı.",
                            "Bilgi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }


        public string dbusername = Form2.username1;

        private void Form7_Load_1(object sender, EventArgs e)
        {
            try
            {
                baglanti = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=bseu;Integrated Security=True;");
                baglanti.Open();

                string ogrID_Sorgusu = "SELECT akademisyen_id FROM Akademisyen_giris WHERE akademisyen_id = @akademisyen_id";
                SqlCommand komut = new SqlCommand(ogrID_Sorgusu, baglanti);
                komut.Parameters.AddWithValue("@akademisyen_id", Program.CurrentTeacher);
                object hocaIDObj = komut.ExecuteScalar();

                if (hocaIDObj != null)
                {
                    int ogretmenID = Convert.ToInt32(hocaIDObj);

                    // Öğretmenin derslerini al
                    string dersSorgusu = "SELECT id, ders_kodu+'('+ders_adi+')' as derstamadi FROM Dersler WHERE akademisyen_id = @akademisyen_id";
                    SqlDataAdapter dersAdapter = new SqlDataAdapter(dersSorgusu, baglanti);
                    dersAdapter.SelectCommand.Parameters.AddWithValue("@akademisyen_id", ogretmenID);
                    DataTable dersDT = new DataTable();
                    dersAdapter.Fill(dersDT);

                    comboBox1.ValueMember = "id";
                    comboBox1.DisplayMember = "derstamadi";
                    comboBox1.DataSource = dersDT;
                }
                else
                {
                    MessageBox.Show("Hoca bilgisi bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                if (baglanti != null && baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
