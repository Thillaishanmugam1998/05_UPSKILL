using System;

namespace Challenge_4___Bank_Account_Management_System
{
    class BankAccount
    {
        private string accountNumber;
        private string accountHolderName;
        private decimal balance;

        public BankAccount(string accountNumber, string accountholdername, decimal balance)
        {
            this.accountHolderName = accountholdername;
            this.balance = balance;
            this.accountNumber = accountNumber;
            Console.WriteLine("Account was successfully created!!!");
            DisplayInfo();

        }

        private void DisplayInfo()
        {
            Console.WriteLine($"Bank Account Number: {accountNumber}");
            Console.WriteLine($"Bank Account Holder Name: {accountHolderName}");
            Console.WriteLine($"Balance: {balance}");
        }

        public void withdraw()
        {
            Console.Write("Enter Withdraw amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Successfully Withdraw!. New Balance is: {balance}");
            }
            else
            {
                Console.WriteLine("Insuffient Balance");
            }
        }

        public void Deposit()
        {
            Console.Write("Enter Deposit amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (amount > 0 )
            {
                balance += amount;
                Console.WriteLine($"Successfully Deposited!. New Balance is: {balance}");
            }
            else
            {
                Console.WriteLine("Invaliad amount");
            }
        }

        public void checkbalance()
        {
            Console.WriteLine($"Banlance:{balance:f2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount customer1 = new BankAccount("867523", "Tamilvani", 50000m);

            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("\nATM MENU:");
                Console.WriteLine("1. Check Balance:");
                Console.WriteLine("2. Deposit:");
                Console.WriteLine("3. Withdraw: ");
                Console.WriteLine("4. Exit: ");
                Console.Write("Enter Your Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        customer1.checkbalance();
                        break;
                    case 2:
                        customer1.Deposit();
                        break;
                    case 3:
                        customer1.withdraw();
                        break;
                    case 4:
                        isExit = true;
                        break;
                    default:
                        break;

                }

            }
        }
    }
}
