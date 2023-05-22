namespace _219996
{
    partial class Windows11Control
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
            label1 = new Label();
            label2 = new Label();
            doesntsupport = new Label();
            win10taskbar = new Button();
            button2 = new Button();
            button6 = new Button();
            comboBox1 = new ComboBox();
            label3 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(342, 400);
            button1.Name = "button1";
            button1.Size = new Size(137, 35);
            button1.TabIndex = 0;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(-3, 409);
            label1.Name = "label1";
            label1.Size = new Size(172, 30);
            label1.TabIndex = 1;
            label1.Text = "Windows Version";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(514, 405);
            label2.Name = "label2";
            label2.Size = new Size(68, 30);
            label2.TabIndex = 2;
            label2.Text = "label2";
            label2.Click += label2_Click;
            // 
            // doesntsupport
            // 
            doesntsupport.AutoSize = true;
            doesntsupport.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            doesntsupport.ForeColor = Color.Red;
            doesntsupport.Location = new Point(-3, 389);
            doesntsupport.Name = "doesntsupport";
            doesntsupport.Size = new Size(328, 20);
            doesntsupport.TabIndex = 3;
            doesntsupport.Text = "The app doesn't support this version of windows";
            // 
            // win10taskbar
            // 
            win10taskbar.Location = new Point(12, 36);
            win10taskbar.Name = "win10taskbar";
            win10taskbar.Size = new Size(166, 53);
            win10taskbar.TabIndex = 4;
            win10taskbar.Text = "[Enable] Windows10 Taskbar";
            win10taskbar.UseVisualStyleBackColor = true;
            win10taskbar.Click += win10taskbar_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 114);
            button2.Name = "button2";
            button2.Size = new Size(166, 53);
            button2.TabIndex = 5;
            button2.Text = "[Enable] Windows10 Start Menu (only works with Windows11 Taskbar)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button6
            // 
            button6.Location = new Point(342, 358);
            button6.Name = "button6";
            button6.Size = new Size(137, 36);
            button6.TabIndex = 9;
            button6.Text = "Restart explorer";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Small", "Medium", "Large" });
            comboBox1.Location = new Point(342, 86);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(166, 23);
            comboBox1.TabIndex = 10;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(300, 47);
            label3.Name = "label3";
            label3.Size = new Size(248, 25);
            label3.TabIndex = 11;
            label3.Text = "Set Windows11 taskbar size:";
            // 
            // button3
            // 
            button3.Location = new Point(12, 189);
            button3.Name = "button3";
            button3.Size = new Size(166, 53);
            button3.TabIndex = 12;
            button3.Text = "[Enable] Taskbar on other monitors(Experimental)";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Windows11Control
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(button6);
            Controls.Add(button2);
            Controls.Add(win10taskbar);
            Controls.Add(doesntsupport);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "Windows11Control";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Windows11 Control";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label doesntsupport;
        private Button win10taskbar;
        private Button button2;
        private Button button6;
        private ComboBox comboBox1;
        private Label label3;
        private Button button3;
    }
}