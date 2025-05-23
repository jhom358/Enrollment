//using System.Collections.Generic;
//using System.Linq;
//using EnrollmentCommon;

//namespace EnrollmentBusinessData
//{
//    public static class StudentDataService
//    {
//        private static List<Student> _students = new List<Student>();

//        public static void AddStudent(Student student)
//        {
//            _students.Add(student);
//        }

//        public static bool RemoveStudent(string name)
//        {
//            var student = _students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
//            if (student != null)
//            {
//                _students.Remove(student);
//                return true;
//            }
//            return false;
//        }

//        public static Student FindStudent(string name)
//        {
//            return _students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
//        }

//        public static List<Student> GetAllStudents()
//        {
//            return _students;
//        }

//        public static void UpdateStudentName(Student student, string newName)
//        {
//            student.Name = newName;
//        }

//        public static void UpdateStudentProgram(Student student, string newProgram)
//        {
//            student.Program = newProgram;
//        }
//    }
//}