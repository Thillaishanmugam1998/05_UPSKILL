// File: IEnumerableDemo.cs

#region Explanation
/*IEnumerable is an interface in .NET that enables iteration over a collection of objects. 
 * It defines a single method, GetEnumerator(), which returns an IEnumerator to allow looping through items (e.g., using foreach).
 * It’s the foundation for all collections that support iteration, like List<T>, 
 * Dictionary<TKey, TValue>, and arrays. Think of it as a contract that says, “This collection can be iterated.”
 */
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsDemo
{
    // Custom class implementing IEnumerable<T> to store a collection of tasks
    public class TaskList : IEnumerable<string>
    {
        private List<string> tasks = new List<string>();

        // Why: Add method to populate the internal list
        public void AddTask(string task)
        {
            tasks.Add(task);
        }

        // Why: Implement IEnumerable<T>.GetEnumerator for foreach iteration
        public IEnumerator<string> GetEnumerator()
        {
            return tasks.GetEnumerator();
        }

        // Why: Implement non-generic IEnumerable for backward compatibility
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); // Reuse generic enumerator
        }
    }

    public class IEnumerableDemo
    {
        public static void Run()
        {
            // Initialize custom TaskList
            TaskList taskList = new TaskList();

            // Why: Add tasks to demonstrate iteration
            taskList.AddTask("Write report");
            taskList.AddTask("Send email");
            taskList.AddTask("Attend meeting");

            // Why: Use foreach to iterate (enabled by IEnumerable<T>)
            Console.WriteLine("Tasks in TaskList:");
            foreach (string task in taskList)
            {
                Console.WriteLine(task);
            }

            // Why: Demonstrate IEnumerable with a standard collection
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine("\nNumbers in List<int>:");
            foreach (int number in numbers) // IEnumerable<int> enables this
            {
                Console.WriteLine(number);
            }

            // Why: Use LINQ (enabled by IEnumerable<T>) for filtering
            IEnumerable<int> evenNumbers = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("\nEven numbers using LINQ:");
            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            IEnumerableDemo.Run();
        }
    }
}