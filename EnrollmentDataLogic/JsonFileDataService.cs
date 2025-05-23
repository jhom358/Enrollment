using EnrollmentCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EnrollmentDataService
{
    public class JsonFileDataService : IStudentDataService
    {
        private readonly string filePath;
        private List<Student> students;
        private readonly object fileLock = new object();

        public JsonFileDataService()
        {
            try
            {
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "students.json");
                students = new List<Student>();

                InitializeDataFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing data service: {ex.Message}");
                students = new List<Student>();
            }
        }
        public bool ValidateStudent(string name, string studentID)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(studentID))
            {
                return false;
            }
            var student = students.FirstOrDefault(s =>
                s.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                s.StudentID.Equals(studentID, StringComparison.OrdinalIgnoreCase));
            return student != null;
        }

        private void InitializeDataFile()
        {
            lock (fileLock)
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "[]");
                }
                else
                {
                    string json = File.ReadAllText(filePath);
                    students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
                }
            }
        }

        private void SaveChanges()
        {
            lock (fileLock)
            {
                try
                {
                    string json = JsonSerializer.Serialize(students,
                        new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(filePath, json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving data: {ex.Message}");
                    throw;
                }
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (string.IsNullOrWhiteSpace(student.Name))
            {
                throw new ArgumentException("Student name cannot be empty");
            }

            if (FindStudent(student.Name) != null)
            {
                throw new InvalidOperationException($"Student '{student.Name}' already exists");
            }

            students.Add(student);
            SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            return new List<Student>(students); 
        }

        public bool RemoveStudent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Student name cannot be empty");
            }

            var student = FindStudent(name);
            if (student != null)
            {
                students.Remove(student);
                SaveChanges();
                return true;
            }
            return false;
        }

        public Student FindStudent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Student name cannot be empty");
            }

            return students.FirstOrDefault(s =>
                s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void UpdateStudentName(Student student, string newName)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("New name cannot be empty");
            }

            var existing = students.FirstOrDefault(s => s.StudentID == student.StudentID);
            if (existing != null)
            {
                if (FindStudent(newName) != null && !newName.Equals(existing.Name, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException($"Student '{newName}' already exists");
                }

                existing.Name = newName;
                SaveChanges();
            }
        }

        public void UpdateStudentProgram(Student student, string newProgram)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (string.IsNullOrWhiteSpace(newProgram))
            {
                throw new ArgumentException("New program cannot be empty");
            }

            var existing = students.FirstOrDefault(s => s.StudentID == student.StudentID);
            if (existing != null)
            {
                existing.Program = newProgram;
                SaveChanges();
            }
        }
    }
}