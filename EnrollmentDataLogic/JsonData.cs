using EnrollmentCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EnrollmentDataService
{
    public class JsonData : IStudentDataService
    {
        string filepath = "students.json";
        List<Student> students = new List<Student>();
        public JsonData()
        {
            GetDataFromJson();
        }
        private void GetDataFromJson()
        {
            string jsonText = File.ReadAllText(filepath);
            students = JsonSerializer.Deserialize<List<Student>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }
        private void SaveDataToFile()
        {
            string jsonText = JsonSerializer.Serialize(students,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filepath, jsonText);
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
            students.Add(new Student
            {
                Name = student.Name,
                StudentID = GenerateStudentID(),
                Program = student.Program
            });
            SaveDataToFile();
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
                    SaveDataToFile();
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
    }
}