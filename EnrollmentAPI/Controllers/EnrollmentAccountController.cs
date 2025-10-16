using EnrollmentBusinessData;
using EnrollmentBusinessLogic;
using EnrollmentCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentAccountController : ControllerBase
    {
        static EnrollBusinessLogic enrollmentBusinessLogic = new EnrollBusinessLogic();
        [HttpGet]
        public IEnumerable<EnrollmentCommon.Student> GetEnrollmentAccounts()
        {
            return enrollmentBusinessLogic.GetAllStudents();
        }
        [HttpPatch("Change Program")]
        public void UpdateStudentProgram(string StudentID, string newProgram)
        {
            enrollmentBusinessLogic.UpdateStudentProgram(StudentID, newProgram);
        }
        [HttpPatch("Change Name")]
        public void UpdateStudentName(string StudentID, string newName)
        {
            enrollmentBusinessLogic.UpdateStudentName(StudentID, newName);
        }
        [HttpPost("Add Student")]
        public void AddStudent(string name, string program)
        {
            EnrollBusinessLogic.AddStudents(name, program);
        }
        [HttpDelete("Remove Student")]
        public bool RemoveStudent(string studentID)
        {
            return enrollmentBusinessLogic.RemoveStudent(studentID);
        }
    }
}
