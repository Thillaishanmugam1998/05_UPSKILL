using System;

namespace AccessModifiersDemo
{
    // Internal class - accessible within this assembly only
    internal class BankAccount
    {
        // Private field - only accessible within this class
        private decimal balance;
        private string accountNumber;

        // Protected field - accessible in this class and derived classes
        protected DateTime createdDate;

        // Public property - accessible from anywhere
        public string AccountHolder { get; set; }

        // Public constructor
        public BankAccount(string accountHolder, string accountNumber)
        {
            this.AccountHolder = accountHolder;
            this.accountNumber = accountNumber;
            this.balance = 0;
            this.createdDate = DateTime.Now;
        }

        // Public method - external interface
        public void Deposit(decimal amount)
        {
            if (ValidateAmount(amount))
            {
                balance += amount;
                Console.WriteLine($"Deposited ${amount}. New balance: ${balance}");
            }
        }

        // Public method with internal logic
        public bool Withdraw(decimal amount)
        {
            if (ValidateAmount(amount) && HasSufficientFunds(amount))
            {
                balance -= amount;
                Console.WriteLine($"Withdrew ${amount}. New balance: ${balance}");
                return true;
            }
            return false;
        }

        // Public property to safely expose balance
        public decimal Balance
        {
            get { return balance; }
        }

        // Private method - internal validation logic
        private bool ValidateAmount(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Amount must be positive.");
                return false;
            }
            return true;
        }

        // Private method - internal business logic
        private bool HasSufficientFunds(decimal amount)
        {
            if (balance < amount)
            {
                Console.WriteLine("Insufficient funds.");
                return false;
            }
            return true;
        }

        // Protected method - can be overridden in derived classes
        protected virtual void LogTransaction(string transactionType, decimal amount)
        {
            Console.WriteLine($"[{createdDate:yyyy-MM-dd}] {transactionType}: ${amount}");
        }
    }

    // Derived class demonstrating protected access
    internal class SavingsAccount : BankAccount
    {
        private decimal interestRate;

        public SavingsAccount(string accountHolder, string accountNumber, decimal interestRate)
            : base(accountHolder, accountNumber)
        {
            this.interestRate = interestRate;
        }

        public void ApplyInterest()
        {
            decimal interest = Balance * interestRate;
            Deposit(interest);

            // Can access protected members from base class
            LogTransaction("Interest Applied", interest);

            // Cannot access private members like 'balance' directly
            // balance += interest; // This would cause a compilation error
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Access Modifiers Demo ===\n");

            // Create a bank account
            BankAccount account = new BankAccount("John Doe", "12345");

            // Public members are accessible
            Console.WriteLine($"Account Holder: {account.AccountHolder}");

            // Public methods can be called
            account.Deposit(1000);
            account.Withdraw(250);

            // Public property provides safe access to balance
            Console.WriteLine($"Current Balance: ${account.Balance}");

            // Private members are not accessible from outside
            // account.balance = 5000; // This would cause a compilation error
            // account.ValidateAmount(100); // This would cause a compilation error

            Console.WriteLine("\n=== Savings Account Demo ===\n");

            SavingsAccount savings = new SavingsAccount("Jane Smith", "67890", 0.05m);
            savings.Deposit(2000);
            savings.ApplyInterest();

            Console.WriteLine($"Savings Balance: ${savings.Balance}");
        }
    }
}