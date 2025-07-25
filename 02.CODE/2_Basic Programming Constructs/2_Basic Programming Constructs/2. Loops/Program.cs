using System;
using System.Collections.Generic;

class LoopsDemo
{
    static void Main()
    {
        Console.WriteLine("=== LOOPS DEMO ===\n");

        // 1. For loop - when you know the number of iterations
        Console.WriteLine("1. For loop (counting 1 to 5):");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Count: {i}");
        }

        // For loop with different increments
        Console.WriteLine("\nFor loop (even numbers 0 to 10):");
        for (int i = 0; i <= 10; i += 2)
        {
            Console.WriteLine($"Even number: {i}");
        }

        // 2. While loop - when condition-based repetition is needed
        Console.WriteLine("\n2. While loop (countdown from 5):");
        int countdown = 5;
        while (countdown > 0)
        {
            Console.WriteLine($"Countdown: {countdown}");
            countdown--;
        }

        // 3. Do-while loop - executes at least once
        Console.WriteLine("\n3. Do-while loop (user input simulation):");
        string userInput;
        int attempts = 0;
        do
        {
            attempts++;
            Console.WriteLine($"Attempt {attempts}: Enter 'quit' to exit");
            // Simulating user input
            userInput = (attempts == 3) ? "quit" : "continue";
            Console.WriteLine($"User entered: {userInput}");
        }
        while (userInput != "quit" && attempts < 5);

        // 4. Foreach loop - for collections and arrays
        Console.WriteLine("\n4. Foreach loop with array:");
        string[] colors = { "Red", "Green", "Blue", "Yellow" };
        foreach (string color in colors)
        {
            Console.WriteLine($"Color: {color}");
        }

        // Foreach with List
        Console.WriteLine("\nForeach loop with List:");
        List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };
        foreach (int number in numbers)
        {
            Console.WriteLine($"Number: {number}");
        }

        // 5. Nested loops - loops inside loops
        Console.WriteLine("\n5. Nested loops (multiplication table):");
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                Console.Write($"{i * j:D2} ");
            }
            Console.WriteLine();
        }

        // 6. Loop control statements
        Console.WriteLine("\n6. Loop control (break and continue):");
        for (int i = 1; i <= 10; i++)
        {
            if (i == 5)
            {
                Console.WriteLine("Skipping 5");
                continue; // Skip this iteration
            }
            if (i == 8)
            {
                Console.WriteLine("Breaking at 8");
                break; // Exit the loop
            }
            Console.WriteLine($"Processing: {i}");
        }
    }
}