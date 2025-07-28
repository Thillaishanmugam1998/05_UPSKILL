using System;
using System.Collections.Generic;

// TOPIC 3: ABSTRACT CLASSES AND ABSTRACT METHODS
// Real-world analogy: Think of a blueprint or template
// You can't build "a vehicle" - you build specific types like cars, trucks, etc.
// Abstract classes are like blueprints that define what MUST be implemented

// ABSTRACT BASE CLASS
// The 'abstract' keyword means:
// 1. You CANNOT create instances of this class directly
// 2. It can contain abstract methods that MUST be implemented by derived classes
// 3. It can also contain regular methods and properties (concrete implementation)
public abstract class Employee
{
    // Regular properties - all employees have these
    protected string name;
    protected int employeeId;
    protected decimal baseSalary;

    // Public properties for accessing private fields
    public string Name { get { return name; } }
    public int EmployeeId { get { return employeeId; } }
    public decimal BaseSalary { get { return baseSalary; } }

    // Constructor for abstract class
    // Even though we can't instantiate Employee directly,
    // derived classes will call this constructor
    public Employee(string name, int id, decimal baseSalary)
    {
        this.name = name;
        this.employeeId = id;
        this.baseSalary = baseSalary;
        Console.WriteLine($"Employee base constructor called for {name}");
    }

    // ABSTRACT METHOD - No implementation provided
    // Every derived class MUST implement this method
    // Abstract methods are implicitly virtual
    public abstract decimal CalculatePayroll();

    // Another abstract method - must be implemented
    public abstract string GetJobDescription();

    // CONCRETE METHOD - Has implementation, can be used as-is or overridden
    public virtual void DisplayBasicInfo()
    {
        Console.WriteLine($"Employee: {name} (ID: {employeeId})");
        Console.WriteLine($"Base Salary: ${baseSalary:C}");
    }

    // CONCRETE METHOD - Provides common functionality
    // This method uses the abstract method (Template Method Pattern)
    public void ProcessPayroll()
    {
        Console.WriteLine($"\n--- Processing Payroll for {name} ---");
        DisplayBasicInfo();
        Console.WriteLine($"Job: {GetJobDescription()}"); // Calls abstract method
        decimal totalPay = CalculatePayroll(); // Calls abstract method
        Console.WriteLine($"Total Pay: ${totalPay:C}");
        Console.WriteLine("Payroll processed successfully!");
    }

    // Regular method that cannot be overridden (not virtual)
    public void ClockIn()
    {
        Console.WriteLine($"{name} has clocked in at {DateTime.Now:HH:mm}");
    }
}

// DERIVED CLASS 1 - Full-time Employee
public class FullTimeEmployee : Employee
{
    private decimal bonus;
    private int vacationDays;

    public decimal Bonus { get { return bonus; } set { bonus = value; } }
    public int VacationDays { get { return vacationDays; } }

    // Constructor must call base constructor
    public FullTimeEmployee(string name, int id, decimal salary, int vacationDays)
        : base(name, id, salary)
    {
        this.vacationDays = vacationDays;
        this.bonus = 0; // Default no bonus
        Console.WriteLine($"FullTimeEmployee constructor - {vacationDays} vacation days");
    }

    // MUST implement abstract method - Required!
    public override decimal CalculatePayroll()
    {
        // Full-time employees get full salary plus bonus
        decimal totalPay = baseSalary + bonus;
        Console.WriteLine($"Calculating full-time pay: ${baseSalary:C} + ${bonus:C} bonus");
        return totalPay;
    }

    // MUST implement abstract method - Required!
    public override string GetJobDescription()
    {
        return "Full-time employee with benefits and vacation days";
    }

    // Optional: Override virtual method to add specific behavior
    public override void DisplayBasicInfo()
    {
        base.DisplayBasicInfo(); // Call base implementation
        Console.WriteLine($"Employment Type: Full-time");
        Console.WriteLine($"Vacation Days: {vacationDays}");
        Console.WriteLine($"Current Bonus: ${bonus:C}");
    }

