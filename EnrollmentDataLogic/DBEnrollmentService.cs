using System;
using System.Collections.Generic;
using EnrollmentCommon;
using Microsoft.Data.SqlClient;

namespace EnrollmentDataService
{
    public class DBEnrollmentService : IStudentDataService
    {
        static string connectionString =
            "Data Source=koy\\SQLEXPRESS;Initial Catalog=Enrollment;Integrated Security=True;TrustServerCertificate=True;";

        public void AddStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Student (Name, Course, StudentID) VALUES (@Name, @Course, @StudentID)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Course", student.Program); 
                    command.Parameters.AddWithValue("@StudentID", student.StudentID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Student FindStudent(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Name, Course, StudentID FROM Student WHERE Name = @Name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student(
                                reader["Name"].ToString(),
                                reader["Course"].ToString(), 
                                reader["StudentID"].ToString()
                            );
                        }
                    }
                }
            }
            return null;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Name, Course, StudentID FROM Student";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student(
                            reader["Name"].ToString(),
                            reader["Course"].ToString(), 
                            reader["StudentID"].ToString()
                        ));
                    }
                }
            }
            return students;
        }

        public int GetMaxStudentSequenceId()
        {
            int maxSequenceId = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COALESCE(MAX(CAST(SUBSTRING(StudentID, 6, 5) AS INT)), 0) FROM Student";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        maxSequenceId = Convert.ToInt32(result);
                    }
                }
            }
            return maxSequenceId;
        }
        public bool Login(string name, string studentID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Student WHERE Name = @Name AND StudentID = @StudentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public bool RemoveStudent(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Student WHERE Name = @Name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public void UpdateStudentName(Student student, string newName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Student SET Name = @NewName WHERE StudentID = @StudentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewName", newName);
                    command.Parameters.AddWithValue("@StudentID", student.StudentID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStudentProgram(Student student, string newProgram)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Student SET Course = @NewProgram WHERE StudentID = @StudentID"; 
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewProgram", newProgram);
                    command.Parameters.AddWithValue("@StudentID", student.StudentID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}