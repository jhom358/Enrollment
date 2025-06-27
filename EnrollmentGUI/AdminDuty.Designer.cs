namespace EnrollmentGUI
{
    partial class AdminDuty
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
            btn_view = new Button();
            btn_remove = new Button();
            btn_edit = new Button();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btn_view
            // 
            btn_view.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_view.Location = new Point(12, 61);
            btn_view.Name = "btn_view";
            btn_view.Size = new Size(156, 66);
            btn_view.TabIndex = 0;
            btn_view.Text = "View Registered Student";
            btn_view.UseVisualStyleBackColor = true;
            btn_view.Click += btn_view_Click;
            // 
            // btn_remove
            // 
            btn_remove.BackColor = Color.White;
            btn_remove.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_remove.Location = new Point(388, 61);
            btn_remove.Name = "btn_remove";
            btn_remove.Size = new Size(156, 66);
            btn_remove.TabIndex = 1;
            btn_remove.Text = "Remove Registered Student";
            btn_remove.UseVisualStyleBackColor = false;
            btn_remove.Click += btn_remove_Click;
            // 
            // btn_edit
            // 
            btn_edit.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_edit.Location = new Point(198, 61);
            btn_edit.Name = "btn_edit";
            btn_edit.Size = new Size(156, 66);
            btn_edit.TabIndex = 2;
            btn_edit.Text = "Edit the Student's Name or Program";
            btn_edit.UseVisualStyleBackColor = true;
            btn_edit.Click += btn_edit_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(123, 182);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(297, 188);
            dataGridView1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(469, 370);
            button1.Name = "button1";
            button1.Size = new Size(75, 31);
            button1.TabIndex = 4;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AdminDuty
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 561);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(btn_edit);
            Controls.Add(btn_remove);
            Controls.Add(btn_view);
            Name = "AdminDuty";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminDuty";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_view;
        private Button btn_remove;
        private Button btn_edit;
        private DataGridView dataGridView1;
        private Button button1;
    }
}