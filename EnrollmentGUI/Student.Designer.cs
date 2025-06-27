namespace EnrollmentGUI
{
    partial class Student
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
            label1 = new Label();
            tb_Name = new TextBox();
            tb_StudentID = new TextBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 6;
            // 
            // tb_Name
            // 
            tb_Name.Location = new Point(181, 181);
            tb_Name.Name = "tb_Name";
            tb_Name.Size = new Size(100, 23);
            tb_Name.TabIndex = 1;
            // 
            // tb_StudentID
            // 
            tb_StudentID.Location = new Point(181, 251);
            tb_StudentID.Name = "tb_StudentID";
            tb_StudentID.Size = new Size(100, 23);
            tb_StudentID.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(206, 308);
            button1.Name = "button1";
            button1.Size = new Size(75, 33);
            button1.TabIndex = 3;
            button1.Text = "Log in";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(62, 181);
            label2.Name = "label2";
            label2.Size = new Size(94, 17);
            label2.TabIndex = 4;
            label2.Text = "Student Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(62, 252);
            label3.Name = "label3";
            label3.Size = new Size(71, 17);
            label3.TabIndex = 5;
            label3.Text = "Student ID:";
            // 
            // button2
            // 
            button2.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(287, 308);
            button2.Name = "button2";
            button2.Size = new Size(75, 33);
            button2.TabIndex = 7;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Student
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 461);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(tb_StudentID);
            Controls.Add(tb_Name);
            Controls.Add(label1);
            Name = "Student";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tb_Name;
        private TextBox tb_StudentID;
        private Button button1;
        private Label label2;
        private Label label3;
        private Button button2;
    }
}