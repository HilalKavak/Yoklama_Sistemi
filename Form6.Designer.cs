namespace bseu_yoklama_sistemi1
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            label1 = new Label();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(170, 60);
            label1.Name = "label1";
            label1.Size = new Size(227, 50);
            label1.TabIndex = 3;
            label1.Text = "Ders Oluştur";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(180, 78, 81);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(188, 363);
            button1.Name = "button1";
            button1.Size = new Size(191, 50);
            button1.TabIndex = 10;
            button1.Text = "Ders Oluştur";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 15.9F);
            textBox2.ForeColor = Color.FromArgb(180, 78, 81);
            textBox2.Location = new Point(85, 243);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Ders Adı";
            textBox2.Size = new Size(402, 43);
            textBox2.TabIndex = 12;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 15.9F);
            textBox1.ForeColor = Color.FromArgb(180, 78, 81);
            textBox1.Location = new Point(85, 153);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Ders Kodu";
            textBox1.Size = new Size(402, 43);
            textBox1.TabIndex = 11;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Resource1.exit;
            pictureBox2.Location = new Point(479, 27);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(91, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 646);
            Controls.Add(pictureBox2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form6";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DERS OLUŞTUR";
            Load += Form6_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
        private PictureBox pictureBox2;
    }
}