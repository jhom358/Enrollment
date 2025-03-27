namespace EnrollmentBusinessLogic
{
    public class EnrollBusinessLogic
    {
        public static List<string> enrolledStudents = new List<string>();
        public static void studentList(string name, string program)
        {
            enrolledStudents.Add(name + "\t" + program);
        }
        public static string removedStudent(string name)
        {
            string student = enrolledStudents.Find(x => x.Contains(name));
            enrolledStudents.Remove(student);
            return student;
        }

    }
}

