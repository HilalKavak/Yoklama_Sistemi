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
    public partial class Form12 : Form
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=bseu;Integrated Security=True;";
        SqlConnection baglanti = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=bseu;Integrated Security=True;");

        public Form12()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();           // Şu anki formu gizler (Form3)
            Form11 geriForm = new Form11();      // Form11'e geri döner
            geriForm.Show();       // Form11'i gösterir
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Lütfen bir ders seçin ve kod alanını doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen ders ve kod değerlerini al
            string selectedItem = comboBox1.SelectedItem.ToString();
            string dersKodu = selectedItem.Split(' ')[0]; // Ders kodunu ayır
            string girilenKod = textBox1.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Ders tablosundan ders kodunun ID'sini al
                    string getDersIdQuery = "SELECT id FROM dbo.Dersler WHERE ders_kodu = @dersKodu";
                    using (SqlCommand getDersIdCommand = new SqlCommand(getDersIdQuery, connection))
                    {
                        getDersIdCommand.Parameters.AddWithValue("@dersKodu", dersKodu);

                        object dersId = getDersIdCommand.ExecuteScalar();
                        if (dersId == null)
                        {
                            MessageBox.Show("Seçilen ders bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Kod tablosunda ders ID, girilen kod ve süre kontrolü
                        string checkQuery = "SELECT id, süre FROM dbo.Kod WHERE ders_kodu = @dersId AND kod = @girilenKod";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@dersId", dersId);
                            checkCommand.Parameters.AddWithValue("@girilenKod", girilenKod);

                            using (SqlDataReader reader = checkCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    DateTime sure = reader.GetDateTime(reader.GetOrdinal("süre"));
                                    int kodId = reader.GetInt32(reader.GetOrdinal("id"));

                                    // Süre kontrolü
                                    if (DateTime.Now.Subtract(sure).TotalMinutes > 2)
                                    {
                                        MessageBox.Show("Kodun süresi dolmuştur. Lütfen geçerli bir kod girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }

                                    // Yoklama tablosunda daha önce eklenmiş mi kontrol et
                                    string yoklamaCheckQuery = "SELECT COUNT(*) FROM dbo.Yoklama WHERE kod_id = @kodId AND ogrenci_id = @ogrenciId";
                                    reader.Close(); // Reader açıkken başka bir komut çalıştırılamaz
                                    using (SqlCommand yoklamaCheckCommand = new SqlCommand(yoklamaCheckQuery, connection))
                                    {
                                        yoklamaCheckCommand.Parameters.AddWithValue("@kodId", kodId);
                                        yoklamaCheckCommand.Parameters.AddWithValue("@ogrenciId", Program.CurrentUser); // Mevcut kullanıcı ID'si

                                        int count = (int)yoklamaCheckCommand.ExecuteScalar();
                                        if (count > 0)
                                        {
                                            MessageBox.Show("Daha önce yoklamaya dahil oldunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }

                                    // Yoklama tablosuna ekle
                                    string insertQuery = "INSERT INTO dbo.Yoklama (kod_id, ogrenci_id) VALUES (@kodId, @ogrenciId)";
                                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                    {
                                        insertCommand.Parameters.AddWithValue("@kodId", kodId);
                                        insertCommand.Parameters.AddWithValue("@ogrenciId", Program.CurrentUser);

                                        insertCommand.ExecuteNonQuery();
                                        MessageBox.Show("Yoklama başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Girilen kod ve ders eşleşmedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yoklama kaydedilirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadUserCourses()
        {
           
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ders_kodu, ders_adi FROM dbo.Dersler";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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


        private void Form12_Load(object sender, EventArgs e)

        { 

            // Kullanıcının derslerini ComboBox'a ekle
            LoadUserCourses();
        }

    }
    
}
