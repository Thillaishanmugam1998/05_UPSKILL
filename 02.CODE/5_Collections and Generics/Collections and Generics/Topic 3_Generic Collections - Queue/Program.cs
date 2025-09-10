// File: QueueDemo.cs

#region Explanation
/* A Queue<T> is a generic collection that operates on a First-In, First-Out (FIFO) basis.
 * It’s like people waiting in a line: the first person who joins is served first.
 * - Enqueue → Adds item to the back
 * - Dequeue → Removes item from the front
 * - Peek    → Looks at the front item without removing
 * 
 * Real-world usage:
 * ✅ Printer queue (documents waiting to be printed)
 * ✅ Task scheduling
 * ✅ Order processing in e-commerce
 * ✅ Customer service systems
 */
#endregion

using System;
using System.Collections.Generic;

namespace CollectionsDemo
{
    // Real-world object to store in Queue<T>
    public class PrintJob
    {
        public int JobId { get; set; }
        public string FileName { get; set; }

        public override string ToString()
        {
            return $"[JobId={JobId}, File={FileName}]";
        }
    }

    public class QueueDemo
    {
        public static void Run()
        {
            // Initialize a Queue<T> for print jobs
            Queue<PrintJob> printJobs = new Queue<PrintJob>();

            // Why: Enqueue adds jobs to the queue (FIFO order)
            printJobs.Enqueue(new PrintJob { JobId = 1, FileName = "Report.pdf" });
            printJobs.Enqueue(new PrintJob { JobId = 2, FileName = "Invoice.docx" });
            printJobs.Enqueue(new PrintJob { JobId = 3, FileName = "Photo.jpg" });

            // Why: Peek to check which job will be processed first
           
            /* Here when you create custom class object collections 
            * to override the tostring method to see the acutal data
            * if you are not using override tostring then you print the data
            * result will be like (Next job: CollectionsDemo.PrintJob)
            * Console.WriteLine($"Next job: {printJobs.Peek()}"); */

            // Why: Dequeue removes and returns the job at the front
            PrintJob job = printJobs.Dequeue();
            Console.WriteLine($"Processing: {job}");

            // Why: Queue.Count tells how many jobs remain
            Console.WriteLine($"Jobs remaining: {printJobs.Count}");

            // Why: Iterate over queue using foreach (IEnumerable<T> support)
            Console.WriteLine("Jobs in queue:");
            foreach (PrintJob remainingJob in printJobs)
            {
                Console.WriteLine(remainingJob);
            }

            // Why: Safe removal using TryDequeue (no exception if empty, introduced in .NET 8)
            if (printJobs.TryDequeue(out PrintJob nextJob))
            {
                Console.WriteLine($"Processing next job: {nextJob}");
            }

            // Why: Handle empty queue safely
            if (printJobs.TryDequeue(out PrintJob anotherJob))
            {
                Console.WriteLine($"Processing: {anotherJob}");
            }
            else
            {
                Console.WriteLine("No jobs left to process.");
            }

            // Why: Clear removes all jobs
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
