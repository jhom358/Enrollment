using EnrollmentCommon;
using System.Collections.Generic;
using System.Linq;

namespace EnrollmentDataService
{
    public class StudentDataService
    {
        private List<StudentData> students = new List<StudentData>();

        public void AddStudent(StudentData student)
        {
            students.Add(student);
        }

        public List<StudentData> GetAllStudents()
        {
            return students;
        }

        public StudentData GetStudentByName(string name)
        {
            return students.FirstOrDefault(s => s.Name == name);
        }

        public bool RemoveStudent(string name)
        {
            var student = GetStudentByName(name);
            if (student != null)
            {
                students.Remove(student);
                return true;
            }
            return false;
        }

        public string GenerateStudentID()
        {
            return "S" + (1000 + students.Count + 1).ToString();
        }
    }
}
