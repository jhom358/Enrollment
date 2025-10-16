using EnrollmentCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentDataService
{
    public class TextFileDataService : IStudentDataService
    {
        private string filepath = "students.txt";
        List<Student> students = new List<Student>();
        public TextFileDataService()
        {
            GetDataFromText();
        }
        private void GetDataFromText()
        {
            
            string[] lines = File.ReadAllLines(filepath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    students.Add(new Student
                    {
                        Name = parts[0],
                        StudentID = parts[1],
                        Program = parts[2]
                    });
                }
            }
        }

        private void SaveDataToFile()
        {
            var lines = new string[students.Count];

            for (int i = 0; i < students.Count; i++)
            {
                lines[i] = $"{students[i].Name}|{students[i].StudentID}|{students[i].Program}";
            }

            File.WriteAllLines(filepath, lines);
        }
        public List<Student> GetAllStudents()
        {
            return students;
        }

        public string GenerateStudentID()
        {
            int studentNumber = students.Count();
            string studentID = $"2025-{studentNumber}";
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
            
            var newStudent = $"{student.Name}|{student.StudentID}|{student.Program}\n";
            File.AppendAllText(filepath, newStudent);
        }

        public bool RemoveStudent(string studentID)
        {
            foreach (var stud in students)
            {
                if (stud.StudentID == studentID)
                {
                    students.Remove(stud);
                    SaveDataToFile();
                    return true;
                }
            }
            return false;
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
            foreach (var stud in students)
            {
                if (stud.StudentID == student.StudentID)
                {
                    stud.Name = newName;
                    SaveDataToFile();
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
                    SaveDataToFile();
                }
            }
        }

        List<Student> IStudentDataService.GetStudentData()
        {
            throw new NotImplementedException();
        }
    }
}