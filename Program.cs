using System;
using System.Collections.Generic;
using System.IO;
using EnrollmentCommon;
using EnrollmentBusinessLogic;

class Enrollment
{
    static EnrollBusinessLogic businessLogic;
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
            "[1] Admin", "[2] Log in as a Student", "[3] Register as a new Student", "[4] Exit"
        };

        foreach (string action in actions)
        {
            Console.WriteLine(action);
        }

        Console.Write("\nChoose an Action: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                LoginAdmin();
                break;
            case "2":
                LoginStudent();
                break;
            case "3":
                RegisterNewStudent();
                break;
            case "4":
                Console.WriteLine("\nExiting the system");
                break;
            default:
                Console.WriteLine("\nInvalid Choice. Please choose between 1-4 only.");
                Menu();
                break;
        }
    }

    static void LoginStudent()
    {
        Console.WriteLine("\nLog in as a Student\n");
        Console.Write("Enter Name: ");
        string name = Console.ReadLine().ToUpper();

        Console.Write("Enter Student ID: ");
        string studentID = Console.ReadLine();

        bool isLoggedIn = businessLogic.Login(name, studentID);

        if (isLoggedIn)
        {
            Console.WriteLine("Login Successful!");
        }
        else
        {
            Console.WriteLine("Invalid Credentials. Please try Again.");
        }

        Menu();
    }

    private static void RegisterNewStudent()
    {
        Console.WriteLine("\nRegister as a New Student\n");
        Console.Write("Enter your Full Name: ");
        string name = Console.ReadLine().ToUpper();

        Console.WriteLine("\nChoose your Course you want to apply:\n");
        string[] courses = {
            "[1] BSIT", "[2] DIT", "[3] BSCPE", "[4] BSIE", "[5] DCE", "[6] DIET",
            "[7] BSP", "[8] BSBA-HRM", "[9] BSE-English", "[10] BSE-Social Studies",
            "[11] BEED", "[12] BSA", "[13] Exit"
        }; 
        string[] courseValue = {
            "BSIT", "DIT", "BSCPE", "BSIE", "DCE", "DIET",
            "BSP", "BSBA-HRM", "BSE-English", "BSE-Social Studies",
            "BEED", "BSA"
        };
        

        foreach (string course in courses)
        {
            Console.WriteLine(course);
        }

        Console.Write("\nEnter your Course Number: ");
        int courseChoice =  Convert.ToInt16(Console.ReadLine());

        courseChoice--;
        if (courseChoice == 13)
        {
            Console.WriteLine("Exiting Enrollment. Thank you!");
            Menu();
        }
        if (courseChoice < 13)
        {
            string program = courseValue[courseChoice];
            businessLogic.AddStudents(name, program);
            Console.WriteLine($"You are now enrolled as a new student of {program}!");
            Console.WriteLine($"Your Student ID is: {businessLogic.DisplayStudentID()}");
        }
        else
        {
            Console.WriteLine("Invalid Course Number. Please try again.");
        }
        Menu();
    }

    static void LoginAdmin()
    {
        Console.WriteLine("\nLog in as Admin");
        Console.Write("\nEnter your Admin Username: ");
        string username = Console.ReadLine();

        if (username != "admin")
        {
            Console.WriteLine("Invalid Username. Please try again.");
            LoginAdmin();
            return;
        }

        Console.Write("Enter your Password: ");
        string password = Console.ReadLine();

        if (password == "123")
        {
            Console.WriteLine("Log in Successful!");
            Admin();
        }
        else
        {
            Console.WriteLine("Incorrect Password.");
            LoginAdmin();
        }
    }

    static void Admin()
    {
        Console.WriteLine("\n[1] View Enrolled Students");
        Console.WriteLine("[2] Remove Enrolled Students");
        Console.WriteLine("[3] Edit Name or Program");
        Console.WriteLine("[4] Exit");
        Console.Write("Enter Action: ");

        int action = Convert.ToInt32(Console.ReadLine());

        switch (action)
        {
            case 1:
                ShowStudents();
                break;
            case 2:
                Console.Write("Enter StudentID to Remove : ");
                string removeName = Console.ReadLine();

                if (businessLogic.RemoveStudent(removeName))
                    Console.WriteLine("Student removed successfully!");
                else
                    Console.WriteLine("Student not found.");
                Admin();
                break;
            case 3:
                EditStudent();
                break;
            case 4:
                Menu();
                break;
            default:
                Console.WriteLine("Invalid option.");
                Admin();
                break;
        }
    }

    static void ShowStudents()
    {
        var students = businessLogic.GetAllStudents();

        foreach (var student in students)
        {
            string info = $" {student.Name} | {student.Program} |  {student.StudentID}";
            Console.WriteLine(info);
        }
        Console.ReadKey();
        Admin();
    }

    static void EditStudent()
    {
        Console.Write("Enter the StudentID to Edit : ");
        string studentID = Console.ReadLine().ToUpper();

        var student = businessLogic.GetStudent(studentID);
        if (student != true)
        {
            Console.WriteLine("Student not Found.");
            Admin();
            return;
        }
        Console.WriteLine("What do you want to edit? ");
        Console.WriteLine("[1] Edit Name");
        Console.WriteLine("[2] Edit Program");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Enter new Name: ");
            string newName = Console.ReadLine().ToUpper();
            businessLogic.UpdateStudentName(studentID, newName);
            Console.WriteLine("Name Updated.");
        }
        else if (choice == "2")
        {
            Console.WriteLine("Available Programs:");
            string[] programs = { "BSIT", "DIT", "BSCPE", "BSIE", "DCE", "DIET", "BSP", "BSBA-HRM", "BSE-ENGLISH", "BSE-SOCIAL STUDIES", "BEED", "BSA" };
            for (int i = 0; i < programs.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {programs[i]}");
            }

            Console.Write("Enter new program Number: ");
            int progIndex = Convert.ToInt32(Console.ReadLine());
            progIndex--; 
            if (progIndex >= 0 && progIndex < programs.Length)
            {
                businessLogic.UpdateStudentProgram(studentID, programs[progIndex]);
                Console.WriteLine("Program Updated.");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }
        else
        {
            Console.WriteLine("Invalid option.");
        }

        Admin();
    }
}
