// File: QueueDemo.cs

#region Explanation
/*A Queue<T> is a generic collection that operates on a First-In, First-Out (FIFO) basis. 
 * It’s like a line of people waiting at a ticket counter: the first person in line is served first. 
 * You add items to the end (enqueue) and remove items from the front (dequeue). 
 * It’s ideal for scenarios where order of processing matters, like task scheduling or message processing.
 */
#endregion

using System;
using System.Collections.Generic;

namespace CollectionsDemo
{
    public class QueueDemo
    {
        public static void Run()
        {
            // Initialize a Queue<T> to store tasks (e.g., print jobs in a printer queue)
            Queue<string> printJobs = new Queue<string>();

            // Why: Enqueue adds items to the end of the queue
            printJobs.Enqueue("Document1.pdf");
            printJobs.Enqueue("Photo.jpg");
            printJobs.Enqueue("Report.docx");

            // Why: Peek at the front item without removing it
            Console.WriteLine($"Next job to process: {printJobs.Peek()}");

            // Why: Dequeue removes and returns the front item (FIFO)
            string job = printJobs.Dequeue();
            Console.WriteLine($"Processing job: {job}");

            // Why: Check the number of items in the queue
            Console.WriteLine($"Jobs remaining: {printJobs.Count}");

            // Why: Iterate over the queue (enabled by IEnumerable<T>)
            Console.WriteLine("Remaining jobs in queue:");
            foreach (string remainingJob in printJobs)
            {
                Console.WriteLine(remainingJob);
            }

            // Why: TryDequeue (new in .NET 8) safely checks if dequeue is possible
            if (printJobs.TryDequeue(out string nextJob))
            {
                Console.WriteLine($"Processing next job: {nextJob}");
            }

            // Why: Clear the queue if needed
            printJobs.Clear();
            Console.WriteLine($"Jobs after clearing: {printJobs.Count}");
        }
    }

    class Program
    {
        static void Main()
        {
            QueueDemo.Run();
        }
    }
}