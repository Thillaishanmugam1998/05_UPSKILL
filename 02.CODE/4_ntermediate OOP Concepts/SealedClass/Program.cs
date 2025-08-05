using System;

// =============================================================================
// TOPIC 6: SEALED CLASSES AND METHODS
// =============================================================================

// WHAT IS SEALED?
// The 'sealed' keyword prevents inheritance - it's like putting a "final lock" on a class or method
// Think of it like a finished product that shouldn't be modified further

// =============================================================================
// 1. SEALED CLASSES
// =============================================================================

// A sealed class cannot be inherited by other classes
// Real-world analogy: Like a final product specification that cannot be modified
public sealed class DatabaseConnection
{
    private string _connectionString;

    public DatabaseConnection(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Connect()
    {
        Console.WriteLine($"Connecting to database: {_connectionString}");
    }

    public void Disconnect()
    {
        Console.WriteLine("Database connection closed");
    }
}

// This would cause a compilation error because DatabaseConnection is sealed:
/*
public class ExtendedDatabaseConnection : DatabaseConnection  // ERROR!
{
    // Cannot inherit from sealed class
}
*/

// =============================================================================
// 2. SEALED METHODS
// =============================================================================

// Base class with virtual methods
public class Vehicle
{
    // Virtual method - can be overridden
    public virtual void Start()
    {
        Console.WriteLine("Vehicle is starting...");
    }

    // Virtual method - can be overridden
    public virtual void Stop()
    {
        Console.WriteLine("Vehicle is stopping...");
    }
}

// Intermediate class that overrides and seals a method
public class Car : Vehicle
{
    // Override the Start method and seal it (no further overriding allowed)
    public sealed override void Start()
    {
        Console.WriteLine("Car engine is starting with ignition key...");
    }

    // Regular override - can still be overridden by derived classes
    public override void Stop()
    {
        Console.WriteLine("Car is stopping with brakes...");
    }
}

// Final derived class
public class SportsCar : Car
{
    // This would cause an error because Start() is sealed in Car class:
    /*
    public override void Start()  // ERROR!
    {
        Console.WriteLine("Sports car turbo engine starting...");
    }
    */

    // This is allowed because Stop() is not sealed
    public override void Stop()
    {
        Console.WriteLine("Sports car stopping with performance brakes...");
    }
}

// =============================================================================
// 3. PRACTICAL EXAMPLE: PAYMENT PROCESSING SYSTEM
// =============================================================================

// Base payment processor
public abstract class PaymentProcessor
{
    protected decimal amount;

    public PaymentProcessor(decimal amount)
    {
        this.amount = amount;
    }

    // Virtual method that can be overridden
    public virtual bool ValidatePayment()
    {
        Console.WriteLine("Basic payment validation...");
        return amount > 0;
    }

    // Abstract method that must be implemented
    public abstract void ProcessPayment();
}

// Credit card processor - allows some customization but seals critical methods
public class CreditCardProcessor : PaymentProcessor
{
    private string cardNumber;

    public CreditCardProcessor(decimal amount, string cardNumber) : base(amount)
    {
        this.cardNumber = cardNumber;
    }

    // Sealed override - security-critical method that shouldn't be changed further
    public sealed override bool ValidatePayment()
    {
        Console.WriteLine("Credit card validation with encryption...");
        // Critical validation logic that shouldn't be modified
        return !string.IsNullOrEmpty(cardNumber) && amount > 0 && amount <= 10000;
    }

    // Implementation of abstract method
    public override void ProcessPayment()
    {
        if (ValidatePayment())
        {
            Console.WriteLine($"Processing ${amount} credit card payment...");
        }
    }
}

// Specific credit card type - cannot override the sealed validation method
public class PremiumCreditCardProcessor : CreditCardProcessor
{
    public PremiumCreditCardProcessor(decimal amount, string cardNumber)
        : base(amount, cardNumber)
    {
    }

    // This would cause an error because ValidatePayment() is sealed:
    /*
    public override bool ValidatePayment()  // ERROR!
    {
        // Cannot override sealed method
    }
    */

    // Can override non-sealed methods
    public override void ProcessPayment()
    {
        Console.WriteLine("Premium processing with additional benefits...");
        base.ProcessPayment(); // Call the base implementation
    }
}

// =============================================================================
// 4. SEALED CLASS EXAMPLE: CONFIGURATION MANAGER
// =============================================================================

// Sealed class for application configuration - prevents inheritance for security
public sealed class ConfigurationManager
{
    private static ConfigurationManager _instance;
    private static readonly object _lock = new object();

