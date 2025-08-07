// File: DictionaryDemo.cs


#region Explanation
/*
 * A Dictionary<TKey, TValue> is a generic collection that stores key-value pairs, 
 * where each key is unique and used to quickly look up its corresponding value. 
 * Think of it as a phonebook: you look up a name (key) to find a phone number (value). 
 * It’s fast for lookups, additions, and removals, using a hash table internally for efficient access.
 */
#endregion

using System;
using System.Collections.Generic;

namespace CollectionsDemo
{
    public class DictionaryDemo
    {
        public static void Run()
        {
            // Initialize a Dictionary with string keys and int values (e.g., employee ID to age)
            Dictionary<string, int> employeeAges = new Dictionary<string, int>();

            // Why: Add key-value pairs; keys must be unique
            employeeAges.Add("Alice", 30);
            employeeAges.Add("Bob", 25);
            employeeAges.Add("Charlie", 35);

            // Why: Access value by key (fast O(1) average case lookup)
            Console.WriteLine($"Alice's age: {employeeAges["Alice"]}");

            // Why: Update value for an existing key
            employeeAges["Bob"] = 26;

            // Why: Check if a key exists before accessing to avoid KeyNotFoundException
            if (employeeAges.ContainsKey("David"))
            {
                Console.WriteLine($"David's age: {employeeAges["David"]}");
            }
            else
            {
                Console.WriteLine("David not found.");
            }

            // Why: Use TryGetValue for safer access (avoids exceptions)
            if (employeeAges.TryGetValue("Charlie", out int age))
            {
                Console.WriteLine($"Charlie's age: {age}");
            }

            // Why: Remove a key-value pair
            employeeAges.Remove("Alice");

            // Why: Iterate over key-value pairs (enabled by IEnumerable<KeyValuePair<TKey, TValue>>)
            Console.WriteLine("Current employee ages:");
            foreach (KeyValuePair<string, int> pair in employeeAges)
            {
                Console.WriteLine($"Name: {pair.Key}, Age: {pair.Value}");
            }

            // Why: Access keys or values separately
            Console.WriteLine("Employee names:");
            foreach (string name in employeeAges.Keys)
            {
                Console.WriteLine(name);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            DictionaryDemo.Run();
        }
    }
}