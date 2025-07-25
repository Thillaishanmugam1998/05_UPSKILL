using System;
using System.Collections.Generic;

// Class demonstrating various constructor types
public class Person
{
    // Fields
    private string firstName;
    private string lastName;
    private int age;
    private DateTime birthDate;
    private string email;
    private static int personCount = 0; // Static field to track total persons created

    // Properties
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value?.Trim(); }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value?.Trim(); }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0 && value <= 150)
                age = value;
            else
                throw new ArgumentException("Age must be between 0 and 150");
        }
    }

    public DateTime BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string FullName
    {
        get { return $"{FirstName} {LastName}"; }
    }

    public static int PersonCount
    {
        get { return personCount; }
    }

    // 1. Static Constructor - called once when class is first used
    static Person()
    {
        Console.WriteLine("Static constructor called - Person class initialized");
        personCount = 0;
    }

    // 2. Default Constructor (no parameters)
    public Person()
    {
        Console.WriteLine("Default constructor called");
        firstName = "Unknown";
        lastName = "Unknown";
        age = 0;
        birthDate = DateTime.Now;
        email = "";
        personCount++;
        Console.WriteLine($"Person created. Total persons: {personCount}");
    }

    // 3. Parameterized Constructor (with parameters)
    public Person(string firstName, string lastName)
    {
        Console.WriteLine("Parameterized constructor (name only) called");
        FirstName = firstName;  // Using property for validation
        LastName = lastName;    // Using property for validation
        age = 0;
        birthDate = DateTime.Now;
        email = "";
        personCount++;
        Console.WriteLine($"Person '{FullName}' created. Total persons: {personCount}");
    }

    // 4. Another Parameterized Constructor (constructor overloading)
    public Person(string firstName, string lastName, int age)
    {
        Console.WriteLine("Parameterized constructor (name and age) called");
        FirstName = firstName;
        LastName = lastName;
        Age = age;  // Using property for validation
        birthDate = DateTime.Now.AddYears(-age); // Approximate birth date
        email = "";
        personCount++;
        Console.WriteLine($"Person '{FullName}' (age {age}) created. Total persons: {personCount}");
    }

    // 5. Full Parameterized Constructor
    public Person(string firstName, string lastName, DateTime birthDate, string email)
    {
        Console.WriteLine("Full parameterized constructor called");
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Email = email;
        // Calculate age from birth date
        age = DateTime.Now.Year - birthDate.Year;
        if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
            age--;

        personCount++;
        Console.WriteLine($"Person '{FullName}' (born {birthDate:yyyy-MM-dd}) created. Total persons: {personCount}");
    }

    // 6. Copy Constructor (creates a copy of another Person)
    public Person(Person other)
    {
        Console.WriteLine("Copy constructor called");
        if (other != null)
        {
            FirstName = other.FirstName;
            LastName = other.LastName;
            Age = other.Age;
            BirthDate = other.BirthDate;
            Email = other.Email;
            personCount++;
            Console.WriteLine($"Copy of '{FullName}' created. Total persons: {personCount}");
        }
        else
        {
            throw new ArgumentNullException("Cannot copy from null Person object");
        }
    }

    // Constructor chaining using 'this' keyword
    public Person(string firstName, string lastName, int age, string email)
        : this(firstName, lastName, DateTime.Now.AddYears(-age), email)
    {
        Console.WriteLine("Constructor chaining completed");
    }

    // Methods
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {FullName}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Birth Date: {BirthDate:yyyy-MM-dd}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine("------------------------");
    }

    public void CelebrateBirthday()
    {
        Age++;
        Console.WriteLine($"Happy Birthday {FirstName}! You are now {Age} years old.");
    }

    // 7. Destructor (Finalizer) - rarely used in C#
    ~Person()
    {
        Console.WriteLine($"Destructor called for {FullName}");
        // Note: In real applications, destructors are rarely needed
        // The garbage collector handles memory cleanup automatically
    }
}

// Class demonstrating resource management with constructor/destructor
public class FileManager
{
    private string fileName;
    private bool isFileOpen;
    private DateTime creationTime;

    // Constructor
    public FileManager(string fileName)
    {
        this.fileName = fileName;
        this.creationTime = DateTime.Now;
        this.isFileOpen = false;

        Console.WriteLine($"FileManager created for '{fileName}' at {creationTime}");

        // Simulate opening a file
        OpenFile();
    }

    private void OpenFile()
    {
        // Simulate file opening
        isFileOpen = true;
        Console.WriteLine($"File '{fileName}' opened successfully");
    }

    public void WriteToFile(string content)
    {
        if (isFileOpen)
        {
            Console.WriteLine($"Writing to '{fileName}': {content}");
        }
        else
        {
            Console.WriteLine("Cannot write - file is not open");
        }
    }

    public void CloseFile()
    {
        if (isFileOpen)
        {
            isFileOpen = false;
            Console.WriteLine($"File '{fileName}' closed");
        }
    }

