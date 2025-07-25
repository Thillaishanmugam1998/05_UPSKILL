// Using statements - import namespaces for easy access
using System;
using System.Collections.Generic;
using System.Text;
using CompanyApp.Data.Models;        // Custom namespace
using CompanyApp.Business.Services;  // Custom namespace
using CompanyApp.Utilities;          // Custom namespace

// Alias for a namespace - useful for long namespace names
using DataModels = CompanyApp.Data.Models;

// Alias for a specific type - useful when there are naming conflicts
using StringBuilder = System.Text.StringBuilder;

namespace CompanyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Namespaces and Using Statements Demo ===\n");

            // Using classes from different namespaces
            Employee emp = new Employee("John Doe", "Software Developer");
            Customer customer = new Customer("Jane Smith", "jane@email.com");

            EmployeeService empService = new EmployeeService();
            CustomerService custService = new CustomerService();

            empService.ProcessEmployee(emp);
            custService.ProcessCustomer(customer);

            // Using utility classes
            string formatted = StringHelper.FormatName("john doe");
            Console.WriteLine($"Formatted name: {formatted}");

            Logger.LogInfo("Application started successfully");

            // Using alias
            DataModels.Product product = new DataModels.Product("Laptop", 999.99m);
            product.DisplayInfo();

            // Using StringBuilder alias
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Building text with StringBuilder");
            sb.AppendLine("This demonstrates namespace aliases");
            Console.WriteLine(sb.ToString());

            // Demonstrating fully qualified names (without using statements)
            System.DateTime now = System.DateTime.Now;
            Console.WriteLine($"Current time (fully qualified): {now}");
        }
    }
}

// Nested namespaces - Data layer
namespace CompanyApp.Data.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }

        public Employee(string name, string position)
        {
            Name = name;
            Position = position;
            HireDate = DateTime.Now;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Employee: {Name}, Position: {Position}, Hired: {HireDate:yyyy-MM-dd}");
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
            RegistrationDate = DateTime.Now;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Customer: {Name}, Email: {Email}, Registered: {RegistrationDate:yyyy-MM-dd}");
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Product: {Name}, Price: ${Price:F2}");
        }
    }
}

// Business logic layer
namespace CompanyApp.Business.Services
{
    // Note: This class has the same name as one in Data.Models
    // but they're in different namespaces, so no conflict
    public class EmployeeService
    {
        public void ProcessEmployee(CompanyApp.Data.Models.Employee employee)
        {
            Console.WriteLine("Processing employee in business layer...");
            employee.DisplayInfo();

            // Business logic here
            if (IsNewEmployee(employee))
            {
                Console.WriteLine("-> New employee detected, sending welcome email");
            }
        }

        private bool IsNewEmployee(CompanyApp.Data.Models.Employee employee)
        {
            return (DateTime.Now - employee.HireDate).TotalDays < 7;
        }
    }

    public class CustomerService
    {
        public void ProcessCustomer(CompanyApp.Data.Models.Customer customer)
        {
            Console.WriteLine("Processing customer in business layer...");
            customer.DisplayInfo();

            // Business logic here
            if (IsNewCustomer(customer))
            {
                Console.WriteLine("-> New customer detected, sending welcome bonus");
            }
        }

        private bool IsNewCustomer(CompanyApp.Data.Models.Customer customer)
        {
            return (DateTime.Now - customer.RegistrationDate).TotalDays < 30;
        }
    }
}

// Utilities namespace
namespace CompanyApp.Utilities
{
    public static class StringHelper
    {
        public static string FormatName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;

            // Convert to title case
            string[] words = name.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) +
                              (words[i].Length > 1 ? words[i].Substring(1).ToLower() : "");
                }
            }
            return string.Join(" ", words);
        }

        public static string Truncate(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
                return text;

            return text.Substring(0, maxLength) + "...";
        }
    }

    public static class Logger
    {
        public static void LogInfo(string message)
        {
            Console.WriteLine($"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public static void LogError(string message)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public static void LogWarning(string message)
        {
            Console.WriteLine($"[WARNING] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }
    }
}

// Demonstrating global namespace (not recommended for production)
//namespace
//{
//    public class GlobalClass
//    {
//        public static void SayHello()
//        {
//            Console.WriteLine("Hello from global namespace!");
//        }
//    }
//}

// Nested namespace example
namespace CompanyApp.Data.Repositories
{
    public class EmployeeRepository
    {
        public List<CompanyApp.Data.Models.Employee> GetAllEmployees()
        {
            // Simulate database access
            return new List<CompanyApp.Data.Models.Employee>
            {
                new CompanyApp.Data.Models.Employee("Alice Johnson", "Manager"),
                new CompanyApp.Data.Models.Employee("Bob Wilson", "Developer")
            };
        }
    }
}