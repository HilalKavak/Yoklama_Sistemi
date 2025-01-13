using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bseu_yoklama_sistemi1
{
    public partial class Form6 : Form
    {
        // Veritabanı bağlantı dizesi
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=bseu;Integrated Security=True;";

        // Constructor - Form6 başlatılırken kullanıcı adı alınır
        public Form6()
        {
            InitializeComponent();
        }

        // Geri dönmek için PictureBox'a tıklama işlemi
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide(); // Şu anki formu gizler (Form6)
            Form3 geriForm = new Form3(); // Form3'e geri döner
            geriForm.Show(); // Form3'ü gösterir
        }

        // Ders ekleme işlemi
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan değerler
            string dersAdi = textBox2.Text.Trim();
            string dersKodu = textBox1.Text.Trim();

            // Ders adı ve ders kodunun boş olup olmadığını kontrol et
            if (string.IsNullOrEmpty(dersAdi) || string.IsNullOrEmpty(dersKodu))
            {
                MessageBox.Show("Lütfen Ders Adı ve Ders Kodu'nun her ikisini de doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Veritabanı bağlantısını aç

                    // Kullanıcı adına bağlı akademisyen_id'yi almak için sorgu
                    string akademisyenQuery = "SELECT akademisyen_id FROM Akademisyen_giris WHERE akademisyen_id = @akademisyen_id";
                    int akademisyenid; // Akademisyen ID'yi saklayacak değişken

                    using (SqlCommand akademisyenCommand = new SqlCommand(akademisyenQuery, connection))
                    {
                        akademisyenCommand.Parameters.AddWithValue("@akademisyen_id", Program.CurrentTeacher); // Parametreye kullanıcı adı atanıyor

                        // Akademisyen ID'yi veritabanından al
                        object result = akademisyenCommand.ExecuteScalar();
                        if (result == null)
                        {
                            // Eğer akademisyen bulunamazsa hata mesajı göster
                            MessageBox.Show("Geçerli bir akademisyen bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        akademisyenid = Convert.ToInt32(result); // Akademisyen ID'yi al
                    }

                    // Dersin zaten mevcut olup olmadığını kontrol et
                    string checkQuery = "SELECT COUNT(1) FROM dbo.Dersler WHERE (ders_adi = @dersAdi OR ders_kodu = @dersKodu) AND akademisyen_id = @akademisyen_id";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@dersAdi", dersAdi);
                        checkCommand.Parameters.AddWithValue("@dersKodu", dersKodu);
                        checkCommand.Parameters.AddWithValue("@akademisyen_id", akademisyenid);

                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count == 0)
                        {
                            // Ders ekleme sorgusu
                            string insertQuery = "INSERT INTO dbo.Dersler (ders_adi, ders_kodu, akademisyen_id) VALUES (@dersAdi, @dersKodu, @akademisyen_id)";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@dersAdi", dersAdi);
                                insertCommand.Parameters.AddWithValue("@dersKodu", dersKodu);
                                insertCommand.Parameters.AddWithValue("@akademisyen_id", akademisyenid);

                                // Yeni dersi ekle
                                insertCommand.ExecuteNonQuery();
                            }

                            // Başarı mesajı
                            MessageBox.Show("Ders başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // TextBox'ları temizle
                            textBox1.Text = string.Empty;
                            textBox2.Text = string.Empty;
                        }
                        else
                        {
                            // Ders zaten mevcutsa uyarı mesajı göster
                            MessageBox.Show("Bu ders adı veya kodu zaten veritabanında mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata mesajı ve detayları
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler (şimdilik boş)
        }
    }
}
