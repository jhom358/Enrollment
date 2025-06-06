using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentCommon
{
    public class Student
    {
        public string Name { get; set; }
        public string Program { get; set; }
        public string StudentID { get; set; }
        public Student(string name, string program, string studentID)
        {
            Name = name;
            Program = program;
            StudentID = studentID;
        }

        public Student()
        {
            Name = string.Empty;
            Program = string.Empty;
            StudentID = string.Empty;
        }

    }
}
