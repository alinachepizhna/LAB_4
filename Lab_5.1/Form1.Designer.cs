namespace Lab_5._1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            radioButtonMDP = new RadioButton();
            radioButtonNewton = new RadioButton();
            comboBoxEquation = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(530, 323);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Розв'язати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(666, 323);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Очистити";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(604, 383);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "Вийти";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(75, 38);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 3;
            label1.Text = "Оберіть метод";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.MenuHighlight;
            label2.Location = new Point(69, 196);
            label2.Name = "label2";
            label2.Size = new Size(132, 20);
            label2.TabIndex = 4;
            label2.Text = "Оберіть рівняння";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(405, 38);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 5;
            label3.Text = "Вхідні дані";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(311, 100);
            label4.Name = "label4";
            label4.Size = new Size(27, 20);
            label4.TabIndex = 6;
            label4.Text = "a=";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(311, 164);
            label5.Name = "label5";
            label5.Size = new Size(28, 20);
            label5.TabIndex = 7;
            label5.Text = "b=";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(311, 238);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 8;
            label6.Text = "Eps=";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ControlText;
            label7.Location = new Point(311, 305);
            label7.Name = "label7";
            label7.Size = new Size(56, 20);
            label7.TabIndex = 9;
            label7.Text = "Kmax=";
            label7.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(648, 38);
            label8.Name = "label8";
            label8.Size = new Size(50, 20);
            label8.TabIndex = 10;
            label8.Text = "label8";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(513, 100);
            label9.Name = "label9";
            label9.Size = new Size(96, 20);
            label9.TabIndex = 11;
            label9.Text = "Розв'язок х=";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(513, 164);
            label10.Name = "label10";
            label10.Size = new Size(70, 20);
            label10.TabIndex = 12;
            label10.Text = "Кількість";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(377, 97);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(377, 164);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 14;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(377, 238);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 15;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(377, 302);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 16;
            textBox4.Visible = false;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(615, 100);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 17;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(615, 164);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 18;
            // 
            // radioButtonMDP
            // 
            radioButtonMDP.AutoSize = true;
            radioButtonMDP.Location = new Point(69, 78);
            radioButtonMDP.Name = "radioButtonMDP";
            radioButtonMDP.Size = new Size(182, 24);
            radioButtonMDP.TabIndex = 19;
            radioButtonMDP.TabStop = true;
            radioButtonMDP.Text = "Метод ділення навпіл";
            radioButtonMDP.UseVisualStyleBackColor = true;
            // 
            // radioButtonNewton
            // 
            radioButtonNewton.AutoSize = true;
            radioButtonNewton.Location = new Point(69, 127);
            radioButtonNewton.Name = "radioButtonNewton";
            radioButtonNewton.Size = new Size(141, 24);
            radioButtonNewton.TabIndex = 20;
            radioButtonNewton.TabStop = true;
            radioButtonNewton.Text = "Метод Ньютона";
            radioButtonNewton.UseVisualStyleBackColor = true;
            radioButtonNewton.CheckedChanged += radioButtonNewton_CheckedChanged_1;
            // 
            // comboBoxEquation
            // 
            comboBoxEquation.FormattingEnabled = true;
            comboBoxEquation.Items.AddRange(new object[] { "x * x - 4", "3 * x - 4 * log(x) - 5", "cos(x) - x = 0" });
            comboBoxEquation.Location = new Point(69, 230);
            comboBoxEquation.Name = "comboBoxEquation";
            comboBoxEquation.Size = new Size(151, 28);
            comboBoxEquation.TabIndex = 24;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBoxEquation);
            Controls.Add(radioButtonNewton);
            Controls.Add(radioButtonMDP);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private RadioButton radioButtonMDP;
        private RadioButton radioButtonNewton;
        private ComboBox comboBoxEquation;
    }
}
