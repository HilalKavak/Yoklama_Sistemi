namespace bseu_yoklama_sistemi1
{
    partial class Form3
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            label1 = new Label();
            button1 = new Button();
            ımageList1 = new ImageList(components);
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            pictureBox2 = new PictureBox();
            button6 = new Button();
            lblgiris = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(77, 69);
            label1.Name = "label1";
            label1.Size = new Size(428, 50);
            label1.TabIndex = 1;
            label1.Text = "Akademisyen Paneli Giriş";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(180, 78, 81);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = Color.White;
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.ImageKey = "kalem.png";
            button1.ImageList = ımageList1;
            button1.Location = new Point(89, 147);
            button1.Name = "button1";
            button1.Size = new Size(395, 47);
            button1.TabIndex = 4;
            button1.Text = "Öğrenci Kayıt";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ımageList1
            // 
            ımageList1.ColorDepth = ColorDepth.Depth32Bit;
            ımageList1.ImageStream = (ImageListStreamer)resources.GetObject("ımageList1.ImageStream");
            ımageList1.TransparentColor = Color.Transparent;
            ımageList1.Images.SetKeyName(0, "anahtar.png");
            ımageList1.Images.SetKeyName(1, "dosya.png");
            ımageList1.Images.SetKeyName(2, "kalem.png");
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(180, 78, 81);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F);
            button2.ForeColor = Color.White;
            button2.ImageAlign = ContentAlignment.MiddleRight;
            button2.ImageKey = "dosya.png";
            button2.ImageList = ımageList1;
            button2.Location = new Point(89, 301);
            button2.Name = "button2";
            button2.Size = new Size(395, 47);
            button2.TabIndex = 5;
            button2.Text = "Öğrenci Listesi";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(180, 78, 81);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F);
            button3.ForeColor = Color.White;
            button3.ImageAlign = ContentAlignment.MiddleRight;
            button3.ImageKey = "kalem.png";
            button3.ImageList = ımageList1;
            button3.Location = new Point(89, 375);
            button3.Name = "button3";
            button3.Size = new Size(395, 47);
            button3.TabIndex = 6;
            button3.Text = "Ders Oluştur";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(180, 78, 81);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F);
            button4.ForeColor = Color.White;
            button4.ImageAlign = ContentAlignment.MiddleRight;
            button4.ImageKey = "anahtar.png";
            button4.ImageList = ımageList1;
            button4.Location = new Point(89, 451);
            button4.Name = "button4";
            button4.Size = new Size(395, 47);
            button4.TabIndex = 7;
            button4.Text = "Kod Oluştur";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(180, 78, 81);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 12F);
            button5.ForeColor = Color.White;
            button5.ImageAlign = ContentAlignment.MiddleRight;
            button5.ImageKey = "dosya.png";
            button5.ImageList = ımageList1;
            button5.Location = new Point(89, 527);
            button5.Name = "button5";
            button5.Size = new Size(395, 47);
            button5.TabIndex = 8;
            button5.Text = "Öğrenci Yoklamasını Göster";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Resource1.exit;
            pictureBox2.Location = new Point(488, 25);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(91, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(180, 78, 81);
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 12F);
            button6.ForeColor = Color.White;
            button6.ImageAlign = ContentAlignment.MiddleRight;
            button6.ImageKey = "kalem.png";
            button6.ImageList = ımageList1;
            button6.Location = new Point(89, 224);
            button6.Name = "button6";
            button6.Size = new Size(395, 47);
            button6.TabIndex = 11;
            button6.Text = "Öğrenci Aktar";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // lblgiris
            // 
            lblgiris.AutoSize = true;
            lblgiris.Location = new Point(488, 597);
            lblgiris.Name = "lblgiris";
            lblgiris.Size = new Size(0, 20);
            lblgiris.TabIndex = 12;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 646);
            Controls.Add(lblgiris);
            Controls.Add(button6);
            Controls.Add(pictureBox2);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AKADEMİSYEN PANELİ GİRİŞ";
            Load += Form3_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private ImageList ımageList1;
        private PictureBox pictureBox2;
        private Button button6;
        private Label lblgiris;
    }
}