    // Method specific to full-time employees
    public void RequestVacation(int days)
    {
        if (days <= vacationDays)
        {
            Console.WriteLine($"{name} requested {days} vacation days - Approved!");
            vacationDays -= days;
        }
        else
        {
            Console.WriteLine($"{name} requested {days} days but only has {vacationDays} available");
        }
    }
}

// DERIVED CLASS 2 - Part-time Employee
public class PartTimeEmployee : Employee
{
    private decimal hourlyRate;
    private int hoursWorked;

    public decimal HourlyRate { get { return hourlyRate; } }
    public int HoursWorked { get { return hoursWorked; } set { hoursWorked = value; } }

    public PartTimeEmployee(string name, int id, decimal hourlyRate)
        : base(name, id, 0) // Part-time has no base salary
    {
        this.hourlyRate = hourlyRate;
        this.hoursWorked = 0;
        Console.WriteLine($"PartTimeEmployee constructor - ${hourlyRate:C}/hour");
    }

    // MUST implement abstract method with different logic
    public override decimal CalculatePayroll()
    {
        decimal totalPay = hourlyRate * hoursWorked;
        Console.WriteLine($"Calculating part-time pay: ${hourlyRate:C}/hr × {hoursWorked} hours");
        return totalPay;
    }

    // MUST implement abstract method
    public override string GetJobDescription()
    {
        return $"Part-time employee working {hoursWorked} hours this period";
    }

    // Override to show part-time specific info
    public override void DisplayBasicInfo()
    {
        Console.WriteLine($"Employee: {name} (ID: {employeeId})");
        Console.WriteLine($"Employment Type: Part-time");
        Console.WriteLine($"Hourly Rate: ${hourlyRate:C}");
        Console.WriteLine($"Hours Worked: {hoursWorked}");
    }

    // Method specific to part-time employees
    public void LogHours(int hours)
    {
        hoursWorked += hours;
        Console.WriteLine($"{name} logged {hours} hours. Total: {hoursWorked} hours");
    }
}

// DERIVED CLASS 3 - Contractor (shows different implementation approach)
public class Contractor : Employee
{
    private decimal projectRate;
    private int projectsCompleted;
    private List<string> skills;

    public decimal ProjectRate { get { return projectRate; } }
    public int ProjectsCompleted { get { return projectsCompleted; } }
    public List<string> Skills { get { return skills; } }

    public Contractor(string name, int id, decimal projectRate, List<string> skills)
        : base(name, id, 0) // Contractors don't have base salary
    {
        this.projectRate = projectRate;
        this.projectsCompleted = 0;
        this.skills = skills ?? new List<string>();
        Console.WriteLine($"Contractor constructor - ${projectRate:C} per project");
    }

    // MUST implement - Contractors paid per project
    public override decimal CalculatePayroll()
    {
        decimal totalPay = projectRate * projectsCompleted;
        // Bonus for contractors with multiple skills
        if (skills.Count > 3)
        {
            decimal skillBonus = totalPay * 0.1m; // 10% bonus
            totalPay += skillBonus;
            Console.WriteLine($"Calculating contractor pay: {projectsCompleted} projects × ${projectRate:C} + 10% skill bonus");
        }
        else
        {
            Console.WriteLine($"Calculating contractor pay: {projectsCompleted} projects × ${projectRate:C}");
        }
        return totalPay;
    }

    // MUST implement
    public override string GetJobDescription()
    {
        return $"Independent contractor with skills: {string.Join(", ", skills)}";
    }

    // Override to show contractor-specific info
    public override void DisplayBasicInfo()
    {
        Console.WriteLine($"Contractor: {name} (ID: {employeeId})");
        Console.WriteLine($"Project Rate: ${projectRate:C}");
        Console.WriteLine($"Projects Completed: {projectsCompleted}");
        Console.WriteLine($"Skills: {string.Join(", ", skills)}");
    }

