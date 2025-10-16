using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace EnrollmentGUI
{
    public partial class Student : Form
    {
        string connectionString = "Data Source=koy\\SQLEXPRESS; Initial Catalog=Enrollment; Integrated Security=True;TrustServerCertificate=True;";

        public Student()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = tb_Name.Text.Trim();
            string studentId = tb_StudentID.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(studentId))
            {
                MessageBox.Show("Please fill in both Name and Student ID!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Students WHERE Name = @name AND StudentID = @studentId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@studentId", studentId);

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Log in Successfully!", "Log in Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StudentDashboard dashboard = new StudentDashboard(name, studentId);
                            dashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Student Name or ID!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Hide();
        }
    }
}
