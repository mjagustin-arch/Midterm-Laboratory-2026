using System;
using System.Collections.Generic;  

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}
struct Operation
{
    public string Action;          
    public string StudentNumber;
    public string StudentName;
}
class StudentApp
{
    static Student[] students = new Student[10];   
    static int count = 0;
        static Stack<Operation> operationHistory = new Stack<Operation>();

    static void Main()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("       STUDENT RECORD MANAGEMENT");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Operation History");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.Write("Enter choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1) AddStudent();
            else if (choice == 2) DisplayStudents();
            else if (choice == 3) UpdateStudent();
            else if (choice == 4) DeleteStudent();
            else if (choice == 5) HistoryMenu();
            else if (choice == 6) Console.WriteLine("Goodbye!");
            else Console.WriteLine("Invalid choice!");

            Console.WriteLine();
        }
    }

    static int FindStudent(string number)
    {
        for (int i = 0; i < count; i++)
        {
            if (students[i].StudentNumber == number)
            {
                return i;
            }
        }
        return -1;
    }
   
    static void RecordOperation(string action, string number, string name)
    {
        Operation op;
        op.Action = action;
        op.StudentNumber = number;
        op.StudentName = name;

        operationHistory.Push(op);
    }

    static void AddStudent()
    {
        if (count == 10)
        {
            Console.WriteLine("Array is full!");
            return;
        }

        Student s;

        Console.Write("Enter Student Number: ");
        s.StudentNumber = Console.ReadLine();

        if (FindStudent(s.StudentNumber) != -1)
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

        students[count] = s;
        count++;

        RecordOperation("Added", s.StudentNumber, s.Name);  

        Console.WriteLine();
        Console.WriteLine("Student added successfully!");
    }
    static void DisplayStudents()
    {
        if (count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Student Number: " + students[i].StudentNumber);
            Console.WriteLine("Name          : " + students[i].Name);
            Console.WriteLine("Program       : " + students[i].Program);
            Console.WriteLine("Year Level    : " + students[i].YearLevel);
            Console.WriteLine();
        }
    }
    static void UpdateStudent()
    {
        Console.Write("Enter Student Number to update: ");
        string number = Console.ReadLine();

        int index = FindStudent(number);

        if (index == -1)
        {
            Console.WriteLine("Student not found!");
            return;
        }

        Console.Write("Enter New Name: ");
        students[index].Name = Console.ReadLine();
        Console.Write("Enter New Program: ");
        students[index].Program = Console.ReadLine();

        Console.Write("Enter New Year Level: ");
        students[index].YearLevel = Convert.ToInt32(Console.ReadLine());
        while (students[index].YearLevel < 1 || students[index].YearLevel > 4)
        {
            Console.Write("Year Level must be 1-4. Enter again: ");
            students[index].YearLevel = Convert.ToInt32(Console.ReadLine());
        }

        RecordOperation("Updated", number, students[index].Name);  

        Console.WriteLine();
        Console.WriteLine("Student updated successfully!");
    }
    static void DeleteStudent()
    {
        Console.Write("Enter Student Number to delete: ");
        string number = Console.ReadLine();

        int index = FindStudent(number);

        if (index == -1)
        {
            Console.WriteLine("Student not found!");
            return;
        }

        string name = students[index].Name; 

        for (int i = index; i < count - 1; i++)
        {
            students[i] = students[i + 1];
        }
        count--;

        RecordOperation("Deleted", number, name);   

        Console.WriteLine();
        Console.WriteLine("Student deleted successfully!");
    }

    static void HistoryMenu()
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("            OPERATION HISTORY");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("1. View Operation History");
            Console.WriteLine("2. View Last Operation");
            Console.WriteLine("3. Remove Last Operation");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
            Console.Write("Enter choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1) ViewHistory();
            else if (choice == 2) ViewLastOperation();
            else if (choice == 3) RemoveLastOperation();
            else if (choice == 4) Console.WriteLine("Back to main menu.");
            else Console.WriteLine("Invalid choice!");

            Console.WriteLine();
        }
    }
    static void ViewHistory()
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No recorded operations.");
            return;
        }

        Console.WriteLine("OPERATION HISTORY");
        Console.WriteLine();


        Operation[] list = operationHistory.ToArray();

        int number = 1;
        for (int i = list.Length - 1; i >= 0; i--)
        {
            Console.WriteLine(number + ". " + list[i].Action + " " + list[i].StudentName);
            number++;
        }
    }

    static void ViewLastOperation()
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No recorded operations.");
            return;
        }

        Operation last = operationHistory.Peek();   

        Console.WriteLine("Last Operation: " + last.Action + " " + last.StudentName);
    }
    static void RemoveLastOperation()
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No recorded operations.");
            return;
        }

        operationHistory.Pop();   

        Console.WriteLine("Last operation removed successfully!");
    }
}
