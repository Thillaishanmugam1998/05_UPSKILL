using System;

class ConsoleInputOutput
{
    static void Main()
    {
        Console.WriteLine("=== Console Input/Output Demo ===");

        // Basic output
        Console.WriteLine("Hello, World!");
        Console.Write("This is on the same line. ");
        Console.WriteLine("This continues the line.");

        // Getting user input
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();

        Console.Write("Enter your age: ");
        string ageInput = Console.ReadLine();
        int userAge = int.Parse(ageInput);

        Console.Write("Are you a student? (true/false): ");
        string studentInput = Console.ReadLine();
        bool isStudent = bool.Parse(studentInput);

        // Display collected information
        Console.WriteLine("\n=== Your Information ===");
        Console.WriteLine($"Name: {userName}");
        Console.WriteLine($"Age: {userAge}");
        Console.WriteLine($"Student: {isStudent}");

        // Formatted output examples
        Console.WriteLine("\n=== Formatted Output Examples ===");
        double price = 99.99;
        Console.WriteLine("Price: ${0}", price);
        Console.WriteLine($"Price with string interpolation: ${price}");
        Console.WriteLine("Price with formatting: {0:C}", price); // Currency format
        Console.WriteLine("Price with 2 decimals: {0:F2}", price);

        // Wait for key press
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}