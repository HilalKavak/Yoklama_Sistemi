namespace bseu_yoklama_sistemi1
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            label1 = new Label();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            lblgiris = new Label();
            lbllgiris = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(168, 70);
            label1.Name = "label1";
            label1.Size = new Size(217, 50);
            label1.TabIndex = 4;
            label1.Text = "Kod Oluştur";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(180, 78, 81);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(205, 332);
            button1.Name = "button1";
            button1.Size = new Size(191, 50);
            button1.TabIndex = 11;
            button1.Text = "Kod Oluştur";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 15.9F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(99, 222);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(402, 44);
            comboBox1.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.9F);
            label2.Location = new Point(89, 166);
            label2.Name = "label2";
            label2.Size = new Size(139, 37);
            label2.TabIndex = 12;
            label2.Text = "Ders Kodu";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Resource1.exit;
            pictureBox2.Location = new Point(479, 26);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(91, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // lblgiris
            // 
            lblgiris.AutoSize = true;
            lblgiris.Location = new Point(479, 465);
            lblgiris.Name = "lblgiris";
            lblgiris.Size = new Size(0, 20);
            lblgiris.TabIndex = 17;
            // 
            // lbllgiris
            // 
            lbllgiris.AutoSize = true;
            lbllgiris.Location = new Point(431, 536);
            lbllgiris.Name = "lbllgiris";
            lbllgiris.Size = new Size(0, 20);
            lbllgiris.TabIndex = 18;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(180, 78, 81);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(205, 415);
            button2.Name = "button2";
            button2.Size = new Size(191, 50);
            button2.TabIndex = 19;
            button2.Text = "Zaman Ayarla";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 646);
            Controls.Add(button2);
            Controls.Add(lbllgiris);
            Controls.Add(lblgiris);
            Controls.Add(pictureBox2);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form7";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KOD OLUŞTUR";
            Load += Form7_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private ComboBox comboBox1;
        private Label label2;
        private PictureBox pictureBox2;
        private Label lblgiris;
        private Label lbllgiris;
        private Button button2;
    }
}