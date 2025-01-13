using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bseu_yoklama_sistemi1
{
    public partial class Form11 : Form
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=bseu;Integrated Security=True;";

        public Form11()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide(); // Şu anki formu gizler
            Form9 geriForm = new Form9(); // Form10'a geri döner
            geriForm.Show(); // Form10'u gösterir
        }

        // Parola gizlilik durumu için bir değişken tanımladım.
        private bool isPasswordHidden = true;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (isPasswordHidden)
            {
                textBox5.UseSystemPasswordChar = false; // Parolayı göster
                isPasswordHidden = false; // Durumu güncelle
            }
            else
            {
                textBox5.UseSystemPasswordChar = true; // Parolayı gizle
                isPasswordHidden = true; // Durumu güncelle
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPassword = textBox5.Text.Trim();

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Lütfen yeni bir şifre girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE dbo.Ogrenci_giris SET sifre = @sifre WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@sifre", newPassword);
                        command.Parameters.AddWithValue("@id", Program.CurrentUser);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Şifreniz başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şifre güncellenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT fakulte, bolum, ad_soyad, e_posta, kullanici_adi FROM dbo.Ogrenci_giris WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", Program.CurrentUser);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            textBox1.Text = reader["fakulte"].ToString();
                            textBox2.Text = reader["bolum"].ToString();
                            textBox3.Text = reader["ad_soyad"].ToString();
                            textBox4.Text = reader["e_posta"].ToString();
                            textBox6.Text = reader["kullanici_adi"].ToString();
                        }
                        //reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bilgiler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Şifre dışında diğer alanları sadece okunabilir yap
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox6.ReadOnly = true;
        }
    }
}
