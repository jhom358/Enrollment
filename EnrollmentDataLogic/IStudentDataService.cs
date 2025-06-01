using EnrollmentCommon;
using System.Collections.Generic;

namespace EnrollmentDataService
{
    public interface IStudentDataService
    {
        List<Student> GetAllStudents();
        void AddStudent(Student student);
        bool RemoveStudent(string name);
        Student FindStudent(string name);
        void UpdateStudentName(Student student, string newName);
        void UpdateStudentProgram(Student student, string newProgram);
        bool Login(string? name, string? studentID);
    }
}
