using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using EnrollmentCommon;

namespace EnrollmentDataService
{
    public class TextFileDataService : IStudentDataService
    {

        //public string FilePath = "students.txt";
        public  string FilePath = "students.json";
        private IStudentDataService dataService;

        public TextFileDataService(IStudentDataService dataService)
        {
            this.dataService = dataService;
        }

        public void AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Student FindStudent(string name)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public int GetMaxStudentSequenceId()
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
