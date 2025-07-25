using System;

class MethodParametersDemo
{
    static void Main()
    {
        Console.WriteLine("=== METHOD PARAMETERS DEMO ===\n");

        // 1. Value Parameters (default behavior)
        Console.WriteLine("1. Value Parameters:");
        int originalNumber = 100;
        Console.WriteLine($"Before calling ModifyValue: {originalNumber}");
        ModifyValue(originalNumber);
        Console.WriteLine($"After calling ModifyValue: {originalNumber}");
        Console.WriteLine("Value parameters don't change the original variable\n");

        // 2. Reference Parameters (ref keyword)
        Console.WriteLine("2. Reference Parameters:");
        int refNumber = 100;
        Console.WriteLine($"Before calling ModifyByReference: {refNumber}");
        ModifyByReference(ref refNumber);
        Console.WriteLine($"After calling ModifyByReference: {refNumber}");
        Console.WriteLine("Reference parameters DO change the original variable\n");

        // 3. Output Parameters (out keyword)
        Console.WriteLine("3. Output Parameters:");

        // Example 1: Mathematical operations returning multiple results
        int dividend = 17, divisor = 5;
        int quotient, remainder;
        DivideNumbers(dividend, divisor, out quotient, out remainder);
        Console.WriteLine($"{dividend} ÷ {divisor} = {quotient} remainder {remainder}");

        // Example 2: Parsing with validation
        string numberString = "123";
        int parsedNumber;


        bool isValid = TryParseInteger(numberString, out parsedNumber);
        Console.WriteLine($"Parsing '{numberString}': Valid = {isValid}, Value = {parsedNumber}");

        string invalidString = "abc";
        bool isValid2 = TryParseInteger(invalidString, out parsedNumber);
        Console.WriteLine($"Parsing '{invalidString}': Valid = {isValid2}, Value = {parsedNumber}");

        // Example 3: Getting circle measurements
        double radius = 3.0;
        double area, circumference;
        CalculateCircleProperties(radius, out area, out circumference);
        Console.WriteLine($"Circle (radius {radius}): Area = {area:F2}, Circumference = {circumference:F2}\n");

        // 4. Parameter Arrays (params keyword)
        Console.WriteLine("4. Parameter Arrays (params):");

        // Can call with different numbers of arguments
        int sum1 = SumNumbers(1, 2, 3);
        Console.WriteLine($"Sum of 1, 2, 3 = {sum1}");

        int sum2 = SumNumbers(10, 20, 30, 40, 50);
        Console.WriteLine($"Sum of 10, 20, 30, 40, 50 = {sum2}");

        int sum3 = SumNumbers(); // No arguments
        Console.WriteLine($"Sum of no numbers = {sum3}");

        // Can also pass an array
        int[] numberArray = { 100, 200, 300 };
        int sum4 = SumNumbers(numberArray);
        Console.WriteLine($"Sum of array elements = {sum4}");

        // Example with different data types
        DisplayInfo("Student Records:", "John Doe", "Jane Smith", "Bob Johnson");
        Console.WriteLine();

        // 5. Combining different parameter types
        Console.WriteLine("5. Combining different parameter types:");

        string operation = "multiply";
        double num1 = 12.5, num2 = 4.0;
        double result;
        bool success;

        success = PerformCalculation(operation, num1, num2, out result);
        Console.WriteLine($"Operation: {operation}, Numbers: {num1}, {num2}");
        Console.WriteLine($"Success: {success}, Result: {result}");

        // 6. Advanced example: Statistical analysis
        Console.WriteLine("\n6. Statistical Analysis Example:");
        double[] data = { 85.5, 92.0, 78.5, 96.0, 88.5, 91.0, 87.5 };

        double mean, median, standardDeviation;
        AnalyzeData(data, out mean, out median, out standardDeviation);

        Console.WriteLine($"Data Analysis Results:");
        Console.WriteLine($"Mean: {mean:F2}");
        Console.WriteLine($"Median: {median:F2}");
        Console.WriteLine($"Standard Deviation: {standardDeviation:F2}");
    }

    // 1. Value parameter methods
    static void ModifyValue(int value)
    {
        value = 999; // This change won't affect the original variable
        Console.WriteLine($"Inside ModifyValue: {value}");
    }

    // 2. Reference parameter methods
    static void ModifyByReference(ref int value)
    {
        value = 999; // This change WILL affect the original variable
        Console.WriteLine($"Inside ModifyByReference: {value}");
    }

    // 3. Output parameter methods
    static void DivideNumbers(int dividend, int divisor, out int quotient, out int remainder)
    {
        quotient = dividend / divisor;
        remainder = dividend % divisor;
    }

    static bool TryParseInteger(string input, out int result)
    {
        return int.TryParse(input, out result);
    }

    static void CalculateCircleProperties(double radius, out double area, out double circumference)
    {
        area = Math.PI * radius * radius;
        circumference = 2 * Math.PI * radius;

    }

    // 4. Parameter array methods
    static int SumNumbers(params int[] numbers)
    {
        int sum = 0;
        Console.Write("Summing: ");
        foreach (int number in numbers)
        {
            Console.Write($"{number} ");
            sum += number;
        }
        Console.WriteLine();
        return sum;
    }

    static void DisplayInfo(string title, params string[] items)
    {
        Console.WriteLine(title);
        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine($"  {i + 1}. {items[i]}");
        }
    }

    // 5. Combined parameter types
    static bool PerformCalculation(string operation, double a, double b, out double result)
    {
        result = 0;

        switch (operation.ToLower())
        {
            case "add":
                result = a + b;
                return true;
            case "subtract":
                result = a - b;
                return true;
            case "multiply":
                result = a * b;
                return true;
            case "divide":
                if (b != 0)
                {
                    result = a / b;
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    // 6. Advanced statistical analysis method
    static void AnalyzeData(double[] data, out double mean, out double median, out double standardDeviation)
    {
        // Calculate mean
        double sum = 0;
        foreach (double value in data)
        {
            sum += value;
        }
        mean = sum / data.Length;

        // Calculate median
        double[] sortedData = new double[data.Length];
        Array.Copy(data, sortedData, data.Length);
        Array.Sort(sortedData);

        int midpoint = sortedData.Length / 2;
        if (sortedData.Length % 2 == 0)
        {
            median = (sortedData[midpoint - 1] + sortedData[midpoint]) / 2;
        }
        else
        {
            median = sortedData[midpoint];
        }

        // Calculate standard deviation
        double sumOfSquaredDifferences = 0;
        foreach (double value in data)
        {
            sumOfSquaredDifferences += Math.Pow(value - mean, 2);
        }
        standardDeviation = Math.Sqrt(sumOfSquaredDifferences / data.Length);
    }
}