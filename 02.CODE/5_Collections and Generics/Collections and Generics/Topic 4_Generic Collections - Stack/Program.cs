using System;
using System.Collections.Generic;

namespace Topic_4_Generic_Collections___Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            // Real-world analogy: Browser Back Button (LIFO - Last In, First Out)
            Stack<string> browserHistory = new Stack<string>();

            // Pushing pages into stack
            browserHistory.Push("Google");
            browserHistory.Push("YouTube");
            browserHistory.Push("StackOverflow");

            Console.WriteLine("Current Browser History (Top to Bottom):");
            foreach (var page in browserHistory)
            {
                Console.WriteLine(page);
            }

            // Peek → check the last visited page
            Console.WriteLine($"\nLast visited page: {browserHistory.Peek()}");

            // Pop → Go back (remove top)
            Console.WriteLine($"Going back from: {browserHistory.Pop()}");

            // Check remaining history
            Console.WriteLine("\nRemaining Browser History:");
            foreach (var page in browserHistory)
            {
                Console.WriteLine(page);
            }

            // Contains check
            Console.WriteLine($"\nIs YouTube still in history? {browserHistory.Contains("YouTube")}");

            // Edge case → popping until empty
            browserHistory.Pop();
            browserHistory.Pop();
            Console.WriteLine($"\nHistory Empty? Count = {browserHistory.Count}");

            try
            {
                // This will throw InvalidOperationException
                browserHistory.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}
