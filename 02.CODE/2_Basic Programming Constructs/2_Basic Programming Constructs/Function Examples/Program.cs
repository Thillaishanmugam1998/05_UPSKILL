using System;

class MethodsDemo
{
    static void Main()
    {
        Console.WriteLine("=== METHODS AND FUNCTIONS DEMO ===\n");

        // 1. Calling methods without parameters
        PrintWelcomeMessage();
        PrintSeparator();

        // 2. Calling methods with parameters
        GreetUser("Alice");
        GreetUser("Bob");

        // 3. Calling methods with return values
        int sum = AddTwoNumbers(15, 25);
        Console.WriteLine($"Sum: {sum}");

        double average = CalculateAverage(85, 92, 78, 96);
        Console.WriteLine($"Average: {average:F2}");  

        // 4. Using methods for validation
        string email1 = "user@example.com";
        string email2 = "invalid-email";

        Console.WriteLine($"Is '{email1}' valid? {IsValidEmail(email1)}");
        Console.WriteLine($"Is '{email2}' valid? {IsValidEmail(email2)}");

        // 5. Methods working with arrays
        int[] numbers = { 1, 2, 3, 4, 5 };
        DisplayArray(numbers);

        int max = FindMaximum(numbers);
        Console.WriteLine($"Maximum value: {max}");

        // 6. Mathematical operations
        double radius = 5.0;
        double area = CalculateCircleArea(radius);
        Console.WriteLine($"Circle area (radius {radius}): {area:F2}");

        // 7. String operations
        string text = "Hello World";
        int vowelCount = CountVowels(text);
        Console.WriteLine($"Vowels in '{text}': {vowelCount}");

        string reversed = ReverseString(text);
        Console.WriteLine($"Reversed: {reversed}");

        // 8. Complex operations
        bool isPrime17 = IsPrimeNumber(17);
        bool isPrime20 = IsPrimeNumber(20);
        Console.WriteLine($"Is 17 prime? {isPrime17}");
        Console.WriteLine($"Is 20 prime? {isPrime20}");

        int factorial5 = CalculateFactorial(5);
        Console.WriteLine($"Factorial of 5: {factorial5}");
    }

    // 1. Method with no parameters and no return value
    public static void PrintWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Methods Demo!");
    }

    static void PrintSeparator()
    {
        Console.WriteLine("".PadRight(40, '1'));
    }

    // 2. Method with parameters but no return value
    static void GreetUser(string name)
    {
        Console.WriteLine($"Hello, {name}! Nice to meet you.");
    }

    // 3. Methods with parameters and return values
    static int AddTwoNumbers(int a, int b)
    {
        return a + b;
    }

    static double CalculateAverage(params double[] numbers)
    {
        if (numbers.Length == 0) return 0;

        double sum = 0;
        foreach (double num in numbers)
        {
            sum += num;
        }
        return sum / numbers.Length;
    }

    // 4. Boolean returning methods (validation)
    static bool IsValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }

    // 5. Methods working with arrays
    static void DisplayArray(int[] array)
    {
        Console.Write("Array elements: ");
        foreach (int element in array)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }

    static int FindMaximum(int[] array)
    {
        if (array.Length == 0) return 0;

        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

    // 6. Mathematical methods
    static double CalculateCircleArea(double radius)
    {
        return Math.PI * radius * radius;
    }

    // 7. String manipulation methods
    static int CountVowels(string text)
    {
        int count = 0;
        string vowels = "aeiouAEIOU";

        foreach (char c in text)
        {
            if (vowels.Contains(c))
            {
                count++;
            }
        }
        return count;
    }

    static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    // 8. Complex algorithmic methods
    static bool IsPrimeNumber(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i * i <= number; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;

    }

    static int CalculateFactorial(int n)
    {
        if (n <= 1) return 1;
        return n * CalculateFactorial(n - 1); // Recursive approach
    }
}