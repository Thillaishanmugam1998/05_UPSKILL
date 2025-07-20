using System;

class VariablesAndDataTypes
{
    static void Main()
    {
        // Integer types
        int age = 25;
        long population = 7800000000L;
        byte score = 95;

        // Floating-point types
        double price = 19.99;  //double price = 19.99d;
        float temperature = 36.5f;
        decimal salary = 75000.50m;

        // Text types
        string name = "John Doe";
        char grade = 'A';

        // Boolean type
        bool isStudent = true;
        bool isEmployed = false;

        // Display all variables
        Console.WriteLine("=== Variables and Data Types ===");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Population: {population}");
        Console.WriteLine($"Score: {score}");
        Console.WriteLine($"Price: {price}");
        Console.WriteLine($"Temperature: {temperature}");
        Console.WriteLine($"Salary: {salary}");
        Console.WriteLine($"Grade: {grade}");
        Console.WriteLine($"Is Student: {isStudent}");
        Console.WriteLine($"Is Employed: {isEmployed}");

        // Getting type information
        Console.WriteLine($"\nType of age: {age.GetType()}");
        Console.WriteLine($"Type of name: {name.GetType()}");
        Console.WriteLine($"Type of price: {price.GetType()}");
    }
}