using ExcelDataReader;
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
using System.IO;


namespace bseu_yoklama_sistemi1
{
    public partial class Form14 : Form
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=bseu;Integrated Security=True;";
        public Form14()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Bir Excel Dosyası Seçin";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Excel'den verileri oku
                    DataTable dataTable = ReadExcelFile(filePath);

                    if (dataTable != null)
                    {
                        int totalRecords = dataTable.Rows.Count;
                        int existingRecords = 0;
                        int newRecords = 0;

                        // Veritabanına aktar
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            foreach (DataRow row in dataTable.Rows)
                            {
                                string ePosta = row["e_posta"].ToString();
                                string kullaniciAdi = row["kullanici_adi"].ToString();

                                // Aynı e-posta veya kullanıcı adı varsa ekleme
                                if (IsRecordExists(connection, ePosta, kullaniciAdi))
                                {
                                    existingRecords++;
                                    continue;
                                }

                                // Yeni kayıt ekle
                                string query = @"INSERT INTO dbo.Ogrenci_giris 
                                                 (fakulte, bolum, ad_soyad, e_posta, kullanici_adi, sifre) 
                                                 VALUES 
                                                 (@fakulte, @bolum, @adSoyad, @ePosta, @kullaniciAdi, @sifre)";
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@fakulte", row["fakulte"]);
                                    command.Parameters.AddWithValue("@bolum", row["bolum"]);
                                    command.Parameters.AddWithValue("@adSoyad", row["ad_soyad"]);
                                    command.Parameters.AddWithValue("@ePosta", row["e_posta"]);
                                    command.Parameters.AddWithValue("@kullaniciAdi", row["kullanici_adi"]);
                                    command.Parameters.AddWithValue("@sifre", row["sifre"]);

                                    command.ExecuteNonQuery();
                                    newRecords++;
                                }
                            }
                        }

                        // İşlem özeti
                        MessageBox.Show(
                            $"{totalRecords} veri bulundu.\n{existingRecords} tanesi zaten vardı.\n{newRecords} yeni veri eklendi.",
                            "İşlem Tamamlandı",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Veri okunamadı. Lütfen dosyayı kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private DataTable ReadExcelFile(string filePath)
        {
            try
            {
                using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        // Verileri DataSet olarak oku
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true // İlk satırı başlık olarak kullan
                            }
                        });

                        // İlk çalışma sayfasını DataTable olarak al
                        return result.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private bool IsRecordExists(SqlConnection connection, string ePosta, string kullaniciAdi)
        {
            string query = @"SELECT COUNT(1) FROM dbo.Ogrenci_giris 
                             WHERE e_posta = @ePosta OR kullanici_adi = @kullaniciAdi";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ePosta", ePosta);
                command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();           // Şu anki formu gizler (Form2)
            Form3 geriForm = new Form3(); // Kullanıcı adını Form3'e ilet
            geriForm.Show();       // Form1'i gösterir
        }
    }
}
