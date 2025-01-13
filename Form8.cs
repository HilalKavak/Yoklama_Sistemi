using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bseu_yoklama_sistemi1
{
    public partial class Form8 : Form
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=bseu;Integrated Security=True;";
        SqlConnection baglanti = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=bseu;Integrated Security=True;");
        public Form8()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();           // Şu anki formu gizler (Form4)
            Form3 geriForm = new Form3();      // Form3'e geri döner
            geriForm.Show();       // Form3'i gösterir
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            LoadUserCourses();
        }

        private void LoadUserCourses()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Akademisyene ait dersleri getiren sorgu
                    string query = @"
                SELECT ders_kodu, ders_adi 
                FROM dbo.Dersler 
                WHERE akademisyen_id = @akademisyenId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Giriş yapan öğretmenin id'sini parametre olarak ekle
                        command.Parameters.AddWithValue("@akademisyenId", Program.CurrentTeacher);

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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dersler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedItem))
            {
                MessageBox.Show("Lütfen bir ders seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen ders kodunu al
            string dersKodu = selectedItem.Split(' ')[0]; // Ders kodunu ayır

            // Dersin id'sini veritabanından al
            int dersId = GetCourseIdFromDatabase(dersKodu);

            if (dersId == 0)
            {
                MessageBox.Show("Ders bulunamadı. Lütfen doğru bir ders seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ders id'sini gönder
            LoadAttendanceData(dersId);
        }

        // Veritabanından ders koduna göre id'yi sorgulayan metod
        private int GetCourseIdFromDatabase(string dersKodu)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id FROM dbo.Dersler WHERE ders_kodu = @dersKodu";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dersKodu", dersKodu);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result); // Bulunan id'yi döndür
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ders id'si alınırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return 0; // Eğer id bulunamazsa 0 döndür
        }


        private void LoadAttendanceData(int dersKodu)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Son oluşturulan kodu al
                    string getLastCodeQuery = @"
                SELECT TOP 1 id 
                FROM dbo.Kod 
                WHERE ders_kodu = @dersKodu 
                ORDER BY süre DESC";

                    int lastCodeId;
                    using (SqlCommand command = new SqlCommand(getLastCodeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@dersKodu", dersKodu);
                        object result = command.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Bu ders için henüz bir kod oluşturulmamış.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        lastCodeId = Convert.ToInt32(result);
                    }

                    // Öğrenci bilgilerini ve yoklama durumlarını getir
                    string query = @"
                SELECT 
                    O.ad_soyad AS AdSoyad,
                    O.kullanici_adi AS KullaniciAdi,
                    K.ders_kodu AS DersKodu,
                    CASE 
                        WHEN Y.id IS NOT NULL THEN 'Katıldı'
                        ELSE 'Katılmadı'
                    END AS YoklamaDurumu
                FROM dbo.Ogrenci_giris O
                LEFT JOIN dbo.Yoklama Y ON O.id = Y.ogrenci_id AND Y.kod_id = @lastCodeId
                LEFT JOIN dbo.Kod K ON K.id = @lastCodeId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@lastCodeId", lastCodeId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // DataGridView'e verileri yükle
                            dataGridView1.DataSource = dataTable;

                            // Sütun başlıklarını gizleme
                            dataGridView1.ColumnHeadersVisible = false;

                            // DataGridView'in düzenlemelerini kapatma
                            dataGridView1.ReadOnly = true;
                            dataGridView1.AllowUserToAddRows = false; // Yeni satır eklenmesini engelle
                            dataGridView1.AllowUserToDeleteRows = false; // Silmeyi engelle
                            dataGridView1.AllowUserToResizeColumns = false; // Sütun boyutlandırmayı engelle
                            dataGridView1.AllowUserToResizeRows = false; // Satır boyutlandırmayı engelle

                            // Sütun genişliklerini eşitleme
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                            // Satır renklerini ayarla
                            // Satır renklerini ayarla
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                var cellValue = row.Cells["YoklamaDurumu"]?.Value;

                                if (cellValue != null && cellValue.ToString() == "Katıldı")
                                {
                                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                                }
                                else
                                {
                                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yoklama verileri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
