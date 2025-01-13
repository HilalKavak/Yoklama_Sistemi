namespace bseu_yoklama_sistemi1
{
    partial class Form12
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form12));
            label7 = new Label();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 22.2F);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(83, 103);
            label7.Name = "label7";
            label7.Size = new Size(279, 50);
            label7.TabIndex = 6;
            label7.Text = "Kod ile Yoklama";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(180, 78, 81);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(111, 385);
            button1.Name = "button1";
            button1.Size = new Size(222, 53);
            button1.TabIndex = 20;
            button1.Text = "Yoklamaya Dahil Ol";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Resource1.exit;
            pictureBox2.Location = new Point(396, 30);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(91, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(57, 174);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(341, 28);
            comboBox1.TabIndex = 27;
            // 
            // textBox1
            // 
            textBox1.ForeColor = Color.FromArgb(180, 78, 81);
            textBox1.Location = new Point(132, 300);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 27);
            textBox1.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(144, 249);
            label1.Name = "label1";
            label1.Size = new Size(148, 31);
            label1.TabIndex = 29;
            label1.Text = "Kodu Giriniz :";
            // 
            // Form12
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 503);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox2);
            Controls.Add(button1);
            Controls.Add(label7);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form12";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KOD İLE YÜKLEME ";
            Load += Form12_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label7;
        private Button button1;
        private PictureBox pictureBox2;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label1;
    }
}