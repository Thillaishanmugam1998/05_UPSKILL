using System;
using System.Collections.Generic;

public class BankAccount
{
    // 1. FIELDS (data storage)
    private string accountNumber;    // Private field - encapsulated
    private double balance;          // Private field - protected data
    private string accountType;     // Private field
    private DateTime creationDate;  // Private field
    private List<string> transactions; // Private field for transaction history

    // Public field (generally not recommended, but shown for demonstration)
    public string bankName = "ABC Bank";

    // 2. PROPERTIES (controlled access to data)

    // Auto-implemented property (C# creates hidden backing field)
    public string OwnerName { get; set; }

    // Property with backing field and validation
    public string AccountNumber
    {
        get { return accountNumber; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length != 10)
            {
                throw new ArgumentException("Account number must be 10 digits");
            }
            accountNumber = value;
        }
    }

    // Read-only property (only getter)
    public double Balance
    {
        get { return balance; }
    }

    // Property with validation in setter
    public string AccountType
    {
        get { return accountType; }
        set
        {
            if (value == "Savings" || value == "Checking" || value == "Business")
            {
                accountType = value;
            }
            else
            {
                throw new ArgumentException("Invalid account type");
            }
        }
    }

    // Read-only property
    public DateTime CreationDate
    {
        get { return creationDate; }
    }

    // Computed property (calculated from other data)
    public string AccountSummary
    {
        get
        {
            return $"{OwnerName} - {AccountType} Account ({AccountNumber}) - Balance: ${Balance:F2}";
        }
    }

    // Property returning collection count
    public int TransactionCount
    {
        get { return transactions.Count; }
    }

    // 3. METHODS (behavior and operations)

    // Constructor method (special method for object initialization)
    public BankAccount(string ownerName, string accountNumber, string accountType)
    {
        OwnerName = ownerName;
        AccountNumber = accountNumber; // Uses property setter for validation
        AccountType = accountType;     // Uses property setter for validation
        balance = 0.0;
        creationDate = DateTime.Now;
        transactions = new List<string>();
        AddTransaction($"Account created for {ownerName}");
    }

    // Method with return value
    public bool Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be positive");
            return false;
        }

        balance += amount;
        AddTransaction($"Deposited ${amount:F2}");
        Console.WriteLine($"Deposited ${amount:F2}. New balance: ${balance:F2}");
        return true;
    }

    // Method with validation and conditional logic
    public bool Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive");
            return false;
        }

        if (amount > balance)
        {
            Console.WriteLine("Insufficient funds");
            return false;
        }

        balance -= amount;
        AddTransaction($"Withdrew ${amount:F2}");
        Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${balance:F2}");
        return true;
    }

    // Method for transferring between accounts
    public bool TransferTo(BankAccount targetAccount, double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Transfer amount must be positive");
            return false;
        }

        if (this.Withdraw(amount))
        {
            targetAccount.Deposit(amount);
            AddTransaction($"Transferred ${amount:F2} to {targetAccount.OwnerName}");
            targetAccount.AddTransaction($"Received ${amount:F2} from {this.OwnerName}");
            return true;
        }

        return false;
    }

    // Private method (helper method)
    private void AddTransaction(string description)
    {
        string transaction = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {description}";
        transactions.Add(transaction);
    }

    // Method to display information
    public void DisplayAccountInfo()
    {
        Console.WriteLine("=== ACCOUNT INFORMATION ===");
        Console.WriteLine($"Bank: {bankName}");
        Console.WriteLine($"Owner: {OwnerName}");
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Account Type: {AccountType}");
        Console.WriteLine($"Balance: ${Balance:F2}");
        Console.WriteLine($"Created: {CreationDate:yyyy-MM-dd}");
        Console.WriteLine($"Total Transactions: {TransactionCount}");
        Console.WriteLine("===========================");
    }

    // Method to show transaction history
    public void ShowTransactionHistory(int lastNTransactions = 5)
    {
        Console.WriteLine($"\n=== LAST {Math.Min(lastNTransactions, transactions.Count)} TRANSACTIONS ===");

        int startIndex = Math.Max(0, transactions.Count - lastNTransactions);
        for (int i = startIndex; i < transactions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {transactions[i]}");
        }
        Console.WriteLine("================================");
    }

    // Method with multiple parameters and default values
    public void GenerateStatement(bool includeTransactions = true, int transactionLimit = 10)
    {
        Console.WriteLine("\n=== ACCOUNT STATEMENT ===");
        Console.WriteLine(AccountSummary);
        Console.WriteLine($"Statement Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

        if (includeTransactions)
        {
            ShowTransactionHistory(transactionLimit);
        }
        Console.WriteLine("=========================");
    }
}

