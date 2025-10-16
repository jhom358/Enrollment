using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace EnrollmentGUI
{
    public partial class StudentDashboard : Form
    {
        private string studentName;
        private string studentId;
        private string connectionString = "Data Source=koy\\SQLEXPRESS; Initial Catalog=Enrollment; Integrated Security=True;TrustServerCertificate=True;";

        public StudentDashboard(string name, string id)
        {
            InitializeComponent();
            studentName = name;
            studentId = id;
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            lbl_name.Text = $"Name: {studentName}";
            lbl_studentId.Text = $"Student ID: {studentId}";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Program FROM Students WHERE Name = @name AND StudentID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", studentName);
                        cmd.Parameters.AddWithValue("@id", studentId);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            lbl_program.Text = "Program: " + reader["Program"].ToString();
                        }
                        else
                        {
                            lbl_program.Text = "Program: Not found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_logout_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Hide();
        }
    }
}
