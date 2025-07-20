using System;

class ConstantsAndLiterals
{
    // Class-level constants
    const double PI = 3.14159265359;
    const int MAX_STUDENTS = 30;
    const string SCHOOL_NAME = "Tech Academy";

    // readonly can be assigned at runtime in constructor
    static readonly DateTime PROGRAM_START_TIME = DateTime.Now;
    readonly int instanceId;

    // Constructor to demonstrate readonly
    public ConstantsAndLiterals()
    {
        instanceId = new Random().Next(1000, 9999);
    }

    static void Main()
    {
        Console.WriteLine("=== Constants and Literals Demo ===");

        // Using class constants
        Console.WriteLine($"School: {SCHOOL_NAME}");
        Console.WriteLine($"Maximum students: {MAX_STUDENTS}");
        Console.WriteLine($"PI value: {PI}");
        Console.WriteLine($"Program started at: {PROGRAM_START_TIME}");

        // Local constants
        const int DAYS_IN_WEEK = 7;
        const string GREETING = "Welcome";

        Console.WriteLine($"\nLocal constants:");
        Console.WriteLine($"Days in week: {DAYS_IN_WEEK}");
        Console.WriteLine($"Greeting: {GREETING}");

        // Integer literals
        Console.WriteLine("\n=== Integer Literals ===");
        int decimalNumber = 100;          // Decimal literal
        int hexNumber = 0xFF;             // Hexadecimal literal (255)
        int binaryNumber = 0b1010;        // Binary literal (10)
        long longNumber = 1000000L;       // Long literal

        Console.WriteLine($"Decimal: {decimalNumber}");
        Console.WriteLine($"Hexadecimal 0xFF: {hexNumber}");
        Console.WriteLine($"Binary 0b1010: {binaryNumber}");
        Console.WriteLine($"Long: {longNumber}");

        // Floating-point literals
        Console.WriteLine("\n=== Floating-Point Literals ===");
        float floatLiteral = 3.14f;       // Float literal
        double doubleLiteral = 2.71828;   // Double literal (default)
        decimal decimalLiteral = 99.99m;  // Decimal literal

        Console.WriteLine($"Float: {floatLiteral}");
        Console.WriteLine($"Double: {doubleLiteral}");
        Console.WriteLine($"Decimal: {decimalLiteral}");

        // Boolean literals
        Console.WriteLine("\n=== Boolean Literals ===");
        bool isTrue = true;
        bool isFalse = false;

        Console.WriteLine($"True literal: {isTrue}");
        Console.WriteLine($"False literal: {isFalse}");

        // Character literals
        Console.WriteLine("\n=== Character Literals ===");
        char letter = 'A';
        char digit = '5';
        char newline = '\n';
        char tab = '\t';
        char backslash = '\\';
        char singleQuote = '\'';

        Console.WriteLine($"Letter: {letter}");
        Console.WriteLine($"Digit: {digit}");
        Console.Write("Before newline");
        Console.Write(newline);
        Console.WriteLine("After newline");
        Console.WriteLine($"Tab:{tab}Example with tab");
        Console.WriteLine($"Backslash: {backslash}");
        Console.WriteLine($"Single quote: {singleQuote}");

        // String literals
        Console.WriteLine("\n=== String Literals ===");
        string regularString = "Hello, World!";
        string stringWithEscape = "Line 1\nLine 2\tTabbed";
        string verbatimString = @"C:\Users\Username\Documents";
        string interpolatedString = $"Current time: {DateTime.Now}";

        Console.WriteLine($"Regular string: {regularString}");
        Console.WriteLine($"With escape characters:\n{stringWithEscape}");
        Console.WriteLine($"Verbatim string: {verbatimString}");
        Console.WriteLine($"Interpolated string: {interpolatedString}");

        // Null literal
        Console.WriteLine("\n=== Null Literal ===");
        string nullString = null;
        int? nullableInt = null;  // Nullable integer

        Console.WriteLine($"Null string: {nullString ?? "null"}");
        Console.WriteLine($"Nullable int: {nullableInt?.ToString() ?? "null"}");

        // Using constants in calculations
        Console.WriteLine("\n=== Using Constants in Calculations ===");
        double radius = 5.0;
        double area = PI * radius * radius;
        double circumference = 2 * PI * radius;

        Console.WriteLine($"Circle with radius {radius}:");
        Console.WriteLine($"Area: {area:F2}");
        Console.WriteLine($"Circumference: {circumference:F2}");

        // Instance example
        var instance = new ConstantsAndLiterals();
        Console.WriteLine($"\nInstance ID (readonly): {instance.instanceId}");

        // Demonstrating constant vs readonly differences
        Console.WriteLine($"\nConst PI: {PI} (compile-time)");
        Console.WriteLine($"Readonly start time: {PROGRAM_START_TIME} (runtime)");
    }
}