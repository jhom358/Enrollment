namespace EnrollmentBusinessLogic
{
    public class EnrollBusinessLogic
    {
        public static List<string> nameOfStudents = new List<string>();
        public static List<string> programOfStudents = new List<string>();
        public static void studentList(string name, string program)
        {
            nameOfStudents.Add(name);
            programOfStudents.Add(program);
        }
        public static bool RemoveStudent(string name)
        {
            if (nameOfStudents.Contains(name))
            {
                int studentOrder = nameOfStudents.IndexOf(name);
                programOfStudents.RemoveAt(studentOrder);
                nameOfStudents.Remove(name);
                return true;
            }
            return false;
        }

    }
}

