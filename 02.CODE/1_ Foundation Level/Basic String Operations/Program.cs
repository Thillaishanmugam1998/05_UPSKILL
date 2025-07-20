using System;

class BasicStringOperations
{
    static void Main()
    {
        Console.WriteLine("=== Basic String Operations ===");

        // String declaration and initialization
        string firstName = "John";
        string lastName = "Doe";
        string email = "  john.doe@email.com  ";
        string sentence = "The quick brown fox jumps over the lazy dog";

        // String concatenation
        string fullName = firstName + " " + lastName;
        string greeting = $"Hello, {fullName}!"; // String interpolation
        

        Console.WriteLine($"First Name: {firstName}");
        Console.WriteLine($"Last Name: {lastName}");
        Console.WriteLine($"Full Name: {fullName}");
        Console.WriteLine($"Greeting: {greeting}");

        // String properties and methods
        Console.WriteLine("\n=== String Properties and Methods ===");
        Console.WriteLine($"Length of full name: {fullName.Length}");
        Console.WriteLine($"Uppercase: {fullName.ToUpper()}");
        Console.WriteLine($"Lowercase: {fullName.ToLower()}");

        // Working with email string
        Console.WriteLine($"\nOriginal email: '{email}'");
        string cleanEmail = email.Trim(); // Remove leading/trailing spaces
        Console.WriteLine($"Trimmed email: '{cleanEmail}'");


        // Substring operations
        var s = cleanEmail.IndexOf('@') + 1;
        string domain = cleanEmail.Substring(cleanEmail.IndexOf('@') + 1);
        string username = cleanEmail.Substring(0, cleanEmail.IndexOf('@'));
        Console.WriteLine($"Username: {username}");
        Console.WriteLine($"Domain: {domain}");

        // String searching and checking
        Console.WriteLine($"\n=== String Searching ===");
        Console.WriteLine($"Email contains 'john': {cleanEmail.Contains("john")}");
        Console.WriteLine($"Email starts with 'john': {cleanEmail.StartsWith("john")}");
        Console.WriteLine($"Email ends with '.com': {cleanEmail.EndsWith(".com")}");

        // String replacement
        string modifiedSentence = sentence.Replace("fox", "cat");
        Console.WriteLine($"\nOriginal: {sentence}");
        Console.WriteLine($"Modified: {modifiedSentence}");

        // String splitting
        string[] words = sentence.Split(' ');
        Console.WriteLine($"\nSentence has {words.Length} words:");
        foreach (string word in words)
        {
            Console.WriteLine($"- {word}");
        }

        // String comparison
        string str1 = "Hello";
        string str2 = "hello";
        Console.WriteLine($"\n=== String Comparison ===");
        Console.WriteLine($"'{str1}' == '{str2}': {str1 == str2}");
        Console.WriteLine($"Case-insensitive comparison: {str1.Equals(str2, StringComparison.OrdinalIgnoreCase)}");
    }
}