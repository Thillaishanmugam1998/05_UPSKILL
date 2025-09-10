// File: DictionaryDemo.cs

#region Explanation
/*
 * Dictionary<TKey, TValue>
 * ------------------------
 * A Dictionary is a generic collection that stores key-value pairs with unique keys. 
 * Internally, it uses a hash table for O(1) average lookup, insertion, and removal.
 * 
 * ✅ Covers for 3-year experience:
 * 1. Basic operations (add, update, remove, lookup).
 * 2. Initialization shortcuts.
 * 3. TryAdd and safe duplicate handling.
 * 4. Iterating with KeyValuePair and deconstruction.
 * 5. Custom class as key (requires Equals & GetHashCode override).
 * 6. Performance considerations (hashing & collisions).
 * 7. Thread-safe alternative: ConcurrentDictionary.
 * 8. Real-world usage examples (frequency counter, caching).
 * 9. Extra: Add, Remove, ContainsValue, Count
 */
#endregion

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace CollectionsDemo
{
    // Custom key type example (important for interviews)
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Override Equals and GetHashCode to avoid dictionary key issues
        public override bool Equals(object obj) =>
            obj is Employee e && Id == e.Id;

        public override int GetHashCode() => Id.GetHashCode();
    }

    public class DictionaryDemo
    {
        public static void Run()
        {
            #region 1. Initialization Shortcuts
            //var employeeAges = new Dictionary<stirng,int>();

            Dictionary<string, int> employeeAges = new Dictionary<string, int>
            {
                ["Alice"] = 30,
                ["Bob"] = 25,
                ["Charlie"] = 35
            };
            #endregion

            #region 2. Basic Lookup and Update
            Console.WriteLine($"Alice's age: {employeeAges["Alice"]}");
            employeeAges["Bob"] = 26; // Update value
            #endregion

            #region 3. Safe Access: ContainsKey, TryGetValue, TryAdd
            if (employeeAges.ContainsKey("David"))
                Console.WriteLine(employeeAges["David"]);
            else
                Console.WriteLine("David not found.");

            if (employeeAges.TryGetValue("Charlie", out int age))
                Console.WriteLine($"Charlie's age: {age}");

            if (!employeeAges.TryAdd("Alice", 31))
                Console.WriteLine("Key 'Alice' already exists.");
            #endregion

            #region 3.1 Add, Remove, ContainsValue, Count
            // Add new element explicitly
            employeeAges.Add("David", 29);

            // Check if a value exists
            Console.WriteLine(employeeAges.ContainsValue(26)
                ? "An employee aged 26 exists."
                : "No employee aged 26 found.");

            // Remove element
            if (employeeAges.Remove("Charlie"))
                Console.WriteLine("Charlie removed successfully.");

            // Dictionary count
            Console.WriteLine($"Total employees in dictionary: {employeeAges.Count}");
            #endregion

            #region 4. Iteration Examples
            Console.WriteLine("\n-- Employee Ages (KeyValuePair) --");
            foreach (KeyValuePair<string, int> pair in employeeAges)
                Console.WriteLine($"Name: {pair.Key}, Age: {pair.Value}");

            Console.WriteLine("\n-- Employee Ages (Deconstruction) --");
            foreach (var (name, empAge) in employeeAges)
                Console.WriteLine($"{name} => {empAge}");
            #endregion

            #region 5. Custom Object as Dictionary Key
            var deptAssignments = new Dictionary<Employee, string>
            {
                [new Employee { Id = 101, Name = "Alice" }] = "HR",
                [new Employee { Id = 102, Name = "Bob" }] = "Finance"
            };

            #region Initialization Ways
            var _dept = new Dictionary<Employee, string>();
            Employee emp1 = new Employee();
            emp1.Id = 100;
            emp1.Name = "Thillai";
            _dept.Add(emp1, "DEVOPS");
            _dept.Add(new Employee { Id = 200, Name = "Tamil" }, "CLIENT");
            _dept[new Employee { Id = 1, Name = "Abi" }] = "Nursing";

            int dict_count =_dept.Count;
            _dept.Clear();
            dict_count = _dept.Count;
            #endregion


            Console.WriteLine("\n-- Employee Department Assignments --");
            foreach (var (emp, dept) in deptAssignments)
                Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Dept: {dept}");
            #endregion

            #region 6. Get values from custom object 
            // Create a new Employee object with same Id = 101
            Employee searchKey = new Employee { Id = 101, Name = "Alice" };

            if (deptAssignments.TryGetValue(searchKey, out string department))
            {
                Console.WriteLine($"Employee 101 works in: {department}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }

            #endregion

            #region 6. Real-World Example: Frequency Counter
            string text = "apple banana apple orange banana apple";
            var wordCount = new Dictionary<string, int>();
            foreach (var word in text.Split(' '))
            {
                if (wordCount.ContainsKey(word))
                    wordCount[word]++;
                else
                    wordCount[word] = 1;
            }

            Console.WriteLine("\n-- Word Frequency Counter --");
            foreach (var (word, count) in wordCount)
                Console.WriteLine($"{word}: {count}");
            #endregion

            #region 7. Thread-Safe Dictionary (ConcurrentDictionary)
            var stockPrices = new ConcurrentDictionary<string, decimal>();
            stockPrices.TryAdd("AAPL", 150.75m);
            stockPrices.TryAdd("MSFT", 310.50m);

            stockPrices.AddOrUpdate("AAPL", 155.00m, (key, oldValue) => oldValue + 5);

            Console.WriteLine("\n-- Concurrent Dictionary Example --");
            foreach (var (symbol, price) in stockPrices)
                Console.WriteLine($"{symbol}: {price}");
            #endregion

            #region 8. Performance Note
            /*
             * ⚡ Average case: O(1) for add, lookup, remove.
             * ❌ Worst case: O(n) if too many hash collisions.
             * ✔ Always use immutable keys and override GetHashCode for custom objects.
             */
            #endregion
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
