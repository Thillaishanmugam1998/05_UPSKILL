using System;
using System.Collections.Generic;
using System.Linq;

namespace EncapsulationDemo
{
    // Well-encapsulated class demonstrating proper data hiding
    public class BankAccount

    {
        // Private fields - hidden from outside access
        private string accountNumber;
        private decimal balance;
        private List<Transaction> transactions;
        private readonly DateTime createdDate;

        // Public properties with controlled access
        public string AccountNumber
        {
            get { return accountNumber; }
        }

        public string AccountHolder { get; private set; }

        public decimal Balance
        {
            get { return balance; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
        }

        // Read-only property that provides controlled access to transactions
        public IReadOnlyList<Transaction> TransactionHistory
        {
            get { return transactions.AsReadOnly(); }
        }

        // Constructor with validation
        public BankAccount(string accountHolder, string accountNumber, decimal initialDeposit = 0)
        {
            if (string.IsNullOrWhiteSpace(accountHolder))
                throw new ArgumentException("Account holder name cannot be empty.");

            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number cannot be empty.");

            if (initialDeposit < 0)
                throw new ArgumentException("Initial deposit cannot be negative.");

            this.AccountHolder = accountHolder;
            this.accountNumber = accountNumber;
            this.balance = initialDeposit;
            this.createdDate = DateTime.Now;
            this.transactions = new List<Transaction>();

            if (initialDeposit > 0)
            {
                RecordTransaction("Initial Deposit", initialDeposit);
            }
        }

        // Public method with input validation and business logic
        public bool Deposit(decimal amount)
        {
            if (!IsValidAmount(amount))
            {
                Console.WriteLine("Invalid deposit amount. Amount must be positive.");
                return false;
            }

            balance += amount;
            RecordTransaction("Deposit", amount);
            Console.WriteLine($"Deposited ${amount:F2}. New balance: ${balance:F2}");
            return true;
        }

        // Public method with business rules and validation
        public bool Withdraw(decimal amount)
        {
            if (!IsValidAmount(amount))
            {
                Console.WriteLine("Invalid withdrawal amount. Amount must be positive.");
                return false;
            }

            if (!HasSufficientFunds(amount))
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
                return false;
            }

            balance -= amount;
            RecordTransaction("Withdrawal", -amount);
            Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${balance:F2}");
            return true;
        }

        // Public method to transfer funds
        public bool TransferTo(BankAccount targetAccount, decimal amount)
        {
            if (targetAccount == null)
            {
                Console.WriteLine("Target account cannot be null.");
                return false;
            }

            if (targetAccount == this)
            {
                Console.WriteLine("Cannot transfer to the same account.");
                return false;
            }

            if (Withdraw(amount))
            {
                if (targetAccount.Deposit(amount))
                {
                    Console.WriteLine($"Successfully transferred ${amount:F2} to {targetAccount.AccountHolder}");
                    return true;
                }
                else
                {
                    // Rollback if deposit fails
                    Deposit(amount);
                    Console.WriteLine("Transfer failed. Amount has been returned to your account.");
                    return false;
                }
            }

            return false;
        }

        // Private helper method - internal business logic
        private bool IsValidAmount(decimal amount)
        {
            return amount > 0 && amount <= 10000; // Business rule: max transaction of $10,000
        }

        // Private helper method - internal validation
        private bool HasSufficientFunds(decimal amount)
        {
            return balance >= amount;
        }

        // Private helper method - internal record keeping
        private void RecordTransaction(string type, decimal amount)
        {
            transactions.Add(new Transaction(type, amount, DateTime.Now));
        }

        // Public method to display account summary
        public void DisplayAccountSummary()
        {
            Console.WriteLine($"\n=== Account Summary ===");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Holder: {AccountHolder}");
            Console.WriteLine($"Current Balance: ${Balance:F2}");
            Console.WriteLine($"Account Created: {CreatedDate:yyyy-MM-dd}");
            Console.WriteLine($"Total Transactions: {transactions.Count}");
        }

