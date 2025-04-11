using System;
using System.Reflection;
using EnrollmentBusinessLogic;
using EnrollmentCommon;

class Enrollment
{
    static EnrollmentManager enrollmentManager = new EnrollmentManager();
    static void Main(string[] args)
    {
        Menu();
    }
    static void Menu()
    {
        Console.WriteLine();
        Console.WriteLine("WELCOME!!!\n");

        Console.WriteLine("ENROLLMENT FOR SCHOOL YEAR 2025-2026\n");

        string[] actions = new string[] { "[1] Admin", "[2] Register as a new Student", "[3] Exit" };

        foreach (string action in actions)
        {
            Console.WriteLine(action);
        }

        Console.Write("\nChoose an Actions: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                LoginAdmin();
                break;
            case "2":
                RegisterNewStudent();
                break;
            case "3":
                Console.WriteLine("\nExiting the system");
                break;
            default:
                Console.WriteLine();
                Console.WriteLine("Invalid Choice. Please choose between 1-3 only.");
                Menu();
                break;

        }
    }
    static void RegisterNewStudent()
    {
        Console.WriteLine("\nRegister as a New Student\n");

        Console.Write("Enter your Full Name: ");

        string name = Console.ReadLine().ToUpper();

        Console.WriteLine("\nYour name is: " + name);

        Console.WriteLine("\nChoose your Course you want to apply:\n");
        string[] courses = { "[1] Bachelor of Science in Information Technology", "[2] Diploma in Information Technology",
            "[3] Bachelor of Science in Computer Engineering", "[4] Bachelor of Science in Industrial Engineering", "[5] Diploma in Computer Engineering", "[6] Diploma in Industrial Engineering Technology",
            "[7] Bachelor of Science in Psychology", "[8] Bachelor of Science in Business Administration Major in Human Resource Management",
            "[9] Bachelor of Secondary Education Major in English", "[10] Bachelor of Secondary Education Major in Social Studies", "[11] Bachelor of Elementary Education",
            "[12] Bachelor of Science in Accountancy", "[13] Exit" };

        foreach (string course in courses)
        {
            Console.WriteLine(course);
        }

        Console.Write("\nEnter your Course: ");
        string courseChoice = Console.ReadLine();

        if (courseChoice == "13")
        {
            Console.WriteLine("Exiting Enrollment, Thank you for choosing our school!!!");
            Menu();
            return;
        }
        if (courseChoice == "1")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Information Technology");
            EnrollmentManager enrollmentManager = new EnrollmentManager();
            enrollmentManager.EnrollStudent(name, "BSIT");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSIT!");
            Menu();
        }
        else if (courseChoice == "2")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Diploma in Information Technology");
            EnrollmentManager enrollmentManager = new EnrollmentManager();
            enrollmentManager.EnrollStudent(name, "DIT");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of DIT!");
            Menu();
        }
        else if (courseChoice == "3")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Computer Engineering");
            EnrollmentManager enrollmentManager = new EnrollmentManager();
            enrollmentManager.EnrollStudent(name, "BSCPE");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSCPE!");
            Menu();
        }
        else if (courseChoice == "4")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Industrial Engineering");
            EnrollmentManager enrollmentManager = new EnrollmentManager();
            enrollmentManager.EnrollStudent(name, "BSIE");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSIE!");
            Menu();
        }
        else if (courseChoice == "5")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Diploma in Computer Engineering");
            EnrollmentManager enrollmentManager = new EnrollmentManager();
            enrollmentManager.EnrollStudent(name, "DCE");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of DCE!");
            Menu();
        }
        else if (courseChoice == "6")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Diploma in Industrial Engineering Technology");
            EnrollmentManager enrollmentManager = new EnrollmentManager();
            enrollmentManager.EnrollStudent(name, "DIET");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of DIET!");
            Menu();
        }
        else if (courseChoice == "7")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Psychology");
            EnrollmentManager enrollmentManager = new EnrollmentManager();
            enrollmentManager.EnrollStudent(name, "BSP");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSP!");
            Menu();
        }
        else if (courseChoice == "8")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Business Administration Major in Human Resource Management");
            EnrollmentManager enrollmentManager = new EnrollmentManager();
            enrollmentManager.EnrollStudent(name, "BSBA-HRM");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSBA-HRM!");
            Menu();
        }
        else if (courseChoice == "9")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Secondary Education Major in English");
            EnrollmentManager enrollmentManager = new EnrollmentManager();
            enrollmentManager.EnrollStudent(name, "BSE-English");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSE-English!");
            Menu();
        }
        else if (courseChoice == "10")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Secondary Education Major in Social Studies");
            EnrollmentManager enrollmentManager = new EnrollmentManager();
            enrollmentManager.EnrollStudent(name, "BSE-Social Studies");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSE-Social Studies!");
            Menu();
        }
        else if (courseChoice == "11")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Elementary Education");
            EnrollmentManager enrollmentManager = new EnrollmentManager();
            enrollmentManager.EnrollStudent(name, "BEED");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BEED!");
            Menu();
        }
        else if (courseChoice == "12")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Accountancy");
            EnrollmentManager enrollmentManager = new EnrollmentManager();
            enrollmentManager.EnrollStudent(name, "BSA");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSA!");
            Menu();
        }
        else
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Invalid Course Number. Please put the correct course number as shown below.");
            RegisterNewStudent();
        }
    }
    static void LoginAdmin()
    {
        Console.WriteLine("\nLog in as a Admin");

        Console.Write("\nEnter your Admin Account: ");

        string username = Console.ReadLine();

        if (username == "admin")
        {
            Console.WriteLine();
            Console.WriteLine("Username Successful.");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Invalid Username. Please try again.");
            LoginAdmin();
        }
        Console.WriteLine();
        Console.Write("Enter your Password: ");

        string password = Console.ReadLine();

        if (username == "admin" && password == "123")
        {
            Console.WriteLine();
            Console.WriteLine("Log in Successful!");
            Admin();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Incorrect username or Password.");
            LoginAdmin();
        }
    }
    static void Admin()
    {
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("[1] View Enrolled Students\n[2] Remove Enrolled Students\n[3] Edit the Name or Program of the Enrolled Students\n[4] Exit");
        Console.Write("Enter action: ");
        int action = Convert.ToInt16(Console.ReadLine());
        EnrollmentManager enrollmentManager = new EnrollmentManager();

        if (action == 1)
        {

            ShowStudents();
        }
        else if (action == 2)
        {
            Console.WriteLine("----------------------------------------------");
            Console.Write("Enter the name of the student you want to remove: ");
            string removeStudent = Console.ReadLine().ToUpper();

            if (enrollmentManager.RemoveStudent(removeStudent))
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Removed Enrolled Student Successfully!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No Student Found! Please put the correct Student Name that you want to remove.");
            }

            Admin();
        }
        else if (action == 3)
        {
            EditStudent();
        }

        else
        {
            Console.WriteLine();
            Console.WriteLine("Exiting the System");
            Menu();
        }



    }
    static void ShowStudents()
    {
        EnrollmentManager enrollmentManager = new EnrollmentManager();
        var students = enrollmentManager.GetAllStudents();

        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Program: {student.Program}");
            Console.WriteLine($"Student ID: {student.StudentID}");
            Console.WriteLine("----------------------------------------------");
        }

        Console.ReadKey();
        Admin();
    }
    static void EditStudent()
    {
        Console.WriteLine("----------------------------------------------");
        Console.Write("Enter the name of the student you want to Edit: ");
        string editStudent = Console.ReadLine().ToUpper();

        var student = enrollmentManager.GetStudent(editStudent);
        if (student == null)
        {
            Console.WriteLine();
            Console.WriteLine("Student not Found.");
            Admin();
            return;
        }
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("What do you want to Edit?");
        Console.WriteLine("[1] Name\n[2] Program");
        Console.WriteLine("----------------------------------------------");
        Console.Write("Enter an Action: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.WriteLine("----------------------------------------------");
            Console.Write("Enter new Name: ");
            string newName = Console.ReadLine().ToUpper();
            enrollmentManager.UpdateStudentName(student.Name, newName);
            Console.WriteLine("Name Updated!");
        }
        else if (choice == "2")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Choose new Program: ");
            string[] programs = {
            "BSIT", "DIT", "BSCPE", "BSIE", "DCE", "DIET", "BSP", "BSBA-HRM",
            "BSE-ENGLISH", "BSE-SOCIAL STUDIES", "BEED", "BSA"
        };

            for (int i = 0; i < programs.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {programs[i]}");
            }

            Console.Write("Enter program Number: ");
            int programChoice = Convert.ToInt32(Console.ReadLine());

            if (programChoice >= 1 && programChoice <= programs.Length)
            {
                Console.WriteLine("Program updated Successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Program Selection.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Choice.");
        }

        Admin();
    }

}