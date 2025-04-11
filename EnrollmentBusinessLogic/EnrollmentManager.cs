using EnrollmentCommon;
using EnrollmentBusinessData;
using System.Collections.Generic;

namespace EnrollmentBusinessLogic
{
    public class EnrollmentManager
    {
        public void EnrollStudent(string name, string program)
        {
            var student = new Student(name, program);
            StudentDataService.AddStudent(student);
        }

        public bool RemoveStudent(string name)
        {
            return StudentDataService.RemoveStudent(name);
        }

        public Student GetStudent(string name)
        {
            return StudentDataService.FindStudent(name);
        }

        public void UpdateStudentName(string oldName, string newName)
        {
            var student = GetStudent(oldName);
            if (student != null)
            {
                StudentDataService.UpdateStudentName(student, newName);
            }
        }

        public void UpdateStudentProgram(string name, string newProgram)
        {
            var student = GetStudent(name);
            if (student != null)
            {
                StudentDataService.UpdateStudentProgram(student, newProgram);
            }
        }

        public List<Student> GetAllStudents()
        {
            return StudentDataService.GetAllStudents();
        }
    }
}