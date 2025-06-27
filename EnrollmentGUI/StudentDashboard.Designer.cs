namespace EnrollmentGUI
{
    partial class StudentDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_studentId;
        private System.Windows.Forms.Label lbl_program;
        private System.Windows.Forms.Button btn_logout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lbl_name = new Label();
            lbl_studentId = new Label();
            lbl_program = new Label();
            btn_logout = new Button();
            SuspendLayout();
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Font = new Font("Segoe UI", 12F);
            lbl_name.Location = new Point(35, 35);
            lbl_name.Margin = new Padding(4, 0, 4, 0);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(55, 21);
            lbl_name.TabIndex = 0;
            lbl_name.Text = "Name:";
            // 
            // lbl_studentId
            // 
            lbl_studentId.AutoSize = true;
            lbl_studentId.Font = new Font("Segoe UI", 12F);
            lbl_studentId.Location = new Point(35, 81);
            lbl_studentId.Margin = new Padding(4, 0, 4, 0);
            lbl_studentId.Name = "lbl_studentId";
            lbl_studentId.Size = new Size(85, 21);
            lbl_studentId.TabIndex = 1;
            lbl_studentId.Text = "Student ID:";
            // 
            // lbl_program
            // 
            lbl_program.AutoSize = true;
            lbl_program.Font = new Font("Segoe UI", 12F);
            lbl_program.Location = new Point(35, 127);
            lbl_program.Margin = new Padding(4, 0, 4, 0);
            lbl_program.Name = "lbl_program";
            lbl_program.Size = new Size(74, 21);
            lbl_program.TabIndex = 2;
            lbl_program.Text = "Program:";
            // 
            // btn_logout
            // 
            btn_logout.Font = new Font("Segoe UI", 10F);
            btn_logout.Location = new Point(308, 182);
            btn_logout.Margin = new Padding(4, 3, 4, 3);
            btn_logout.Name = "btn_logout";
            btn_logout.Size = new Size(88, 35);
            btn_logout.TabIndex = 3;
            btn_logout.Text = "Logout";
            btn_logout.UseVisualStyleBackColor = true;
            btn_logout.Click += btn_logout_Click;
            // 
            // StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 254);
            Controls.Add(lbl_name);
            Controls.Add(lbl_studentId);
            Controls.Add(lbl_program);
            Controls.Add(btn_logout);
            Margin = new Padding(4, 3, 4, 3);
            Name = "StudentDashboard";
            Text = "Student Dashboard";
            Load += StudentDashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
