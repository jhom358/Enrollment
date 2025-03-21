using System;

class Enrollment
{
    static void Main(string[] args)
    {
        Console.WriteLine("WELCOME!!!\n");

        Console.WriteLine("ENROLLMENT FOR SCHOOL YEAR 2025-2026\n");

        string[] actions = new string[] {
        "[1] Register as a New Student",
        "[2] Exit" };

        foreach (string action in actions)
        {
            Console.WriteLine(action);
        }

        Console.Write("\nChoose an Actions: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                RegisterNewStudent();
                break;
            case "2":
                Console.WriteLine("Exiting");
                break;
            default:
                Console.WriteLine("Invalid Choice. Please choose between 1-2 only. ");
                break;
        }
        static void RegisterNewStudent()
        {
            Console.WriteLine("\nRegister as a New Student\n");
            Console.Write("Enter your Full Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nYour name is: " + name);

            Console.WriteLine("\nChoose your Course you want to apply:");
            string[] courses = { "[1] Bachelor of Science in Information Technology", "[2] Diploma in Information Technology", "[3] Exit" };

            foreach (string course in courses)
            {
                Console.WriteLine(course);
            }
            Console.WriteLine("\nEnter your Course: ");
            string courseChoice = Console.ReadLine();

            if (courseChoice == "3")
            {
                Console.WriteLine("Exiting Enrollment, Thank you for choosing our school!!!");
                return;
            }
            if (courseChoice == "1")
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("You have chosen Bachelor of Science in Information Technology");
                Console.ReadKey();
                Console.WriteLine("You are now registered as a new student of BSIT!");
            }
            else if (courseChoice == "2")
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("You have chosen Diploma in Information Technology");
                Console.ReadKey();
                Console.WriteLine("You are now registered as a new student of DIT!");
            }
            else
            {
                Console.WriteLine("Invalid Course. Please put the correct course what show below.");
                return;
            }



        }

    }
}