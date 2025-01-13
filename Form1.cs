namespace bseu_yoklama_sistemi1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();           //form 2 yi göstermek için
            this.Hide();            //Form1'de giriþ yapýp Form3'e yönlendirildiðinde Form1'in görünmesini engellemek için.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();           //form 2 yi göstermek için
            this.Hide();            //Form1'de giriþ yapýp Form3'e yönlendirildiðinde Form1'in görünmesini engellemek için.

        }
    }
}
