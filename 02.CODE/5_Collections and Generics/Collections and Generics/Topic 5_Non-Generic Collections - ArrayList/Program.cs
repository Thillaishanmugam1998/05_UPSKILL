// File: ArrayListDemo.cs

#region Explanation
/*An ArrayList is a non-generic, dynamic collection that can store items of any type (objects). 
 * It’s like a List<object>, allowing you to add, remove, or access items by index, with automatic resizing. 
 * However, because it’s non-generic, 
 * it requires boxing/unboxing for value types and type casting, making it less safe and slower than List<T>.
 */
#endregion

using System;
using System.Collections;

namespace CollectionsDemo
{
    public class ArrayListDemo
    {
        public static void Run()
        {
            // Initialize an ArrayList to store mixed-type items (e.g., inventory items)
            ArrayList inventory = new ArrayList();

            // Why: Add items of different types (no type safety)
            inventory.Add("Laptop"); // String
            inventory.Add(100);     // Int (boxed)
            inventory.Add(3.99);    // Double (boxed)

            // Why: Access items by index (requires casting)
            string item = (string)inventory[0]; // Cast to string
            Console.WriteLine($"First item: {item}");

            // Why: Insert at a specific index, shifting other elements
            inventory.Insert(1, "Mouse");

            // Why: Remove an item by value
            inventory.Remove(100);

            // Why: Iterate over the ArrayList (enabled by IEnumerable)
            Console.WriteLine("Current inventory:");
            foreach (object obj in inventory)
            {
                // Why: Casting needed for specific types
                if (obj is string str)
                    Console.WriteLine($"String item: {str}");
                else if (obj is double num)
                    Console.WriteLine($"Number item: {num}");
            }

            // Why: Sort the ArrayList (requires IComparable implementation)
            try
            {
                inventory.Sort(); // May throw if types are incompatible
                Console.WriteLine("Sorted inventory:");
                foreach (object obj in inventory)
                {
                    Console.WriteLine(obj);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Sort failed: {ex.Message}");
            }

            // Why: Check count and clear if needed
            Console.WriteLine($"Items in inventory: {inventory.Count}");
            inventory.Clear();
            Console.WriteLine($"Items after clearing: {inventory.Count}");
        }
    }

    class Program
    {
        static void Main()
        {
            ArrayListDemo.Run();
        }
    }
}