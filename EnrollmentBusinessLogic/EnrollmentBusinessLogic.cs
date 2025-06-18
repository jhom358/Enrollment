using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnrollmentCommon;
using EnrollmentBusinessData;

namespace EnrollmentBusinessLogic
{
    public class EnrollBusinessLogic
    {
        static StudentDataService studentDataService = new StudentDataService();
        public bool Login(string name, string studentID)
        {
            var student = new Student
            {
                Name = name,
                StudentID = studentID
            };
            return studentDataService.Login(student);
        }
        public List<Student> GetAllStudents()
        {
            return studentDataService.GetAllStudents();
        }
        public string GenerateStudentID()
        {
            var students = studentDataService.GetAllStudents();
            var numberOfStudents = students.Count;
            return "2025-" + numberOfStudents.ToString("D5");
        }
        public void AddStudents(string name, string program)
        {
            var student = new Student
            {
                Name = name,
                Program = program,
                StudentID = GenerateStudentID()
            };
            studentDataService.AddStudents(student);
        }
        public bool RemoveStudent(string name)
        {
            return studentDataService.RemoveStudent(name);
        }
        public void UpdateStudentName(string name, string newName)
        {
            var oldName = new Student
            {
                Name = name
            };
            studentDataService.UpdateStudentName(oldName, newName);
        }
        public void UpdateStudentProgram(string program, string newProgram)
        {
            var oldProgram = new Student
            {
                Program = program
            };
            studentDataService.UpdateStudentProgram(oldProgram, newProgram);
        }
        public bool GetStudent(string name)
        {
            var student = new Student
            {
                Name = name
            };
            return studentDataService.FindStudents(student);
        }
        public List<Student> GetStudentData()
        {
            return studentDataService.GetStudentData();
        }
    }
}
