using EnrollmentDataService;

internal class JsonLoginDataService
{
    private IStudentDataService dataService;

    public JsonLoginDataService(IStudentDataService dataService)
    {
        this.dataService = dataService;
    }
    internal bool Login(string? name, string? studentID)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(studentID))
            return false;

        var student = dataService.FindStudent(name.ToUpper());
        return student != null && student.StudentID == studentID;
    }
}
