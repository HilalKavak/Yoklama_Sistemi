namespace bseu_yoklama_sistemi1
{
    partial class Form11
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form11));
            label1 = new Label();
            pictureBox2 = new PictureBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            button1 = new Button();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(151, 80);
            label1.Name = "label1";
            label1.Size = new Size(281, 50);
            label1.TabIndex = 3;
            label1.Text = "Öğrenci Bilgileri";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Resource1.exit;
            pictureBox2.Location = new Point(479, 30);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(91, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI", 15.9F);
            textBox5.ForeColor = Color.FromArgb(180, 78, 81);
            textBox5.Location = new Point(87, 602);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Şifre";
            textBox5.Size = new Size(402, 43);
            textBox5.TabIndex = 21;
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Segoe UI", 15.9F);
            textBox6.ForeColor = Color.FromArgb(180, 78, 81);
            textBox6.Location = new Point(87, 515);
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "Kullanıcı Adı";
            textBox6.Size = new Size(402, 43);
            textBox6.TabIndex = 20;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(180, 78, 81);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(193, 686);
            button1.Name = "button1";
            button1.Size = new Size(191, 50);
            button1.TabIndex = 19;
            button1.Text = "Bilgilerimi Güncelle";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 15.9F);
            textBox4.ForeColor = Color.FromArgb(180, 78, 81);
            textBox4.Location = new Point(87, 433);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "E-Mail";
            textBox4.Size = new Size(402, 43);
            textBox4.TabIndex = 18;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 15.9F);
            textBox3.ForeColor = Color.FromArgb(180, 78, 81);
            textBox3.Location = new Point(87, 346);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Ad Soyad";
            textBox3.Size = new Size(402, 43);
            textBox3.TabIndex = 17;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 15.9F);
            textBox2.ForeColor = Color.FromArgb(180, 78, 81);
            textBox2.Location = new Point(87, 259);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Bölüm";
            textBox2.Size = new Size(402, 43);
            textBox2.TabIndex = 16;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 15.9F);
            textBox1.ForeColor = Color.FromArgb(180, 78, 81);
            textBox1.Location = new Point(87, 171);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Fakülte";
            textBox1.Size = new Size(402, 43);
            textBox1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resource1.password;
            pictureBox1.Location = new Point(444, 614);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 21);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Form11
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 780);
            Controls.Add(pictureBox1);
            Controls.Add(textBox5);
            Controls.Add(textBox6);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form11";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ÖĞRENCİ BİLGİLERİ";
            Load += Form11_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox2;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button button1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private PictureBox pictureBox1;
    }
}