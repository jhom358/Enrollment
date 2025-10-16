using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;

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
                string name = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();

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

                    RemoveStudentFromFiles(studentId);

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

                UpdateStudentInFiles(studentId, newName, newProgram);

                MessageBox.Show("Student updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudents();
            }
        }

        private void RemoveStudentFromFiles(string studentId)
        {
            string txtPath = "students.txt";
            string jsonPath = "students.json";

 
            if (File.Exists(txtPath))
            {
                var lines = File.ReadAllLines(txtPath).ToList();
                lines.RemoveAll(line => line.Contains($"StudentID: {studentId}"));
                File.WriteAllLines(txtPath, lines);
            }

            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                var students = JsonConvert.DeserializeObject<List<StudentData>>(json) ?? new List<StudentData>();
                students.RemoveAll(s => s.StudentID == studentId);
                string newJson = JsonConvert.SerializeObject(students, Formatting.Indented);
                File.WriteAllText(jsonPath, newJson);
            }
        }

        private void UpdateStudentInFiles(string studentId, string newName, string newProgram)
        {
            string txtPath = "students.txt";
            string jsonPath = "students.json";

            if (File.Exists(txtPath))
            {
                var lines = File.ReadAllLines(txtPath).ToList();
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Contains($"StudentID: {studentId}"))
                    {
                        lines[i] = $"Name: {newName}, StudentID: {studentId}, Program: {newProgram}";
                        break;
                    }
                }
                File.WriteAllLines(txtPath, lines);
            }

            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                var students = JsonConvert.DeserializeObject<List<StudentData>>(json) ?? new List<StudentData>();
                foreach (var student in students)
                {
                    if (student.StudentID == studentId)
                    {
                        student.Name = newName;
                        student.Program = newProgram;
                        break;
                    }
                }
                string updatedJson = JsonConvert.SerializeObject(students, Formatting.Indented);
                File.WriteAllText(jsonPath, updatedJson);
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
    }
}
   