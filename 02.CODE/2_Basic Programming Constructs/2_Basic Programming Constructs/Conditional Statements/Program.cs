using System;

class ConditionalStatementsDemo
{
    static void Main()
    {
        Console.WriteLine("=== CONDITIONAL STATEMENTS DEMO ===\n");

        // 1. Basic if statement
        int temperature = 25;
        if (temperature > 30)
        {
            Console.WriteLine("It's hot outside!");
        }

        // 2. if-else statement
        int age = 17;
        if (age >= 18)
        {
            Console.WriteLine("You can vote!");
        }
        else
        {
            Console.WriteLine("You cannot vote yet.");
        }

        // 3. if-else if-else chain
        int score = 85;
        if (score >= 90)
        {
            Console.WriteLine("Grade: A");
        }
        else if (score >= 80)
        {
            Console.WriteLine("Grade: B");
        }
        else if (score >= 70)
        {
            Console.WriteLine("Grade: C");
        }
        else if (score >= 60)
        {
            Console.WriteLine("Grade: D");
        }
        else
        {
            Console.WriteLine("Grade: F");
        }

        // 4. Switch statement
        char grade = 'B';
        switch (grade)
        {
            case 'A':
                Console.WriteLine("Excellent work!");
                break;
            case 'B':
                Console.WriteLine("Good job!");
                break;
            case 'C':
                Console.WriteLine("Average performance.");
                break;
            case 'D':
                Console.WriteLine("Below average.");
                break;
            case 'F':
                Console.WriteLine("Failing grade.");
                break;
            default:
                Console.WriteLine("Invalid grade.");
                break;
        }

        // 5. Ternary operator
        int number = 15;
        string result = (number % 2 == 0) ? "Even" : "Odd";
        Console.WriteLine($"The number {number} is {result}");

        // 6. Complex conditions with logical operators
        int hour = 14;
        bool isWeekend = false;

        if (hour >= 9 && hour <= 17 && !isWeekend)
        {
            Console.WriteLine("Office is open");
        }
        else
        {
            Console.WriteLine("Office is closed");
        }
    }
}