using System;
using EnrollmentCommon;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;


namespace EnrollmentDataService
{
    internal class DBEnrollmentService : IStudentDataService
    {
        static string connectionString
        = "Data Source =DESKTOP-B62R382; Initial Catalog = Enrollment; Integrated Security = True; TrustServerCertificate=True;";

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
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public bool Login(string? name, string? studentID)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStudent(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudentName(Student student, string newName)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudentProgram(Student student, string newProgram)
        {
            throw new NotImplementedException();
        }
    }
}
