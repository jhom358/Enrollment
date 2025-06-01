using System;
using EnrollmentCommon;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;


namespace EnrollmentDataService
{
    public class DBEnrollmentService : IStudentDataService
    {
        static string connectionString
        = "Data Source =koy\\SQLEXPRESS; Initial Catalog = Enrollment; Integrated Security = True; TrustServerCertificate=True;";

        static SqlConnection sqlConnection;
        public DBEnrollmentService()
        {
            sqlConnection = new SqlConnection(connectionString);
        }


        public void AddStudent(Student student)
        {
            var insertStatement = "INSERT INTO Student VALUES (@Name, @Course, @StudentID)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Name", student.Name);
            insertCommand.Parameters.AddWithValue("@Course", student.Course);
            insertCommand.Parameters.AddWithValue("@StudentID", student.StudentID);

            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public Student FindStudent(string name)
        {
            string query = "SELECT * FROM Student WHERE Name = @Name";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Name", name);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Student student = null;

            if (reader.Read())
            {
                student = new Student
                {
                    Name = reader["Name"].ToString(),
                    Course = reader["Course"].ToString(),
                    StudentID = reader["StudentID"].ToString()
                };
            }

            reader.Close();
            sqlConnection.Close();
            return student;
        }
        

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            string query = "SELECT * FROM Student";
            SqlCommand command = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student
                {
                    Name = reader["Name"].ToString(),
                    Course = reader["Course"].ToString(),
                    StudentID = reader["StudentID"].ToString()
                });
            }

            reader.Close();
            sqlConnection.Close();
            return students;
        }

        public bool Login(string? name, string? studentID)
        {
            string query = "SELECT COUNT(*) FROM Student WHERE Name = @Name AND StudentID = @StudentID";
            SqlCommand command = new SqlCommand(query, sqlConnection);

            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@StudentID", studentID);

            sqlConnection.Open();
            int count = (int)command.ExecuteScalar();
            sqlConnection.Close();

            return count > 0;
        }

        public bool RemoveStudent(string name)
        {
            string query = "DELETE FROM Student WHERE Name = @Name";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Name", name);

            sqlConnection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            sqlConnection.Close();

            return rowsAffected > 0;
        }

        public void UpdateStudentName(Student student, string newName)
        {
            string query = "UPDATE Student SET Name = @NewName WHERE StudentID = @StudentID";
            SqlCommand command = new SqlCommand(query, sqlConnection);

            command.Parameters.AddWithValue("@NewName", newName);
            command.Parameters.AddWithValue("@StudentID", student.StudentID);

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpdateStudentProgram(Student student, string newProgram)
        {
            string query = "UPDATE Student SET Course = @NewProgram WHERE StudentID = @StudentID";
            SqlCommand command = new SqlCommand(query, sqlConnection);

            command.Parameters.AddWithValue("@NewProgram", newProgram);
            command.Parameters.AddWithValue("@StudentID", student.StudentID);

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}