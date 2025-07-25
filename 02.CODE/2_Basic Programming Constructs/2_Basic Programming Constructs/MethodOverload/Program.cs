using System;

class MethodOverloadingDemo
{
    static void Main()
    {
        Console.WriteLine("=== METHOD OVERLOADING DEMO ===\n");

        // 1. Basic overloading - different number of parameters
        Console.WriteLine("1. Basic Overloading (different parameter counts):");

        // Calling different versions of CalculateArea
        Console.WriteLine($"Square area (side 5): {CalculateArea(5)}");
        Console.WriteLine($"Rectangle area (5x8): {CalculateArea(5, 8)}");
        Console.WriteLine($"Triangle area (base 6, height 4): {CalculateArea(6, 4, "triangle")}");
        Console.WriteLine();

        // 2. Overloading with different parameter types
        Console.WriteLine("2. Overloading with different parameter types:");

        DisplayValue(42);                    // int version
        DisplayValue(3.14159);              // double version
        DisplayValue("Hello World");        // string version
        DisplayValue(true);                 // bool version
        DisplayValue('A');                  // char version
        Console.WriteLine();

        // 3. Mathematical operations overloading
        Console.WriteLine("3. Mathematical operations overloading:");

        // Add method with different parameter types
        Console.WriteLine($"Add integers (5 + 3): {Add(5, 3)}");
        Console.WriteLine($"Add doubles (2.5 + 3.7): {Add(2.5, 3.7):F2}");
        Console.WriteLine($"Add three integers (1 + 2 + 3): {Add(1, 2, 3)}");
        Console.WriteLine($"Add strings ('Hello' + 'World'): {Add("Hello", "World")}");
        Console.WriteLine();

        // 4. Print methods with different formatting
        Console.WriteLine("4. Print methods with different formatting:");

        Print("Simple message");
        Print("Formatted message", true);
        Print("Centered message", 50, true);
        Print("Custom message", ConsoleColor.Green, true);
        Console.WriteLine();

        // 5. Search methods in different data structures
        Console.WriteLine("5. Search methods with different data types:");

        // Array search
        int[] intArray = { 1, 3, 5, 7, 9, 11 };
        Console.WriteLine($"Search 7 in int array: Index {Search(intArray, 7)}");

        // String array search
        string[] stringArray = { "apple", "banana", "cherry", "date" };
        Console.WriteLine($"Search 'banana' in string array: Index {Search(stringArray, "banana")}");

        // String search
        string text = "This is a sample text for searching";
        Console.WriteLine($"Search 'sample' in text: Index {Search(text, "sample")}");
        Console.WriteLine();

        // 6. Convert methods with different return types
        Console.WriteLine("6. Convert methods with different return types:");

        Console.WriteLine($"Convert '123' to int: {Convert("123")}");
        Console.WriteLine($"Convert '45.67' to double: {Convert("45.67")}");
        Console.WriteLine($"Convert 'true' to bool: {Convert("true")}");
        Console.WriteLine();

        // 7. Process methods with optional parameters simulation
        Console.WriteLine("7. Process methods demonstrating parameter variations:");

        Process("Data");
        Process("Data", "INFO");
        Process("Data", "ERROR", true);

        Console.WriteLine("\n=== END OF DEMO ===");
    }

    // 1. CALCULATE AREA METHODS (Different parameter counts)

    // Square area (1 parameter)
    static double CalculateArea(double side)
    {
        return side * side;
    }

    // Rectangle area (2 parameters)
    static double CalculateArea(double length, double width)
    {
        return length * width;
    }

    // Triangle area (3 parameters with shape identifier)
    static double CalculateArea(double baseLength, double height, string shape)
    {
        if (shape.ToLower() == "triangle")
            return 0.5 * baseLength * height;
        return 0;
    }

    // Circle area (1 parameter with shape identifier)
    static double CalculateArea(double radius, string shape)
    {
        if (shape.ToLower() == "circle")
            return Math.PI * radius * radius;
        return 0;
    }

    // 2. DISPLAY VALUE METHODS (Different parameter types)

    static void DisplayValue(int value)
    {
        Console.WriteLine($"Integer value: {value}");
    }

    static void DisplayValue(double value)
    {
        Console.WriteLine($"Double value: {value:F4}");
    }

    static void DisplayValue(string value)
    {
        Console.WriteLine($"String value: '{value}'");
    }

    static void DisplayValue(bool value)
    {
        Console.WriteLine($"Boolean value: {value}");
    }

    static void DisplayValue(char value)
    {
        Console.WriteLine($"Character value: '{value}'");
    }

    // 3. ADD METHODS (Mathematical operations with different types)

    static int Add(int a, int b)
    {
        return a + b;
    }

    static double Add(double a, double b)
    {
        return a + b;
    }

    static int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    static string Add(string a, string b)
    {
        return a + " " + b;
    }

    static double Add(int a, double b)  // Mixed types
    {
        return a + b;
    }

    // 4. PRINT METHODS (Different formatting options)

    static void Print(string message)
    {
        Console.WriteLine(message);
    }

    static void Print(string message, bool addTimestamp)
    {
        if (addTimestamp)
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        else
            Console.WriteLine(message);
    }

    static void Print(string message, int width, bool center)
    {
        if (center && message.Length < width)
        {
            int padding = (width - message.Length) / 2;
            message = message.PadLeft(message.Length + padding).PadRight(width);
        }
        Console.WriteLine(message);
    }

    static void Print(string message, ConsoleColor color, bool resetColor)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        if (resetColor)
            Console.ResetColor();
    }

    // 5. SEARCH METHODS (Different data structures)

    static int Search(int[] array, int target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
                return i;
        }
        return -1;
    }

    static int Search(string[] array, string target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Equals(target, StringComparison.OrdinalIgnoreCase))
                return i;
        }
        return -1;
    }

    static int Search(string text, string substring)
    {
        return text.IndexOf(substring, StringComparison.OrdinalIgnoreCase);
    }

    static bool Search(int[] array, int target, out int index)  // With out parameter
    {
        index = Search(array, target);
        return index != -1;
    }

    // 6. CONVERT METHODS (Different return types)

    static int Convert(string value)
    {
        if (int.TryParse(value, out int result))
            return result;
        return 0;
    }

    static double Convert(string value, string type)
    {
        if (type.ToLower() == "double" && double.TryParse(value, out double result))
            return result;
        return 0.0;
    }

    static bool Convert(string value, bool defaultValue)
    {
        if (bool.TryParse(value, out bool result))
            return result;
        return defaultValue;
    }

    // 7. PROCESS METHODS (Simulating optional parameters with overloading)

    static void Process(string data)
    {
        Process(data, "INFO", false);
    }

    static void Process(string data, string logLevel)
    {
        Process(data, logLevel, false);
    }

    static void Process(string data, string logLevel, bool verbose)
    {
        Console.WriteLine($"[{logLevel}] Processing: {data}" + (verbose ? " (verbose mode)" : ""));
    }
}