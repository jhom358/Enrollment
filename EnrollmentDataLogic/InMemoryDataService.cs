using EnrollmentCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EnrollmentDataService
{
    public class JsonFileStudentDataService : IStudentDataService
    {
        private static List<Student> students = new List<Student>();
        private static string jsonFilePath = "students.json";

        public JsonFileStudentDataService()
        {
            if (File.Exists(jsonFilePath))
            {
                ReadJsonDataFromFile();
            }
            else
            {
                students = new List<Student>();
                WriteJsonDataToFile();
            }
        }

        private void ReadJsonDataFromFile()
        {
            string jsonText = File.ReadAllText(jsonFilePath);
            students = JsonSerializer.Deserialize<List<Student>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Student>();
        }

        private void WriteJsonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(students, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(jsonFilePath, jsonString);
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
            WriteJsonDataToFile();
        }

        public bool RemoveStudent(string name)
        {
            var student = students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (student != null)
            {
                students.Remove(student);
                WriteJsonDataToFile();
                return true;
            }
            return false;
        }

        public Student FindStudent(string name)
        {
            return students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Student> GetAllStudents()
        {
            return new List<Student>(students); 
        }

        public void UpdateStudentName(Student student, string newName)
        {
            var target = students.FirstOrDefault(s => s.StudentID == student.StudentID);
            if (target != null)
            {
                target.Name = newName;
                WriteJsonDataToFile();
            }
        }

        public void UpdateStudentProgram(Student student, string newProgram)
        {
            var target = students.FirstOrDefault(s => s.StudentID == student.StudentID);
            if (target != null)
            {
                target.Program = newProgram;
                WriteJsonDataToFile();
            }
        }

        public bool Login(string? name, string? studentID)
        {
            throw new NotImplementedException();
        }

        public int GetMaxStudentSequenceId()
        {
            throw new NotImplementedException();
        }
    }
}
