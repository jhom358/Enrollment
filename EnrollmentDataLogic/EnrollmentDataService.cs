using System.Collections.Generic;
using System.Linq;
using EnrollmentCommon;
using EnrollmentDataService;
namespace EnrollmentBusinessData
{
    public class StudentDataService 
    {
        IStudentDataService interfaceData;
        public StudentDataService()
        {
            //interfaceData = new InMemoryDataService();
            //interfaceData = new JsonFileDataService();
            interfaceData = new TextFileDataService();
            //interfaceData = new DBEnrollmentService();
        }
        public string DisplayStudentID()
        {
            return interfaceData.DisplayStudentID();
        }
        public List<Student> GetStudentData()
        {
            return interfaceData.GetAllStudents();
        }
        public void AddStudents(Student student)
        {
            interfaceData.AddStudent(student);
        }

        public bool RemoveStudent(string name)
        {
            return interfaceData.RemoveStudent(name);
        }

        public bool Login(Student student)
        {
            return interfaceData.Login(student);
        }

        public List<Student> GetAllStudents()
        {
            return interfaceData.GetAllStudents();
        }

        public void UpdateStudentName(Student student, string newName)
        {
            interfaceData.UpdateStudentName(student, newName);
        }

        public  void UpdateStudentProgram(Student student, string newProgram)
        {
            interfaceData.UpdateStudentProgram(student, newProgram);
        }
        public bool FindStudents(Student student)
        {
            return interfaceData.FindStudents(student);
        }

        
    }
}