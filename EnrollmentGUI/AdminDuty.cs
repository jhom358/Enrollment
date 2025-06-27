using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EnrollmentGUI
{
    public partial class AdminDuty : Form
    {
        string connectionString = "Data Source=koy\\SQLEXPRESS; Initial Catalog=Enrollment; Integrated Security=True;TrustServerCertificate=True;";

        public AdminDuty()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Students", conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string studentId = dataGridView1.CurrentRow.Cells["StudentID"].Value.ToString();

                DialogResult confirm = MessageBox.Show("Are you sure you want to remove this student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Students WHERE StudentID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", studentId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Student removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string studentId = dataGridView1.CurrentRow.Cells["StudentID"].Value.ToString();
                string currentName = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                string currentProgram = dataGridView1.CurrentRow.Cells["Program"].Value.ToString();

                string newName = Prompt("Enter new name:", currentName);
                string newProgram = Prompt("Enter new program:", currentProgram);

                if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newProgram))
                {
                    MessageBox.Show("Update cancelled. Fields cannot be empty.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Students SET Name = @name, Program = @program WHERE StudentID = @id", conn);
                    cmd.Parameters.AddWithValue("@name", newName);
                    cmd.Parameters.AddWithValue("@program", newProgram);
                    cmd.Parameters.AddWithValue("@id", studentId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Student updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudents();
            }
        }

        private string Prompt(string text, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Edit Info",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 10, Top = 20, Text = text, Width = 260 };
            TextBox inputBox = new TextBox() { Left = 10, Top = 50, Width = 260, Text = defaultValue };
            Button confirmation = new Button() { Text = "OK", Left = 180, Width = 90, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
