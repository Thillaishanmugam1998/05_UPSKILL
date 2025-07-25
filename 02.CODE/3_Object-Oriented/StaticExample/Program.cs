using System;

namespace StaticMembersDemo
{
    // Static class - cannot be instantiated, can only contain static members
    public static class MathUtilities
    {
        // Static field - shared across the entire application
        public static readonly double Pi = 3.14159265359;

        // Static method - can be called without creating an instance
        public static double CalculateCircleArea(double radius)
        {
            return Pi * radius * radius;
        }

        public static double CalculateCircumference(double radius)
        {
            return 2 * Pi * radius;
        }

        public static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }

    // Regular class with both static and instance members
    public class Counter
    {
        // Static field - shared by all instances
        private static int totalCounters = 0;

        // Static property
        public static int TotalCounters
        {
            get { return totalCounters; }
        }

        // Instance field - unique to each instance
        private int value;
        private string name;

        // Static constructor - called once when the type is first used
        static Counter()
        {
            Console.WriteLine("Static constructor called - initializing Counter class");
            totalCounters = 0;
        }

        // Instance constructor
        public Counter(string name)
        {
            this.name = name;
            this.value = 0;
            totalCounters++; // Increment shared counter
            Console.WriteLine($"Created counter '{name}'. Total counters: {totalCounters}");
        }

        // Instance method
        public void Increment()
        {
            value++;
            Console.WriteLine($"Counter '{name}' incremented to {value}");
        }

        // Instance property
        public int Value
        {
            get { return value; }
        }

        // Static method - can only access static members
        public static void DisplayTotalCounters()
        {
            Console.WriteLine($"Total counters created: {totalCounters}");

            // Cannot access instance members from static context
            // Console.WriteLine(value); // This would cause a compilation error
            // Console.WriteLine(name);  // This would cause a compilation error
        }

        // Instance method can access both static and instance members
        public void DisplayInfo()
        {
            Console.WriteLine($"Counter '{name}': Value = {value}, Total Counters = {totalCounters}");
        }
    }

    // Another example with static initialization
    public class Configuration
    {
        // Static fields with initialization
        public static readonly string ApplicationName = "Demo App";
        public static readonly string Version = "1.0.0";

        // Static field initialized at runtime
        public static readonly DateTime StartupTime = DateTime.Now;

        private static string connectionString;

        // Static property with logic
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = BuildConnectionString();
                }
                return connectionString;
            }
        }

        private static string BuildConnectionString()
        {
            // Simulate building connection string
            return "Server=localhost;Database=DemoDb;Integrated Security=true";
        }

        public static void DisplayInfo()
        {
            Console.WriteLine($"Application: {ApplicationName} v{Version}");
            Console.WriteLine($"Started at: {StartupTime}");
            Console.WriteLine($"Connection: {ConnectionString}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Static Members and Classes Demo ===\n");

            // Using static class - no instantiation needed
            Console.WriteLine("=== Math Utilities (Static Class) ===");
            double radius = 5.0;
            double area = MathUtilities.CalculateCircleArea(radius);
            double circumference = MathUtilities.CalculateCircumference(radius);

            Console.WriteLine($"Circle with radius {radius}:");
            Console.WriteLine($"Area: {area:F2}");
            Console.WriteLine($"Circumference: {circumference:F2}");
            Console.WriteLine($"Pi value: {MathUtilities.Pi}");
            Console.WriteLine($"Is 17 prime? {MathUtilities.IsPrime(17)}");

            Console.WriteLine("\n=== Counter Class (Mixed Static/Instance) ===");

            // Display static information before creating instances
            Counter.DisplayTotalCounters();

            // Create instances
            Counter counter1 = new Counter("Counter1");
            Counter counter2 = new Counter("Counter2");
            Counter counter3 = new Counter("Counter3");

            // Use instance methods
            counter1.Increment();
            counter1.Increment();
            counter2.Increment();

            // Display instance information
            counter1.DisplayInfo();
            counter2.DisplayInfo();
            counter3.DisplayInfo();

            // Access static property
            Console.WriteLine($"Total counters created: {Counter.TotalCounters}");

            Console.WriteLine("\n=== Configuration (Static Members) ===");
            Configuration.DisplayInfo();
        }
    }
}