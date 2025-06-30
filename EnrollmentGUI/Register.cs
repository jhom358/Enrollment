using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace EnrollmentGUI
{
    public partial class Register : Form
    {
        string connectionString = "Data Source=koy\\SQLEXPRESS; Initial Catalog=Enrollment; Integrated Security=True;TrustServerCertificate=True;";

        public Register()
        {
            InitializeComponent();
            this.Load += new EventHandler(Register_Program);
        }

        private void Register_Program(object sender, EventArgs e)
        {
            comboBox1.Items.Add("BSIT");
            comboBox1.Items.Add("DIT");
            comboBox1.Items.Add("BSCPE");
            comboBox1.Items.Add("DCE");
            comboBox1.Items.Add("DIET");
            comboBox1.Items.Add("BSP");
            comboBox1.Items.Add("BSBA-HRM");
            comboBox1.Items.Add("BSE-English");
            comboBox1.Items.Add("BSE-Social Studies");
            comboBox1.Items.Add("BEED");
            comboBox1.Items.Add("BSA");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int cursor = tb_register.SelectionStart;
            tb_register.Text = tb_register.Text;
            tb_register.SelectionStart = cursor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_register.Text))
            {
                MessageBox.Show("Please enter your name first!", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_register.Focus();
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a course!", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.DroppedDown = true;
                return;
            }

            string name = tb_register.Text.Trim();
            string program = comboBox1.SelectedItem.ToString();
            string studentId = GenerateStudentID();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Students (Name, StudentID, Program) VALUES (@name, @studentId, @program)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@program", program);
                        cmd.ExecuteNonQuery();
                    }
                }

                string textPath = Path.Combine(Application.StartupPath, "students.txt");
                string line = $"Name: {name}, StudentID: {studentId}, Program: {program}";
                File.AppendAllText(textPath, line + Environment.NewLine);

                string jsonPath = Path.Combine(Application.StartupPath, "students.json");
                List<StudentData> students = new List<StudentData>();

                if (File.Exists(jsonPath))
                {
                    string existingJson = File.ReadAllText(jsonPath);
                    students = JsonConvert.DeserializeObject<List<StudentData>>(existingJson) ?? new List<StudentData>();
                }

                students.Add(new StudentData
                {
                    Name = name,
                    StudentID = studentId,
                    Program = program
                });

                string updatedJson = JsonConvert.SerializeObject(students, Formatting.Indented);
                File.WriteAllText(jsonPath, updatedJson);

                MessageBox.Show("Registered Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_register.Clear();
                comboBox1.SelectedIndex = -1;

                Student studentForm = new Student();
                studentForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data:\n" + ex.Message, "Database/File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Hide();
        }

        private string GenerateStudentID()
        {
            int studentNumber = 0;
            string studentID = $"2025-{studentNumber}";
            List<string> existingIDs = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT StudentID FROM Students WHERE StudentID LIKE '2025-%'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            existingIDs.Add(reader.GetString(0));
                        }
                    }
                }

                while (existingIDs.Contains(studentID))
                {
                    studentNumber++;
                    studentID = $"2025-{studentNumber}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating ID:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return studentID;
        }
    }
}
   
