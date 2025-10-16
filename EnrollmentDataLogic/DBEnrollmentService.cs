using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnrollmentCommon;
using Microsoft.Data.SqlClient;
namespace EnrollmentDataService
{
    public class DBEnrollmentService : IStudentDataService
    {
        string connectionString = "Data Source =koy\\SQLEXPRESS; Initial Catalog = Enrollment ; Integrated Security=true;TrustServerCertificate=True;";
        SqlConnection sqlConnection;
        List<Student> students = new List<Student>();
        public DBEnrollmentService()
        {
            sqlConnection = new SqlConnection(connectionString);
            GetDataFromDatabase();
        }
        public void GetDataFromDatabase()
        {

            sqlConnection.Open();
            string query = "SELECT * FROM Students";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                students.Add(new Student
                {
                    Name = reader["Name"].ToString(),
                    StudentID = reader["StudentID"].ToString(),
                    Program = reader["Program"].ToString()
                });
            }
            reader.Close();
            sqlConnection.Close();
        }

        public string GenerateStudentID()
        {
            int studentNumber = students.Count();
            string studentID = $"2025-{studentNumber}";
            foreach (var stud in students)
            {
                if (stud.StudentID == studentID)
                {
                    studentNumber++;
                    studentID = $"2025-{studentNumber}";
                }
            }
            return studentID;
        }
        public string DisplayStudentID()
        {
            return students.Last().StudentID;
        }

        public void AddStudent(Student student)
        {
            student.StudentID = GenerateStudentID();
            students.Add(new Student
            {
                Name = student.Name,
                StudentID = student.StudentID,
                Program = student.Program
            });
            sqlConnection.Open();
            string insertQuery = "INSERT INTO Students (Name, StudentID, Program) VALUES (@Name, @StudentID, @Program)";
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
            insertCommand.Parameters.AddWithValue("@Name", student.Name);
            insertCommand.Parameters.AddWithValue("@StudentID", student.StudentID);
            insertCommand.Parameters.AddWithValue("@Program", student.Program);
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
        public bool FindStudents(Student student)
        {
            foreach (var stud in students)
            {
                if (stud.StudentID == student.StudentID)
                {
                    return true;
                }
            }
            return false;
        }


        public List<Student> GetAllStudents()
        {
            return students;
        }
        public bool Login(Student student)
        {
            foreach (var stud in students)
            {
                if (stud.Name == student.Name && stud.StudentID == student.StudentID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool RemoveStudent(string studentID)
        {
            foreach (var stud in students)
            {
                if (stud.StudentID == studentID)
                {
                    students.Remove(stud);
                    DeleteStudentFromDatabase(studentID);
                    return true;
                }
            }
            return false;
        }
        public void DeleteStudentFromDatabase(string studentID)
        {
            sqlConnection.Open();
            string deleteQuery = "DELETE FROM Students WHERE StudentID = @StudentID";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@StudentID", studentID);
            deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void UpdateStudentName(Student student, string newName)
        {
            foreach (var stud in students)
            {
                if (stud.StudentID == student.StudentID)
                {
                    stud.Name = newName;
                    UpdateStudentNameInDatabase(student.StudentID, newName);
                    return;
                }
            }
        }
        public void UpdateStudentNameInDatabase(string studentID, string newName)
        {
            sqlConnection.Open();
            string updateQuery = "Update students set Name = @Name where StudentID = @StudentID";
            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
            updateCommand.Parameters.AddWithValue("@Name", newName);
            updateCommand.Parameters.AddWithValue("@StudentID", studentID);
            updateCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpdateStudentProgram(Student student, string newProgram)
        {
            foreach (var stud in students)
            {
                if (stud.StudentID == student.StudentID)
                {
                    stud.Program = newProgram;
                    UpdateStudentProgramInDatabase(student.StudentID, newProgram);
                    return;
                }
            }
        }
        public void UpdateStudentProgramInDatabase(string studentID, string newProgram)
        {
            sqlConnection.Open();
            string updateQuery = "Update students set Program = @Program where StudentID = @StudentID";
            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
            updateCommand.Parameters.AddWithValue("@Program", newProgram);
            updateCommand.Parameters.AddWithValue("@StudentID", studentID);
            updateCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        List<Student> IStudentDataService.GetStudentData()
        {
            throw new NotImplementedException();
        }
    }
}