    // Contractor-specific methods
    public void CompleteProject(string projectName)
    {
        projectsCompleted++;
        Console.WriteLine($"{name} completed project: {projectName}");
        Console.WriteLine($"Total projects completed: {projectsCompleted}");
    }

    public void AddSkill(string skill)
    {
        if (!skills.Contains(skill))
        {
            skills.Add(skill);
            Console.WriteLine($"{name} learned new skill: {skill}");
        }
    }
}

// DEMONSTRATION CLASS
public class AbstractClassDemo
{
    public static void RunDemo()
    {
        Console.WriteLine("=== ABSTRACT CLASSES AND METHODS DEMO ===\n");

        // ERROR: Cannot instantiate abstract class
        // Employee emp = new Employee("John", 1, 50000); // This would cause compilation error

        // Create concrete instances of derived classes
        FullTimeEmployee fullTimer = new FullTimeEmployee("Alice Johnson", 101, 75000, 20);
        fullTimer.Bonus = 5000;

        PartTimeEmployee partTimer = new PartTimeEmployee("Bob Smith", 102, 25);
        partTimer.LogHours(80); // Log some hours worked

        List<string> contractorSkills = new List<string> { "C#", "JavaScript", "SQL", "React" };
        Contractor contractor = new Contractor("Carol Williams", 103, 2500, contractorSkills);
        contractor.CompleteProject("E-commerce Website");
        contractor.CompleteProject("Mobile App Backend");
        contractor.CompleteProject("Database Migration");

        Console.WriteLine("\n" + new string('=', 50));

        // Process payroll for each employee type
        // Notice: Each uses their own implementation of abstract methods
        fullTimer.ProcessPayroll();

        Console.WriteLine("\n" + new string('-', 30));
        partTimer.ProcessPayroll();

        Console.WriteLine("\n" + new string('-', 30));
        contractor.ProcessPayroll();

        Console.WriteLine("\n" + new string('=', 50));

        // Demonstrate polymorphism with abstract classes
        Console.WriteLine("\n=== POLYMORPHISM WITH ABSTRACT CLASSES ===");
        Employee[] employees = { fullTimer, partTimer, contractor };

        Console.WriteLine("\nAll employees clocking in:");
        foreach (Employee emp in employees)
        {
            emp.ClockIn(); // Same method for all
        }

        Console.WriteLine("\nCalculating total company payroll:");
        decimal totalPayroll = 0;
        foreach (Employee emp in employees)
        {
            // Each employee type uses its own CalculatePayroll() implementation
            totalPayroll += emp.CalculatePayroll();
        }
        Console.WriteLine($"\nTotal Company Payroll: ${totalPayroll:C}");

        // Demonstrate type-specific behavior
        Console.WriteLine("\n=== TYPE-SPECIFIC BEHAVIOR ===");
        fullTimer.RequestVacation(5);
        partTimer.LogHours(20);
        contractor.AddSkill("Docker");
    }
}

// BEST PRACTICES EXAMPLE
// When to use Abstract Classes vs Interfaces (preview for next topic)
public abstract class DatabaseConnection
{
    protected string connectionString;

    public DatabaseConnection(string connectionString)
    {
        this.connectionString = connectionString;
    }

    // Concrete method - common functionality
    public void LogConnection()
    {
        Console.WriteLine($"Connection attempt at {DateTime.Now}");
    }

    // Abstract methods - must be implemented differently for each database type
    public abstract void Connect();
    public abstract void Disconnect();
    public abstract void ExecuteQuery(string query);

    // Template method that uses abstract methods
    public void ProcessQuery(string query)
    {
        Connect();
        ExecuteQuery(query);
        Disconnect();
    }
}

// PROGRAM ENTRY POINT
class Program
{
    static void Main(string[] args)
    {
        AbstractClassDemo.RunDemo();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}