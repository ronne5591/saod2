namespace Sort
{
    partial class Form1
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
            this.Order_By = new System.Windows.Forms.RadioButton();
            this.Sort = new System.Windows.Forms.RadioButton();
            this.Shella = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.quick2 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // Order_By
            // 
            this.Order_By.AutoSize = true;
            this.Order_By.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Order_By.Location = new System.Drawing.Point(195, 148);
            this.Order_By.Name = "Order_By";
            this.Order_By.Size = new System.Drawing.Size(85, 24);
            this.Order_By.TabIndex = 3;
            this.Order_By.TabStop = true;
            this.Order_By.Tag = "4";
            this.Order_By.Text = "OrderBy";
            this.Order_By.UseVisualStyleBackColor = true;
            // 
            // Sort
            // 
            this.Sort.AutoSize = true;
            this.Sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Sort.Location = new System.Drawing.Point(286, 148);
            this.Sort.Name = "Sort";
            this.Sort.Size = new System.Drawing.Size(98, 24);
            this.Sort.TabIndex = 2;
            this.Sort.TabStop = true;
            this.Sort.Tag = "3";
            this.Sort.Text = "Array.Sort";
            this.Sort.UseVisualStyleBackColor = true;
            // 
            // Shella
            // 
            this.Shella.AutoSize = true;
            this.Shella.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Shella.Location = new System.Drawing.Point(111, 148);
            this.Shella.Name = "Shella";
            this.Shella.Size = new System.Drawing.Size(78, 24);
            this.Shella.TabIndex = 1;
            this.Shella.TabStop = true;
            this.Shella.Tag = "2";
            this.Shella.Text = "Шелла";
            this.Shella.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(12, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сортировка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox1.Location = new System.Drawing.Point(12, 116);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 26);
            this.textBox1.TabIndex = 2;
            // 
            // quick2
            // 
            this.quick2.AutoSize = true;
            this.quick2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.quick2.Location = new System.Drawing.Point(12, 148);
            this.quick2.Name = "quick2";
            this.quick2.Size = new System.Drawing.Size(93, 24);
            this.quick2.TabIndex = 4;
            this.quick2.TabStop = true;
            this.quick2.Text = "Быстрая";
            this.quick2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Создать массив";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 41);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(108, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Время:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 184);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quick2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.Order_By);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Sort);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Shella);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton Order_By;
        private System.Windows.Forms.RadioButton Sort;
        private System.Windows.Forms.RadioButton Shella;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton quick2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}