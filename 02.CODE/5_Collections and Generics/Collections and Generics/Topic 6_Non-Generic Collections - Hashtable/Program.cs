// File: HashtableDemo.cs

#region Explanation
/* A Hashtable is a non-generic collection that stores key-value pairs, where keys are unique and used for fast lookups. 
 * It’s similar to Dictionary<TKey, TValue> but stores keys and values as object, 
 * requiring boxing for value types and casting for retrieval. 
 * It uses a hash table internally for efficient O(1) average-case operations but is considered legacy due to lack of type safety.
 */
#endregion

using System;
using System.Collections;

namespace CollectionsDemo
{
    public class HashtableDemo
    {
        public static void Run()
        {
            // Initialize a Hashtable to store employee IDs (key) and names (value)
            Hashtable employeeDirectory = new Hashtable();

            // Why: Add key-value pairs; keys and values are objects
            employeeDirectory.Add("E001", "Alice"); // String key, string value
            employeeDirectory.Add("E002", "Bob");
            employeeDirectory.Add(100, 30); // Int key (boxed), int value (boxed)

            // Why: Access value by key (requires casting)
            string name = (string)employeeDirectory["E001"];
            Console.WriteLine($"Employee E001: {name}");

            // Why: Update value for an existing key (no Add needed)
            employeeDirectory["E002"] = "Robert";

            // Why: Check if a key exists to avoid null reference
            if (employeeDirectory.ContainsKey("E003"))
            {
                Console.WriteLine($"Employee E003: {employeeDirectory["E003"]}");
            }
            else
            {
                Console.WriteLine("Employee E003 not found.");
            }

            // Why: Iterate over key-value pairs (enabled by IEnumerable)
            Console.WriteLine("\nEmployee Directory:");
            foreach (DictionaryEntry entry in employeeDirectory)
            {
                // Why: Cast key and value as needed
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

            // Why: Remove a key-value pair
            employeeDirectory.Remove("E001");

            // Why: Check count and clear if needed
            Console.WriteLine($"Employees in directory: {employeeDirectory.Count}");
            employeeDirectory.Clear();
            Console.WriteLine($"Employees after clearing: {employeeDirectory.Count}");
        }
    }

    class Program
    {
        static void Main()
        {
            HashtableDemo.Run();
        }
    }
}