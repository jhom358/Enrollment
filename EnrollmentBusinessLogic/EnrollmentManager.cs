using EnrollmentCommon;
using EnrollmentDataService;
using System.Collections.Generic;

namespace EnrollmentBusinessLogic
{
    public class EnrollmentManager
    {
        private readonly IStudentDataService studentDataService;


        public EnrollmentManager(IStudentDataService dataService)
        {
            studentDataService = dataService;
        }

        public void EnrollStudent(string name, string program)
        {
            var student = new Student(name, program);
            studentDataService.AddStudent(student);
        }

        public bool RemoveStudent(string name)
        {
            return studentDataService.RemoveStudent(name);
        }

        public Student GetStudent(string name)
        {
            return studentDataService.FindStudent(name);
        }

        public void UpdateStudentName(string oldName, string newName)
        {
            var student = GetStudent(oldName);
            if (student != null)
            {
                studentDataService.UpdateStudentName(student, newName);
            }
        }

        public void UpdateStudentProgram(string name, string newProgram)
        {
            var student = GetStudent(name);
            if (student != null)
            {
                studentDataService.UpdateStudentProgram(student, newProgram);
            }
        }

        public List<Student> GetAllStudents()
        {
            return studentDataService.GetAllStudents();
        }
    }
}
