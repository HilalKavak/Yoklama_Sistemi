using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bseu_yoklama_sistemi1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        // Parola gizlilik durumu için bir değişken tanımladım.
        private bool isPasswordHidden = false;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();           // Şu anki formu gizler (Form4)
            Form3 geriForm = new Form3();      // Form3'e geri döner
            geriForm.Show();       // Form3'i gösterir
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Veritabanı bağlantısını sağlamak için gerekli bilgiler
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=bseu;Integrated Security=True;";

            //Herhangi bir giriş alanı boş bırakılmışsa kullanıcıyı uyarıyor
            if (string.IsNullOrEmpty(textBox1.Text) ||
            string.IsNullOrEmpty(textBox2.Text) ||
            string.IsNullOrEmpty(textBox3.Text) ||
            string.IsNullOrEmpty(textBox4.Text) ||
            string.IsNullOrEmpty(textBox5.Text) ||
            string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;          // İşlemi sonlandırıyor
            }

            //Veritabanı bağlantısını yapmak için 'SqlConnection' kullanılıyor
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                      //Veritabanı bağlantısı açılıyor

                    // Kullanıcının girdiği e-posta veya kullanıcı adının kayıtlı olup olmadığını kontrol ediyor
                    string checkQuery = "SELECT COUNT(1) FROM dbo.Ogrenci_giris WHERE e_posta = @ePosta OR kullanici_adi = @kullaniciAdi";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        //Kullanıcın girdiği e-posta ve kullanıcı adı SQL sorgusuna ekleniyor
                        checkCommand.Parameters.AddWithValue("@ePosta", textBox4.Text);
                        checkCommand.Parameters.AddWithValue("@kullaniciAdi", textBox6.Text);

                        //SQL sorgusunu çalıştırır ve eşleşen kayıt sayısını alıyor
                        int existingCount = (int)checkCommand.ExecuteScalar();        //SQL sorgularını çalıştırmak için kullanılır.Yalnızca ilk sütundaki ilk satırı döndürür.
                        if (existingCount > 0)                                      //Eğer eşleşen bir kayıt varsa,kullanıcıya uyarı gösterir ve işlemi iptal ediyor.
                        {
                            MessageBox.Show("E-posta veya kullanıcı adı zaten kayıtlı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // İşlemi iptal eder
                        }
                    }

                    // Eğer kayıt bulunmazsa yenir bir kayıt eklenir
                    string query = "INSERT INTO dbo.Ogrenci_giris (fakulte, bolum, ad_soyad, e_posta, kullanici_adi, sifre) " +
                                   "VALUES (@fakulte, @bolum, @adSoyad, @ePosta, @kullaniciAdi, @sifre)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //Kullanıcının formdan girdiği değerler SQL sorgusuna ekleniyor
                        command.Parameters.AddWithValue("@fakulte", textBox1.Text);
                        command.Parameters.AddWithValue("@bolum", textBox2.Text);
                        command.Parameters.AddWithValue("@adSoyad", textBox3.Text);
                        command.Parameters.AddWithValue("@ePosta", textBox4.Text);
                        command.Parameters.AddWithValue("@kullaniciAdi", textBox6.Text);
                        command.Parameters.AddWithValue("@sifre", textBox5.Text);

                        int result = command.ExecuteNonQuery();     //Veritabanına yapılan değişikliklerin(insert, update, delete) sonucunda etkilenen satır sayısını alıyor
                        if (result > 0)                             // Eğer etkilenen satır sayısı 0'dan büyükse işlem başarılı
                        {
                            MessageBox.Show("Kayıt başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // İnputları (giriş alanları) temizleniyor
                            textBox1.Text = string.Empty;
                            textBox2.Text = string.Empty;
                            textBox3.Text = string.Empty;
                            textBox4.Text = string.Empty;
                            textBox5.Text = string.Empty;
                            textBox6.Text = string.Empty;
                        }
                        else
                        {
                            //Eğer işlem başarısız olursa kullanıcıya hata mesajı gönderiliyor
                            MessageBox.Show("Kayıt eklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)                           //Herhangi bir hata oluşursa
                {
                    //Hata mesajı kullanıcıya gösteriliyor
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