        // Public method to display recent transactions
        public void DisplayRecentTransactions(int count = 5)
        {
            Console.WriteLine($"\n=== Recent Transactions (Last {count}) ===");
            var recentTransactions = transactions.TakeLast(count);

            foreach (var transaction in recentTransactions)
            {
                Console.WriteLine($"{transaction.Date:yyyy-MM-dd HH:mm} - {transaction.Type}: ${transaction.Amount:F2}");
            }
        }
    }

    // Supporting class with proper encapsulation
    public class Transaction
    {
        // Auto-implemented properties with private setters
        public string Type { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }

        public Transaction(string type, decimal amount, DateTime date)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Amount = amount;
            Date = date;
        }

        // Override ToString for better display
        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd HH:mm} - {Type}: ${Amount:F2}";
        }
    }

    // Example of poor encapsulation (for demonstration)
    public class PoorlyEncapsulatedAccount
    {
        // Public fields - anyone can modify directly
        public string accountNumber;
        public decimal balance;
        public string accountHolder;

        // No validation in constructor
        public PoorlyEncapsulatedAccount(string holder, string number)
        {
            accountHolder = holder;
            accountNumber = number;
            balance = 0;
        }

        // Methods without validation
        public void Deposit(decimal amount)
        {
            balance += amount; // No validation - could allow negative deposits
        }

        public void Withdraw(decimal amount)
        {
            balance -= amount; // No validation - could create negative balance
        }
    }

    // Demonstration class showing different levels of property access
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        // Property with full control over get/set
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First name cannot be empty.");
                firstName = value.Trim();
            }
        }

        // Property with validation on set
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Last name cannot be empty.");
                lastName = value.Trim();
            }
        }

        // Property with validation and business logic
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentException("Age must be between 0 and 150.");
                age = value;
            }
        }

        // Computed property - no backing field
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        // Read-only property with business logic
        public string AgeCategory
        {
            get
            {
                if (age < 13) return "Child";
                if (age < 20) return "Teenager";
                if (age < 65) return "Adult";
                return "Senior";
            }
        }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName; // Uses property setter for validation
            LastName = lastName;   // Uses property setter for validation
            Age = age;            // Uses property setter for validation
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Encapsulation Principles Demo ===\n");

            try
            {
                // Creating well-encapsulated bank accounts
                Console.WriteLine("=== Well-Encapsulated Bank Account ===");
                BankAccount account1 = new BankAccount("John Doe", "ACC001", 1000);
                BankAccount account2 = new BankAccount("Jane Smith", "ACC002", 500);

                // Using public interface methods
                account1.Deposit(200);
                account1.Withdraw(150);

                // Attempting transfer
                account1.TransferTo(account2, 300);

                // Display account information
                account1.DisplayAccountSummary();
                account1.DisplayRecentTransactions(3);

                account2.DisplayAccountSummary();

                // Demonstrate that private fields cannot be accessed
                // account1.balance = 5000; // This would cause compilation error
                // account1.accountNumber = "HACK"; // This would cause compilation error

                // But public properties provide controlled access
                Console.WriteLine($"\nAccount1 Balance (read-only): ${account1.Balance}");
                Console.WriteLine($"Account1 Number (read-only): {account1.AccountNumber}");

                Console.WriteLine("\n=== Person Class with Property Validation ===");
                Person person = new Person("John", "Doe", 30);
                Console.WriteLine($"Person: {person.FullName}, Age: {person.Age} ({person.AgeCategory})");

                // Properties provide validation
                person.Age = 17;
                Console.WriteLine($"Updated: {person.FullName}, Age: {person.Age} ({person.AgeCategory})");

                // This would throw an exception due to validation
                // person.Age = -5; // Uncomment to see validation in action

                Console.WriteLine("\n=== Poorly Encapsulated Account (Bad Example) ===");
                PoorlyEncapsulatedAccount poorAccount = new PoorlyEncapsulatedAccount("Bad Example", "POOR001");

                // Direct field access - no encapsulation
                poorAccount.balance = 1000;
                Console.WriteLine($"Poor account balance: ${poorAccount.balance}");

                // No validation - can create invalid states
                poorAccount.balance = -500; // Negative balance allowed!
                poorAccount.accountNumber = ""; // Empty account number allowed!
                Console.WriteLine($"Poor account corrupted - Balance: ${poorAccount.balance}, Number: '{poorAccount.accountNumber}'");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}