    // Private constructor prevents direct instantiation
    private ConfigurationManager()
    {
        LoadConfiguration();
    }

    // Singleton pattern implementation
    public static ConfigurationManager Instance
    {
        get
        {
            // Thread-safe singleton creation
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }
            return _instance;
        }
    }

    private void LoadConfiguration()
    {
        Console.WriteLine("Loading application configuration...");
    }

    public string GetConnectionString(string name)
    {
        return $"Server=localhost;Database={name};Trusted_Connection=true;";
    }

    public T GetSetting<T>(string key, T defaultValue)
    {
        Console.WriteLine($"Getting setting: {key}");
        return defaultValue; // Simplified implementation
    }
}

// =============================================================================
// 5. DEMONSTRATION CLASS
// =============================================================================

public class SealedConceptsDemo
{
    public static void RunExamples()
    {
        Console.WriteLine("=== SEALED CLASSES AND METHODS DEMO ===\n");

        // 1. Using sealed class
        Console.WriteLine("1. Sealed Class Example:");
        var dbConnection = new DatabaseConnection("Server=localhost;Database=MyApp");
        dbConnection.Connect();
        dbConnection.Disconnect();
        Console.WriteLine();

        // 2. Sealed methods in inheritance hierarchy
        Console.WriteLine("2. Sealed Methods Example:");
        Vehicle vehicle = new Vehicle();
        Car car = new Car();
        SportsCar sportsCar = new SportsCar();

        vehicle.Start();  // Base implementation
        car.Start();      // Sealed override
        sportsCar.Start(); // Uses sealed implementation from Car (cannot override)

        Console.WriteLine();

        vehicle.Stop();   // Base implementation
        car.Stop();       // Regular override
        sportsCar.Stop(); // Can override because Stop() is not sealed
        Console.WriteLine();

        // 3. Payment processing example
        Console.WriteLine("3. Payment Processing Example:");
        var creditProcessor = new CreditCardProcessor(500m, "1234-5678-9012-3456");
        var premiumProcessor = new PremiumCreditCardProcessor(1000m, "9876-5432-1098-7654");

        creditProcessor.ProcessPayment();
        premiumProcessor.ProcessPayment();
        Console.WriteLine();

        // 4. Sealed singleton configuration manager
        Console.WriteLine("4. Sealed Configuration Manager:");
        var config = ConfigurationManager.Instance;
        string connectionString = config.GetConnectionString("UserDB");
        int timeout = config.GetSetting("Timeout", 30);

        Console.WriteLine($"Connection String: {connectionString}");
        Console.WriteLine($"Timeout Setting: {timeout} seconds");
    }
}

// =============================================================================
// BEST PRACTICES FOR SEALED CLASSES AND METHODS
// =============================================================================

/*
WHEN TO USE SEALED CLASSES:
✅ Security-sensitive classes (like authentication, encryption)
✅ Singleton patterns where inheritance could break the pattern
✅ Performance-critical classes where inheritance might add overhead
✅ Classes that represent final, complete implementations
✅ When you want to prevent misuse through inheritance

WHEN TO USE SEALED METHODS:
✅ Security-critical methods that shouldn't be overridden
✅ Methods with complex logic that must remain unchanged
✅ Performance-sensitive methods where overriding could cause issues
✅ Methods that are part of a contract that shouldn't be modified

WHEN NOT TO USE SEALED:
❌ Don't seal classes/methods prematurely - only when you're certain
❌ Avoid sealing in library code unless absolutely necessary
❌ Don't use sealed just to prevent inheritance - use composition instead
❌ Don't seal methods that might legitimately need customization

PERFORMANCE BENEFITS:
- Sealed classes enable certain compiler optimizations
- Virtual method calls can be optimized when the class is sealed
- JIT compiler can inline methods more aggressively

KEY DIFFERENCES:
- SEALED CLASS: Cannot be inherited at all
- SEALED METHOD: Can only be used on overridden methods, prevents further overriding
- ABSTRACT vs SEALED: Complete opposites - abstract forces inheritance, sealed prevents it
- VIRTUAL vs SEALED: Virtual allows overriding, sealed prevents it (when overriding)
*/