using System;

class BasicOperators
{
    static void Main()
    {
        Console.WriteLine("=== Arithmetic Operators ===");
        int a = 15;
        int b = 4;

        Console.WriteLine($"a = {a}, b = {b}");
        Console.WriteLine($"Addition: {a} + {b} = {a + b}");
        Console.WriteLine($"Subtraction: {a} - {b} = {a - b}");
        Console.WriteLine($"Multiplication: {a} * {b} = {a * b}");
        Console.WriteLine($"Division: {a} / {b} = {a / b}");
        Console.WriteLine($"Modulus: {a} % {b} = {a % b}");

        // Increment and Decrement
        int x = 10;
        Console.WriteLine($"\nOriginal x: {x}");
        Console.WriteLine($"Pre-increment (++x): {++x}");
        Console.WriteLine($"Post-increment (x++): {x++}");
        Console.WriteLine($"After post-increment: {x}");
        Console.WriteLine($"Pre-decrement (--x): {--x}");
        Console.WriteLine($"Post-decrement (x--): {x--}");
        Console.WriteLine($"After post-decrement: {x}");

        Console.WriteLine("\n=== Comparison Operators ===");
        int num1 = 20;
        int num2 = 15;

        Console.WriteLine($"num1 = {num1}, num2 = {num2}");
        Console.WriteLine($"num1 == num2: {num1 == num2}");
        Console.WriteLine($"num1 != num2: {num1 != num2}");
        Console.WriteLine($"num1 > num2: {num1 > num2}");
        Console.WriteLine($"num1 < num2: {num1 < num2}");
        Console.WriteLine($"num1 >= num2: {num1 >= num2}");
        Console.WriteLine($"num1 <= num2: {num1 <= num2}");

        Console.WriteLine("\n=== Logical Operators ===");
        bool condition1 = true;
        bool condition2 = false;

        Console.WriteLine($"condition1 = {condition1}, condition2 = {condition2}");
        Console.WriteLine($"condition1 && condition2: {condition1 && condition2}");
        Console.WriteLine($"condition1 || condition2: {condition1 || condition2}");
        Console.WriteLine($"!condition1: {!condition1}");
        Console.WriteLine($"!condition2: {!condition2}");

        // Practical example
        int age = 25;
        bool hasLicense = true;
        bool canDrive = (age >= 18) && hasLicense;
        Console.WriteLine($"\nAge: {age}, Has License: {hasLicense}");
        Console.WriteLine($"Can Drive: {canDrive}");
    }
}