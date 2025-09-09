// File: ListDemo.cs

using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsDemo
{
    #region 01. String List Demo (Basic + Advanced)
    public class ListStringDemo
    {
        public static void Run()
        {
            Console.WriteLine("===== STRING LIST DEMO =====");

            List<string> employees = new List<string>();
            employees.Add("Alice");
            employees.Add("Bob");
            employees.Add("Charlie");

            Console.WriteLine($"After Add(): {string.Join(", ", employees)}");
            // Output: Alice, Bob, Charlie
            Console.WriteLine($"Count: {employees.Count}, Capacity: {employees.Capacity}\n");
            // Output: Count = 3, Capacity = 4

            employees.Insert(1, "David");
            Console.WriteLine($"After Insert(1, \"David\"): {string.Join(", ", employees)}");
            // Output: Alice, David, Bob, Charlie

            employees.Remove("Bob");
            Console.WriteLine($"After Remove(\"Bob\"): {string.Join(", ", employees)}");
            // Output: Alice, David, Charlie

            employees.AddRange(new List<string> { "Eve", "Frank", "Charlie" });
            Console.WriteLine($"After AddRange(Eve, Frank, Charlie): {string.Join(", ", employees)}");
            // Output: Alice, David, Charlie, Eve, Frank, Charlie

            employees.RemoveAll(e => e.StartsWith("C"));
            Console.WriteLine($"After RemoveAll(StartsWith C): {string.Join(", ", employees)}");
            // Output: Alice, David, Eve, Frank

            Console.WriteLine($"Contains(\"Alice\")? {employees.Contains("Alice")}");  // True
            Console.WriteLine($"Contains(\"Charlie\")? {employees.Contains("Charlie")}\n");  // False

            employees.RemoveAt(0);
            Console.WriteLine($"After RemoveAt(0): {string.Join(", ", employees)}");
            // Output: David, Eve, Frank

            employees.Reverse();
            Console.WriteLine($"After Reverse(): {string.Join(", ", employees)}");
            // Output: Frank, Eve, David

            Console.WriteLine("\nEmployees List (foreach):");
            foreach (string emp in employees) Console.WriteLine(emp);
            // Frank, Eve, David

            string found = employees.Find(e => e.StartsWith("A"));
            Console.WriteLine($"\nFind employee starting with A: {found}");
            // Output: null (no match, prints blank)

            List<string> foundAll = employees.FindAll(e => e.Length > 3);
            Console.WriteLine("Employees with names longer than 3 letters:");
            foreach (var emp in foundAll) Console.WriteLine(emp);
            // Output: Frank, David

            int index = employees.IndexOf("David");
            Console.WriteLine($"Index of David: {index}");
            // Output: 2

            employees.Sort();
            Console.WriteLine("\nSorted employees (asc):");
            employees.ForEach(Console.WriteLine);
            // Output:
            // David
            // Eve
            // Frank

            employees.Sort((x, y) => y.CompareTo(x));
            Console.WriteLine("\nSorted employees (desc):");
            employees.ForEach(Console.WriteLine);
            // Output:
            // Frank
            // Eve
            // David

            string[] empArray = employees.ToArray();
            Console.WriteLine("\nEmployees as Array:");
            foreach (var emp in empArray) Console.WriteLine(emp);
            // Output:
            // Frank
            // Eve
            // David

            var filtered = employees.Where(e => e.Contains("a")).ToList();
            Console.WriteLine("\nEmployees containing 'a':");
            filtered.ForEach(Console.WriteLine);
            // Output:
            // Frank
            // David

            bool hasDavid = employees.Any(e => e == "David");
            Console.WriteLine($"Contains David? {hasDavid}");
            // True

            employees.Clear();
            Console.WriteLine($"\nAfter Clear(): Count={employees.Count}, Capacity={employees.Capacity}");
            // Output: Count=0, Capacity stays at 16 (capacity does not shrink automatically)

            Console.WriteLine("\n[Performance Notes]");
            Console.WriteLine("Add() -> O(1), Insert(index) -> O(n), Remove(value) -> O(n), Sort() -> O(n log n), IndexOf() -> O(n), Clear() -> O(1)");

            Console.WriteLine("============================\n");
        }
    }
    #endregion

    #region 02. Employee List Demo (Real-world Objects)
    public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public decimal Salary { get; set; }

            public override string ToString()
            {
                return $"ID: {Id}, Name: {Name}, Age: {Age}, Salary: {Salary:C}";
            }
        }

        // Custom comparer for Salary (desc) then Name (asc)
        public class EmployeeComparer : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                // Compare Salary descending
                int salaryCompare = y.Salary.CompareTo(x.Salary);
                if (salaryCompare != 0) return salaryCompare;

                // If salary is same, compare by Name ascending
                return x.Name.CompareTo(y.Name);
            }
        }

        public class ListEmployeeDemo
        {
            public static void Run()
            {
                Console.WriteLine("===== EMPLOYEE LIST DEMO =====");

                // Initialize Employee List using Add()
                List<Employee> employees = new List<Employee>();
                employees.Add(new Employee { Id = 1, Name = "Alice", Age = 30, Salary = 50000 });
                employees.Add(new Employee { Id = 2, Name = "Bob", Age = 25, Salary = 40000 });
                employees.Add(new Employee { Id = 3, Name = "Charlie", Age = 28, Salary = 60000 });
                employees.Add(new Employee { Id = 4, Name = "David", Age = 35, Salary = 55000 });

                // Print All Employees
                Console.WriteLine("All Employees:");
                employees.ForEach(Console.WriteLine);

                // Sorting by Name
                employees.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                Console.WriteLine("\nEmployees sorted by Name:");
                employees.ForEach(Console.WriteLine);

                // Sorting by Salary (lambda)
                employees.Sort((e1, e2) => e2.Salary.CompareTo(e1.Salary));
                Console.WriteLine("\nEmployees sorted by Salary (high to low):");
                employees.ForEach(Console.WriteLine);

                // Sorting by Salary desc + Name asc (using IComparer)
                employees.Sort(new EmployeeComparer());
                Console.WriteLine("\nEmployees sorted by Salary (desc), then Name (asc):");
                employees.ForEach(Console.WriteLine);

                // Searching & Filtering
                Employee emp = employees.Find(e => e.Name == "Charlie");
                Console.WriteLine($"\nFound Employee: {emp}");

                var highEarners = employees.Where(e => e.Salary > 45000).ToList();
                Console.WriteLine("\nEmployees with Salary > 45,000:");
                highEarners.ForEach(Console.WriteLine);

                bool hasYoung = employees.Any(e => e.Age < 25);
                Console.WriteLine($"\nAny employee younger than 25? {hasYoung}");

                // Conversion
                Employee[] empArray = employees.ToArray();
                Console.WriteLine("\nEmployees as Array:");
                foreach (var e in empArray) Console.WriteLine(e);

                Console.WriteLine("===============================\n");
            }
        }
        #endregion

    class Program
    {
        static void Main()
        {
            // Run both demos
            ListStringDemo.Run();
            ListEmployeeDemo.Run();
        }
    }
    }
