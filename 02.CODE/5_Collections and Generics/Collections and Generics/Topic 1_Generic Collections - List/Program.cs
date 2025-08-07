// File: ListDemo.cs

#region Explanation
/*
A List<T> is a dynamic, resizable collection of items of type T (e.g., List<int> for integers, List<string> for strings). 
It’s like an array but can grow or shrink as needed. 
You can add, remove, or access items by index, and it supports common operations like sorting or searching.
 */
#endregion

using System;
using System.Collections.Generic;

namespace CollectionsDemo
{
    public class ListDemo
    {
        public static void Run()
        {
            // Initialize a List<T> to store strings (e.g., a list of employee names)
            List<string> employees = new List<string>();

            // Why: Add items dynamically without worrying about fixed size
            employees.Add("Alice");
            employees.Add("Bob");
            employees.Add("Charlie");

            // Why: Access elements by index (zero-based)
            Console.WriteLine($"First employee: {employees[0]}");

            // Why: Insert at a specific index, shifting other elements
            employees.Insert(1, "David");

            // Why: Remove an item by value
            employees.Remove("Bob");

            // Why: Iterate over the list using foreach (enabled by IEnumerable<T>)
            Console.WriteLine("Current employees:");
            foreach (string employee in employees)
            {
                Console.WriteLine(employee);
            }

            // Why: Sort the list (requires IComparable implementation for custom types)
            employees.Sort();
            Console.WriteLine("Sorted employees:");
            foreach (string employee in employees)
            {
                Console.WriteLine(employee);
            }

            // Why: Check if an item exists
            bool hasCharlie = employees.Contains("Charlie");
            Console.WriteLine($"Contains Charlie? {hasCharlie}");
        }
    }

    class Program
    {
        static void Main()
        {
            ListDemo.Run();
        }
    }
}