using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;

namespace bseu_yoklama_sistemi1
{
    public partial class Form5 : Form
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=bseu;Integrated Security=True;";

        public Form5()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
        }

        private void LoadDataIntoDataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL sorgusu
                    string query = "SELECT fakulte, bolum, ad_soyad, e_posta, kullanici_adi FROM dbo.Ogrenci_giris";

                    // DataAdapter ve DataTable kullanarak veriyi çekme
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // DataGridView'e veri bağlama
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();           // Şu anki formu gizler (Form3)
            Form3 geriForm = new Form3();      // Form3'e geri döner
            geriForm.Show();       // Form3'i gösterir
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
