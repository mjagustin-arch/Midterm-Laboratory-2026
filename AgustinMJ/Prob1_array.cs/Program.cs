using System;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}
class StudentApp
{
    static Student[] students = new Student[10];
    static int count = 0;

    static void Main()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("       STUDENT RECORD MANAGEMENT");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.Write("Enter choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1) AddStudent();
            else if (choice == 2) DisplayStudents();
            else if (choice == 3) SearchStudent();
            else if (choice == 4) UpdateStudent();
            else if (choice == 5) DeleteStudent();
            else if (choice == 6) Console.WriteLine("Exited Successfully!");
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
    static void SearchStudent()
    {
        Console.Write("Enter Student Number to search: ");
        string number = Console.ReadLine();

        int index = FindStudent(number);

        if (index == -1)
        {
            Console.WriteLine("Student not found!");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Student Number: " + students[index].StudentNumber);
            Console.WriteLine("Name          : " + students[index].Name);
            Console.WriteLine("Program       : " + students[index].Program);
            Console.WriteLine("Year Level    : " + students[index].YearLevel);
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

        for (int i = index; i < count - 1; i++)
        {
            students[i] = students[i + 1];
        }
        count--;

        Console.WriteLine();
        Console.WriteLine("Student deleted successfully!");
    }
}

