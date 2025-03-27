using System;
using EnrollmentBusinessLogic;

class Enrollment
{
    static void Main(string[] args)
    {
        Menu();
    }
    static void Menu()
    {
        Console.WriteLine();
        Console.WriteLine("WELCOME!!!\n");

        Console.WriteLine("ENROLLMENT FOR SCHOOL YEAR 2025-2026\n");

        string[] actions = new string[] {
        "[1] Admin",
        "[2] Register as a new Student",
        "[3] Exit" };

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
            EnrollBusinessLogic.studentList(name, "BSIT");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSIT!");
            Menu();
        }
        else if (courseChoice == "2")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Diploma in Information Technology");
            EnrollBusinessLogic.studentList(name, "DIT");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of DIT!");
            Menu();
        }
        else if (courseChoice == "3")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Computer Engineering");
            EnrollBusinessLogic.studentList(name, "BSCPE");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSCPE!");
            Menu();
        }
        else if (courseChoice == "4")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Industrial Engineering");
            EnrollBusinessLogic.studentList(name, "BSIE");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSIE!");
            Menu();
        }
        else if (courseChoice == "5")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Diploma in Computer Engineering");
            EnrollBusinessLogic.studentList(name, "DCE");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of DCE!");
            Menu();
        }
        else if (courseChoice == "6")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Diploma in Industrial Engineering Technology");
            EnrollBusinessLogic.studentList(name, "DIET");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of DIET!");
            Menu();
        }
        else if (courseChoice == "7")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Psychology");
            EnrollBusinessLogic.studentList(name, "BSP");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSP!");
            Menu();
        }
        else if (courseChoice == "8")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Business Administration Major in Human Resource Management");
            EnrollBusinessLogic.studentList(name, "BSBA-HRM");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSBA-HRM!");
            Menu();
        }
        else if (courseChoice == "9")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Secondary Education Major in English");
            EnrollBusinessLogic.studentList(name, "BSE-ENGLISH");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSE-English!");
            Menu();
        }
        else if (courseChoice == "10")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Secondary Education Major in Social Studies");
            EnrollBusinessLogic.studentList(name, "BSE-SOCIAL STUDIES");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSE-Social Studies!");
            Menu();
        }
        else if (courseChoice == "11")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Elementary Education");
            EnrollBusinessLogic.studentList(name, "BEED");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BEED!");
            Menu();
        }
        else if (courseChoice == "12")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Accountancy");
            EnrollBusinessLogic.studentList(name, "BSA");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSA!");
            Menu();
        }
        else
        {
            Console.WriteLine("Invalid Course. Please put the correct course number as shown below.");
            return;
        }
    }
    static void LoginAdmin()
    {
        Console.WriteLine("----------------------------------------------");
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
            Console.WriteLine("Invalid Username. Please try again.");
            return;
        }
        Console.WriteLine();
        Console.Write("Enter your Password: ");

        string password = Console.ReadLine();

        if (username == "admin" && password == "123")
        {
            Console.WriteLine("Log in Successful!");
            Admin();
        }
        else
        {
            Console.WriteLine("Incorrect username or password");
        }
    }
    static void Admin()
    {
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine("[1] Show Students\n[2] Remove Students\n[3] Exit");
        Console.Write("Enter action : ");
        int action = Convert.ToInt16(Console.ReadLine());
        if (action == 1)
        {

            ShowStudents();
        }
        else if (action == 2)
        {
            Console.WriteLine("----------------------------------------------");
            Console.Write("Enter the name of the student you want to remove: ");
            string removeStudent = Console.ReadLine().ToUpper();

            if (EnrollBusinessLogic.RemoveStudent(removeStudent))
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Student Removed Successfully!");
            }
            else
            {
                Console.WriteLine("No Student Found!");
            }
            Admin();
        }

        else
        {
            Console.WriteLine("Exiting the System");
            Menu();
        }


    }
    static void ShowStudents()
    {
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Name \t Program");


        for (int i = 0; i <= EnrollBusinessLogic.nameOfStudents.Count - 1; i++)
        {
            Console.WriteLine(EnrollBusinessLogic.nameOfStudents[i] + "\t" + EnrollBusinessLogic.programOfStudents[i]);

        }
        Console.ReadKey();
        Admin();
    }
}