    // Destructor for cleanup
    ~FileManager()
    {
        Console.WriteLine($"FileManager destructor called for '{fileName}'");
        if (isFileOpen)
        {
            Console.WriteLine("Cleaning up - closing file in destructor");
            CloseFile();
        }
    }
}

// Class demonstrating initialization patterns
public class BankAccount2
{
    public string AccountNumber { get; private set; }
    public string OwnerName { get; private set; }
    public decimal Balance { get; private set; }
    public DateTime CreationDate { get; private set; }
    public string AccountType { get; private set; }

    private static readonly List<string> ValidAccountTypes = new List<string>
    {
        "Savings", "Checking", "Business", "Investment"
    };

    // Static constructor to initialize static data
    static BankAccount2()
    {
        Console.WriteLine("BankAccount2 static constructor - initializing valid account types");
    }

    // Primary constructor with validation
    public BankAccount2(string accountNumber, string ownerName, string accountType, decimal initialDeposit = 0)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(accountNumber) || accountNumber.Length != 10)
            throw new ArgumentException("Account number must be exactly 10 characters");

        if (string.IsNullOrWhiteSpace(ownerName))
            throw new ArgumentException("Owner name cannot be empty");

        if (!ValidAccountTypes.Contains(accountType))
            throw new ArgumentException($"Invalid account type. Valid types: {string.Join(", ", ValidAccountTypes)}");

        if (initialDeposit < 0)
            throw new ArgumentException("Initial deposit cannot be negative");

        // Initialize properties
        AccountNumber = accountNumber;
        OwnerName = ownerName.Trim();
        AccountType = accountType;
        Balance = initialDeposit;
        CreationDate = DateTime.Now;

        Console.WriteLine($"BankAccount2 created: {OwnerName} - {AccountType} account with ${Balance:F2}");
    }

    // Convenience constructor for savings account with minimum deposit
    public BankAccount2(string ownerName, string accountNumber)
        : this(accountNumber, ownerName, "Savings", 100.00m)
    {
        Console.WriteLine("Convenience constructor used - created Savings account with $100 minimum deposit");
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount:F2}. New balance: ${Balance:F2}");
        }
    }

    public void DisplayAccount()
    {
        Console.WriteLine($"Account: {AccountNumber} ({AccountType})");
        Console.WriteLine($"Owner: {OwnerName}");
        Console.WriteLine($"Balance: ${Balance:F2}");
        Console.WriteLine($"Created: {CreationDate:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine("------------------------");
    }
}

// Demonstration program
public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== C# Constructor Demonstration ===\n");

        // 1. Default constructor
        Console.WriteLine("1. Creating person with default constructor:");
        Person person1 = new Person();
        person1.DisplayInfo();

        // 2. Parameterized constructor (name only)
        Console.WriteLine("2. Creating person with name constructor:");
        Person person2 = new Person("John", "Doe");
        person2.DisplayInfo();

        // 3. Parameterized constructor (name and age)
        Console.WriteLine("3. Creating person with name and age constructor:");
        Person person3 = new Person("Jane", "Smith", 25);
        person3.DisplayInfo();

        // 4. Full parameterized constructor
        Console.WriteLine("4. Creating person with full constructor:");
        Person person4 = new Person("Bob", "Johnson", new DateTime(1990, 5, 15), "bob.johnson@email.com");
        person4.DisplayInfo();

        // 5. Constructor chaining
        Console.WriteLine("5. Creating person with constructor chaining:");
        Person person5 = new Person("Alice", "Brown", 30, "alice.brown@email.com");
        person5.DisplayInfo();

        // 6. Copy constructor
        Console.WriteLine("6. Creating person with copy constructor:");
        Person person6 = new Person(person4);
        person6.DisplayInfo();

        // Display total person count
        Console.WriteLine($"Total persons created: {Person.PersonCount}\n");

        // Demonstrate FileManager
        Console.WriteLine("=== FileManager Demonstration ===");
        FileManager fileManager = new FileManager("test.txt");
        fileManager.WriteToFile("Hello, World!");
        fileManager.WriteToFile("This is a test file.");
        fileManager.CloseFile();

        Console.WriteLine();

        // Demonstrate BankAccount2
        Console.WriteLine("=== BankAccount2 Demonstration ===");

        try
        {
            // Create accounts with different constructors
            BankAccount2 account1 = new BankAccount2("1234567890", "John Doe", "Checking", 500.00m);
            account1.DisplayAccount();

            BankAccount2 account2 = new BankAccount2("Jane Smith", "9876543210");
            account2.DisplayAccount();

            // Make some deposits
            account1.Deposit(150.00m);
            account2.Deposit(50.00m);

            Console.WriteLine("\nAfter deposits:");
            account1.DisplayAccount();
            account2.DisplayAccount();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error creating account: {ex.Message}");
        }

        // Test birthday celebration
        Console.WriteLine("\n=== Birthday Celebration ===");
        person3.CelebrateBirthday();
        person3.DisplayInfo();

        Console.WriteLine("\n=== Program End ===");

        // Note: Destructors will be called by garbage collector automatically
        // We can force garbage collection for demonstration (not recommended in real apps)
        Console.WriteLine("\nForcing garbage collection...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}