// Another class to demonstrate different types of members
public class Calculator
{
    // Static field (belongs to the class, not instance)
    public static string CalculatorName = "Advanced Calculator v1.0";
    private static int calculationCount = 0;

    // Instance fields
    private double lastResult;
    private List<string> history;

    // Property for last result
    public double LastResult
    {
        get { return lastResult; }
    }

    // Static property
    public static int TotalCalculations
    {
        get { return calculationCount; }
    }

    // Constructor
    public Calculator()
    {
        lastResult = 0;
        history = new List<string>();
    }

    // Instance methods
    public double Add(double a, double b)
    {
        lastResult = a + b;
        RecordCalculation($"{a} + {b} = {lastResult}");
        return lastResult;
    }

    public double Multiply(double a, double b)
    {
        lastResult = a * b;
        RecordCalculation($"{a} × {b} = {lastResult}");
        return lastResult;
    }

    // Static method (doesn't need instance)
    public static double Power(double baseNumber, double exponent)
    {
        calculationCount++;
        return Math.Pow(baseNumber, exponent);
    }

    private void RecordCalculation(string calculation)
    {
        calculationCount++;
        history.Add($"{DateTime.Now:HH:mm:ss} - {calculation}");
    }

    public void ShowHistory()
    {
        Console.WriteLine("Calculation History:");
        foreach (string record in history)
        {
            Console.WriteLine($"  {record}");
        }
    }
}

class FieldsPropertiesMethodsDemo
{
    static void Main()
    {
        Console.WriteLine("=== FIELDS, PROPERTIES, AND METHODS DEMO ===\n");

        // 1. Creating and using objects with properties
        Console.WriteLine("1. Creating Bank Accounts:");

        try
        {
            BankAccount account1 = new BankAccount("John Doe", "1234567890", "Savings");
            BankAccount account2 = new BankAccount("Jane Smith", "0987654321", "Checking");

            // Display initial account information
            account1.DisplayAccountInfo();
            account2.DisplayAccountInfo();

            // 2. Using methods to modify object state
            Console.WriteLine("\n2. Performing Banking Operations:");

            account1.Deposit(1000);
            account1.Deposit(500);
            account1.Withdraw(200);

            account2.Deposit(750);
            account2.Withdraw(100);

            // 3. Demonstrating property access
            Console.WriteLine("\n3. Property Access:");
            Console.WriteLine($"Account 1 Balance: ${account1.Balance:F2}");
            Console.WriteLine($"Account 1 Summary: {account1.AccountSummary}");
            Console.WriteLine($"Account 2 Transaction Count: {account2.TransactionCount}");

            // 4. Transfer between accounts
            Console.WriteLine("\n4. Transfer Operations:");
            account1.TransferTo(account2, 300);

            // Show updated balances
            Console.WriteLine($"Account 1 Balance after transfer: ${account1.Balance:F2}");
            Console.WriteLine($"Account 2 Balance after transfer: ${account2.Balance:F2}");

            // 5. Show transaction history
            Console.WriteLine("\n5. Transaction History:");
            account1.ShowTransactionHistory(3);
            account2.ShowTransactionHistory(3);

            // 6. Generate statements
            Console.WriteLine("\n6. Account Statements:");
            account1.GenerateStatement(true, 5);

            // 7. Demonstrating Calculator class with static members
            Console.WriteLine("\n7. Calculator Demo (Static vs Instance):");

            Calculator calc1 = new Calculator();
            Calculator calc2 = new Calculator();

            Console.WriteLine($"Calculator Name: {Calculator.CalculatorName}");
            Console.WriteLine($"Initial calculation count: {Calculator.TotalCalculations}");

            // Instance method calls
            calc1.Add(10, 5);
            calc1.Multiply(3, 4);

            calc2.Add(20, 15);

            // Static method call (no instance needed)
            double powerResult = Calculator.Power(2, 8);
            Console.WriteLine($"2^8 = {powerResult}");

            Console.WriteLine($"Total calculations performed: {Calculator.TotalCalculations}");
            Console.WriteLine($"Calc1 last result: {calc1.LastResult}");
            Console.WriteLine($"Calc2 last result: {calc2.LastResult}");

            calc1.ShowHistory();
            calc2.ShowHistory();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // 8. Demonstrating property validation
        Console.WriteLine("\n8. Property Validation Demo:");
        try
        {
            BankAccount invalidAccount = new BankAccount("Test User", "123", "Savings"); // Invalid account number
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Validation Error: {ex.Message}");
        }

        try
        {
            BankAccount account = new BankAccount("Test User", "1111111111", "InvalidType"); // Invalid account type
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Validation Error: {ex.Message}");
        }
    }
}