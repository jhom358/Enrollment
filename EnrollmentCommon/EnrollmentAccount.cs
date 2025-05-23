using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentCommon
{
    public class Student
    {
        private static int studentCount = 0;
        public string Name { get; set; }
        public string Program { get; set; }
        public string StudentID { get; set; }
        public Student(string name, string program, string studentID)
        {
            Name = name;
            Program = program;
            StudentID = studentID;
        }

        public Student(string name, string program)
        {
            Name = name;
            Program = program;
            StudentID = GenerateStudentID();
        }
        public string GenerateStudentID()
        {
            studentCount++;
            return "2025-" + studentCount.ToString("D5");
        }
    }
}
