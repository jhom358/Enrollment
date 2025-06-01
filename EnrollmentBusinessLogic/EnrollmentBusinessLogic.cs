using EnrollmentDataService;

namespace EnrollmentBusinessLogic
{
    public class EnrollBusinessLogic
    {
        public static List<string> nameOfStudents = new List<string>();
        public static List<string> programOfStudents = new List<string>();
        public static List<string> studentIDs = new List<string>();

        public static void studentList(string name, string program, string id)
        {
            nameOfStudents.Add(name);
            programOfStudents.Add(program);
            studentIDs.Add(id);
        }
        public static bool RemoveStudent(string name)
        {
            if (nameOfStudents.Contains(name))
            {
                int studentOrder = nameOfStudents.IndexOf(name);
                programOfStudents.RemoveAt(studentOrder);
                nameOfStudents.Remove(name);
                studentIDs.RemoveAt(studentOrder);

                return true;
            }
            return false;
        }

    }
}

