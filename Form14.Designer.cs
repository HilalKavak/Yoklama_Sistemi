namespace bseu_yoklama_sistemi1
{
    partial class Form14
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form14));
            label7 = new Label();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 22.2F);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(159, 127);
            label7.Name = "label7";
            label7.Size = new Size(248, 50);
            label7.TabIndex = 7;
            label7.Text = "Öğrenci Aktar";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(180, 78, 81);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(187, 274);
            button1.Name = "button1";
            button1.Size = new Size(191, 50);
            button1.TabIndex = 14;
            button1.Text = "Dosya Aktar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Resource1.exit;
            pictureBox2.Location = new Point(475, 37);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(91, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click_1;
            // 
            // Form14
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 450);
            Controls.Add(pictureBox2);
            Controls.Add(button1);
            Controls.Add(label7);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form14";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ÖĞRENCİ AKTAR";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Button button1;
        private PictureBox pictureBox2;
    }
}