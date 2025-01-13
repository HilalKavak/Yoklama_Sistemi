using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace bseu_yoklama_sistemi1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();    //Form4' e yönlendiriyor.
            form4.Show();                 //Form4' ü gösteriyor.
            this.Hide();                  // mevcut formu gizler.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();       //Form5' e yönlendiriyor.
            form5.Show();                    //Form5' i gösteriyor.
            this.Hide();                     // mevcut formu gizler.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();          //Form6' ya yönlendiriyor.
            form6.Show();                      //Form6' yı gösteriyor.
            this.Hide();                      // mevcut formu gizler.
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();           //Form7' ye yönlendiriyor.
            form7.Show();                        //Form7' yi gösteriyor.
            this.Hide();                         // mevcut formu gizler.
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();           // Şu anki formu gizler (Form3)
            Form2 geriForm = new Form2();      // Form2'e geri döner
            geriForm.Show();       // Form1'i gösterir
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();                     //Form8' e yönlendiriyor.
            form8.Show();                                  //Form8' i gösteriyor
            this.Hide();                                    // mevcut formu gizler.
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();                   //Form14' e yönlendiriyor.
            form14.Show();                                  //Form14' ü gösteriyor
            this.Hide();                                   // mevcut formu gizler.
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            lblgiris.Text = $"Hoş geldiniz, {Program.CurrentTeacherNameSurname}!"; // Kullanıcı adını göster
        }
        public string db1username=Form2.username1;

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }
    }
}

