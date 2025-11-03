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
        private readonly EnrollmentBusinessLogic.EnrollBusinessLogic _EnrollBusinessLogic;

        public EnrollmentAccountController(EnrollmentBusinessLogic.EnrollBusinessLogic enrollBusinessLogic)
        {
            _EnrollBusinessLogic = enrollBusinessLogic;
        }
        [HttpGet]
        public IEnumerable<EnrollmentCommon.Student> GetEnrollmentAccounts()
        {
            return _EnrollBusinessLogic.GetAllStudents();
        }
        [HttpPatch("Change Program")]
        public void UpdateStudentProgram(string StudentID, string newProgram)
        {
            _EnrollBusinessLogic.UpdateStudentProgram(StudentID, newProgram);
        }
        [HttpPatch("Change Name")]
        public void UpdateStudentName(string StudentID, string newName)
        {
            _EnrollBusinessLogic.UpdateStudentName(StudentID, newName);
        }
        [HttpPost("Add Student")]
        public void AddStudent(string name, string program)
        {
            _EnrollBusinessLogic.AddStudents(name, program);
        }
        [HttpDelete("Remove Student")]
        public bool RemoveStudent(string studentID)
        {
            return _EnrollBusinessLogic.RemoveStudent(studentID);
        }
    }
}
