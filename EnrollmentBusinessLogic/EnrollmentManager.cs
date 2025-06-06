using EnrollmentCommon;
using EnrollmentDataService;
using System.Collections.Generic;
using System; 

namespace EnrollmentBusinessLogic
{
    public class EnrollmentManager
    {
        private IStudentDataService studentDataService;
        public static int _currentStudentSequence; 

        static EnrollmentManager()
        {
            DBEnrollmentService tempDbService = new DBEnrollmentService();
            _currentStudentSequence = tempDbService.GetMaxStudentSequenceId();
        }

        public EnrollmentManager(IStudentDataService dataService)
        {
            studentDataService = dataService;
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

        public void EnrollStudent(string name, string program)
        {
            _currentStudentSequence++;


            string newStudentID = $"2025-{_currentStudentSequence:D5}"; 

            var student = new Student(name, program, newStudentID);

            studentDataService.AddStudent(student);
        }

        public bool LoginStudent(string name, string studentID)
        {
            return studentDataService.Login(name, studentID);
        }
    }
}