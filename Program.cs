using System;

class Enrollment
{
    static void Main(string[] args)
    {
        Console.WriteLine("WELCOME!!!\n");

        Console.WriteLine("ENROLLMENT FOR SCHOOL YEAR 2025-2026\n");

        string[] actions = new string[] {
        "[1] Faculty",
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
                Faculty();
                break;
            case "2":
                RegisterNewStudent();
                break;
            case "3":
                Console.WriteLine("\nExiting the system");
                break;
            default:
                Console.WriteLine("Invalid Choice. Please choose between 1-3 only.");
                break;
        }
    }

    static void RegisterNewStudent()
    {
        Console.WriteLine("\nRegister as a New Student\n");

        Console.Write("Enter your Full Name: ");

        string name = Console.ReadLine();

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
            return;
        }
        if (courseChoice == "1")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Information Technology");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSIT!");
        }
        else if (courseChoice == "2")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Diploma in Information Technology");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of DIT!");
        }
        else if (courseChoice == "3")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Computer Engineering");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSCPE!");

        }
        else if (courseChoice == "4")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Industrial Engineering");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSIE!");
        }
        else if (courseChoice == "5")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Diploma in Computer Engineering");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of DCE!");
        }
        else if (courseChoice == "6")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Diploma in Industrial Engineering Technology");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of DIET!");
        }
        else if (courseChoice == "7")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Psychology");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSP!");
        }
        else if (courseChoice == "8")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Business Administration Major in Human Resource Management");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSBA-HRM!");
        }
        else if (courseChoice == "9")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Secondary Education Major in English");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSE-English!");
        }
        else if (courseChoice == "10")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Secondary Education Major in Social Studies");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSE-Social Studies!");
        }
        else if (courseChoice == "11")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Elementary Education");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BEED!");
        }
        else if (courseChoice == "12")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("You have chosen Bachelor of Science in Accountancy");
            Console.ReadKey();
            Console.WriteLine("You are now enrolled as a new student of BSA!");
        }
        else
        {
            Console.WriteLine("Invalid Course. Please put the correct course number as shown below.");
            return;
        }
    }


    static void Faculty()
    {
        Console.WriteLine("\nLog in as a Faculty");

        Console.Write("\nEnter your Faculty Account: ");

        string username = Console.ReadLine();

        if (username == "jhom")
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

        if (username == "jhom" && password == "123")
        {
            Console.WriteLine();
            Console.WriteLine("Log in Successful!");
        }
        else
        {
            Console.WriteLine("Invalid Username or Password. Please try again.");
        }
    }
}