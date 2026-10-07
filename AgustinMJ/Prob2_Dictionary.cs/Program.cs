using System;
using System.Collections.Generic;   

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}
class StudentLookup
{
    static Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();

    static void Main()
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("      STUDENT LOOKUP USING DICTIONARY");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Display All Students");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
            Console.Write("Enter choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1) AddStudent();
            else if (choice == 2) SearchStudent();
            else if (choice == 3) DisplayAll();
            else if (choice == 4) Console.WriteLine("Goodbye!");
            else Console.WriteLine("Invalid choice!");

            Console.WriteLine();
        }
    }
    static void AddStudent()
    {
        Student s;

        Console.Write("Enter Student Number: ");
        s.StudentNumber = Console.ReadLine();

        if (studentDictionary.ContainsKey(s.StudentNumber))
        {
            Console.WriteLine();
            Console.WriteLine("Student Number already exists!");
            return;
        }

        Console.Write("Enter Name: ");
        s.Name = Console.ReadLine();
        Console.Write("Enter Program: ");
        s.Program = Console.ReadLine();

        Console.Write("Enter Year Level: ");
        s.YearLevel = Convert.ToInt32(Console.ReadLine());
        while (s.YearLevel < 1 || s.YearLevel > 4)
        {
            Console.Write("Year Level must be 1-4. Enter again: ");
            s.YearLevel = Convert.ToInt32(Console.ReadLine());
        }

        studentDictionary.Add(s.StudentNumber, s);

        Console.WriteLine();
        Console.WriteLine("Student added successfully!");
    }
    static void SearchStudent()
    {
        Console.Write("Enter Student Number to search: ");
        string number = Console.ReadLine();
        Console.WriteLine();

        if (studentDictionary.ContainsKey(number))
        {
            Student s = studentDictionary[number];  

            Console.WriteLine("Student Found!");
            Console.WriteLine("Student Number: " + s.StudentNumber);
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Program: " + s.Program);
            Console.WriteLine("Year Level: " + s.YearLevel);
        }
        else
        {
            Console.WriteLine("Student not found!");
        }
    }
    static void DisplayAll()
    {
        if (studentDictionary.Count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }

        foreach (Student s in studentDictionary.Values)
        {
            Console.WriteLine("Student Number: " + s.StudentNumber);
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Program: " + s.Program);
            Console.WriteLine("Year Level: " + s.YearLevel);
            Console.WriteLine();
        }
    }
}

