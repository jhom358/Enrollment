using EnrollmentCommon;
using System.Collections.Generic;

namespace EnrollmentDataService
{
    public interface IStudentDataService
    {
        List<Student> GetAllStudents();
        public string GenerateStudentID();
        public string DisplayStudentID();
        public void AddStudent(Student student);
        public bool RemoveStudent(string name);
        public bool Login(Student student);
        public bool FindStudents(Student student);
        public void UpdateStudentName(Student student, string newName);
        public void UpdateStudentProgram(Student student, string newProgram);
    }
}
