namespace Windows_Feature_Control_Panel
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
            button4 = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            comboBox2 = new ComboBox();
            label3 = new Label();
            comboBox3 = new ComboBox();
            label4 = new Label();
            comboBox4 = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            comboBox5 = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            Debug = new Label();
            comboBox6 = new ComboBox();
            button5 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(29, 13);
            button1.Name = "button1";
            button1.Size = new Size(100, 35);
            button1.TabIndex = 0;
            button1.Text = "Taskbar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(135, 14);
            button2.Name = "button2";
            button2.Size = new Size(100, 35);
            button2.TabIndex = 1;
            button2.Text = "Start Menu";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(347, 13);
            button3.Name = "button3";
            button3.Size = new Size(108, 35);
            button3.TabIndex = 2;
            button3.Text = "File Explorer";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(461, 13);
            button4.Name = "button4";
            button4.Size = new Size(115, 35);
            button4.TabIndex = 3;
            button4.Text = "Log In Screen";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(31, 81);
            label1.Name = "label1";
            label1.Size = new Size(101, 21);
            label1.TabIndex = 4;
            label1.Text = "Taskbar Type:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Windows 11", "Windows 10" });
            comboBox1.Location = new Point(138, 81);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 24);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(29, 122);
            label2.Name = "label2";
            label2.Size = new Size(345, 21);
            label2.TabIndex = 6;
            label2.Text = "MMT Taskbar (Taskbar on secondary monitor(s)):";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Disabled", "Enabled" });
            comboBox2.Location = new Point(377, 122);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 24);
            comboBox2.TabIndex = 7;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(29, 167);
            label3.Name = "label3";
            label3.Size = new Size(186, 21);
            label3.TabIndex = 8;
            label3.Text = "Windows 11 Taskbar size:";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Small", "Medium (Default)", "Large" });
            comboBox3.Location = new Point(221, 166);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 24);
            comboBox3.TabIndex = 9;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(29, 217);
            label4.Name = "label4";
            label4.Size = new Size(186, 21);
            label4.TabIndex = 10;
            label4.Text = "Windows 10 Taskbar size:";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Default", "Small" });
            comboBox4.Location = new Point(221, 214);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(121, 24);
            comboBox4.TabIndex = 11;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(31, 267);
            label5.Name = "label5";
            label5.Size = new Size(170, 21);
            label5.TabIndex = 12;
            label5.Text = "Show Task Wiev Icon: X";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(29, 320);
            label6.Name = "label6";
            label6.Size = new Size(107, 21);
            label6.TabIndex = 13;
            label6.Text = "Show Search: ";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(29, 377);
            label7.Name = "label7";
            label7.Size = new Size(172, 21);
            label7.TabIndex = 14;
            label7.Text = "Combine Taskbar Icons:";
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Items.AddRange(new object[] { "Always Combine", "Combine only when taskbar full", "Never Combine" });
            comboBox5.Location = new Point(207, 374);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(135, 24);
            comboBox5.TabIndex = 15;
            comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(12, 531);
            label8.Name = "label8";
            label8.Size = new Size(148, 21);
            label8.TabIndex = 16;
            label8.Text = "Restart File Explorer";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(419, 531);
            label9.Name = "label9";
            label9.Size = new Size(176, 21);
            label9.TabIndex = 17;
            label9.Text = "Reset settings to default";
            // 
            // Debug
            // 
            Debug.AutoSize = true;
            Debug.Location = new Point(275, 531);
            Debug.Name = "Debug";
            Debug.Size = new Size(44, 16);
            Debug.TabIndex = 18;
            Debug.Text = "Debug";
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Items.AddRange(new object[] { "Disabled", "Icon", "Search Box (Default)", "Search Icon and Label" });
            comboBox6.Location = new Point(142, 317);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(144, 24);
            comboBox6.TabIndex = 19;
            comboBox6.SelectedIndexChanged += comboBox6_SelectedIndexChanged;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(241, 13);
            button5.Name = "button5";
            button5.Size = new Size(100, 35);
            button5.TabIndex = 20;
            button5.Text = "Search";
            button5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 563);
            Controls.Add(button5);
            Controls.Add(comboBox6);
            Controls.Add(Debug);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(comboBox5);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(comboBox4);
            Controls.Add(label4);
            Controls.Add(comboBox3);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            MaximumSize = new Size(623, 602);
            MinimumSize = new Size(623, 602);
            Name = "Form1";
            Text = "Windows Feature Control Panel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private ComboBox comboBox2;
        private Label label3;
        private ComboBox comboBox3;
        private Label label4;
        private ComboBox comboBox4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox comboBox5;
        private Label label8;
        private Label label9;
        private Label Debug;
        private ComboBox comboBox6;
        private Button button5;
    }
}