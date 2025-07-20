using System;


/// <summary>
/// This class demonstrates different types of comments and documentation
/// in C# programming.
/// </summary>
class CommentsAndDocumentation
{
    /// <summary>
    /// Main method - entry point of the program
    /// </summary>
    /// <param name="args">Command line arguments</param>
    static void Main(string[] args)
    {
        // This is a single-line comment
        // It explains what the next line does
        Console.WriteLine("=== Comments and Documentation Demo ===");

        /*
         * This is a multi-line comment
         * It can span multiple lines
         * Useful for longer explanations
         */

        // Variable declarations with explanatory comments
        int studentCount = 25;    // Number of students in class
        double averageGrade = 87.5; // Class average grade

        /* 
         * Calculate and display student statistics
         * This section performs basic calculations
         */
        double totalPoints = studentCount * averageGrade;

        // Display results with descriptive comments
        Console.WriteLine($"Students: {studentCount}"); // Show student count
        Console.WriteLine($"Average: {averageGrade}");  // Show average grade
        Console.WriteLine($"Total Points: {totalPoints}"); // Show total points

        // TODO: Add more statistical calculations
        // FIXME: Handle division by zero in future calculations
        // NOTE: Consider adding input validation

        DisplayWelcomeMessage(); // Call helper method
    }

    /// <summary>
    /// Displays a welcome message to the user
    /// </summary>
    /// <remarks>
    /// This method demonstrates XML documentation comments
    /// which can be used to generate API documentation
    /// </remarks>
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("\nWelcome to C# Programming!");
        Console.WriteLine("Comments make code more readable and maintainable.");
    }
}