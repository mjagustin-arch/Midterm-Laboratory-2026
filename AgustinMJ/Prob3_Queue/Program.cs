
using System;
using System.Collections.Generic;   

struct StudentRequest
{
    public string StudentNumber;
    public string StudentName;
    public string RequestType;
}
class RequestQueueApp
{
    static Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();

    static void Main()
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("          STUDENT REQUEST QUEUE");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Add Request");
            Console.WriteLine("2. View Pending Requests");
            Console.WriteLine("3. Process Request");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
            Console.Write("Enter choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1) AddRequest();
            else if (choice == 2) ViewRequests();
            else if (choice == 3) ProcessRequest();
            else if (choice == 4) Console.WriteLine("Goodbye!");
            else Console.WriteLine("Invalid choice!");

            Console.WriteLine();
        }
    }
    static void AddRequest()
    {
        StudentRequest r;

        Console.Write("Enter Student Number: ");
        r.StudentNumber = Console.ReadLine();
        Console.Write("Enter Student Name: ");
        r.StudentName = Console.ReadLine();
        Console.Write("Enter Request Type: ");
        r.RequestType = Console.ReadLine();

        requestQueue.Enqueue(r);  

        Console.WriteLine();
        Console.WriteLine("Request added successfully!");
    }
    static void ViewRequests()
    {
        if (requestQueue.Count == 0)
        {
            Console.WriteLine("No pending requests.");
            return;
        }

        Console.WriteLine("REQUEST QUEUE");

        int number = 1;
        foreach (StudentRequest r in requestQueue)   
        {
            Console.WriteLine(number + ". " + r.StudentName + " - " + r.RequestType);
            number++;
        }
    }
    static void ProcessRequest()
    {
        if (requestQueue.Count == 0)
        {
            Console.WriteLine("No pending requests.");
            return;
        }

        StudentRequest r = requestQueue.Dequeue();   

        Console.WriteLine("Processing Request: " + r.StudentName + " - " + r.RequestType);
        Console.WriteLine();
        Console.WriteLine("Request processed successfully!");
    }
}
