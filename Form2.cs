using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bseu_yoklama_sistemi1
{

    public partial class Form2 : Form
    {
        public static string currentUser;
        public Form2()
        {
            InitializeComponent();
        }
        
        public static string username1;
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=bseu;Integrated Security=True;";
            string username = textBox1.Text;
            string password = textBox2.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT akademisyen_id, ad_soyad FROM dbo.Akademisyen_giris WHERE kullanici_adi = @username AND sifre = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Program.CurrentTeacher = reader["akademisyen_id"].ToString(); // 'id' sütununu alır ve string'e dönüştürür

                                Program.CurrentTeacherNameSurname = reader["ad_soyad"].ToString();
                                MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Giriş başarılı olduğunda Form10'a yönlendirir
                                Form3 form3 = new Form3();
                                form3.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Parola gizlilik durumu için bir değişken tanımladım.
        private bool isPasswordHidden = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox'un üstüne tıklandıgında parola gızleme ve kaldırma
            // textBox2.UseSystemPasswordChar = true;               
            // Parola gizliyse göster, değilse gizle
            if (isPasswordHidden)
            {
                textBox2.UseSystemPasswordChar = false; // Parolayı göster
                isPasswordHidden = false; // Durumu güncelle
            }
            else
            {
                textBox2.UseSystemPasswordChar = true; // Parolayı gizle
                isPasswordHidden = true; // Durumu güncelle
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();           // Şu anki formu gizler (Form2)
            Form1 geriForm = new Form1();      // Form1'e geri döner
            geriForm.Show();       // Form1'i gösterir
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
