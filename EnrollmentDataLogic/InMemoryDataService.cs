using EnrollmentCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentDataService
{
    public class InMemoryDataService : IStudentDataService
    {
        private static List<Student> students = new List<Student>();
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
            students.Add(new Student
            {
                Name = student.Name,
                StudentID = GenerateStudentID(),
                Program = student.Program
            });
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
                    return true;
                }
            }
            return false;
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
        public void UpdateStudentName(Student student, string newName)
        {
            foreach(var stud in students)
            {
                if (stud.StudentID == student.StudentID)
                {
                    stud.Name = newName;
                }
            }
        }

        public void UpdateStudentProgram(Student student, string newProgram)
        {
            foreach (var stud in students)
            {
                if (stud.StudentID == student.StudentID)
                {
                    stud.Program = newProgram;
                }
            }
        }

        List<Student> IStudentDataService.GetStudentData()
        {
            throw new NotImplementedException();
        }
    }
}
