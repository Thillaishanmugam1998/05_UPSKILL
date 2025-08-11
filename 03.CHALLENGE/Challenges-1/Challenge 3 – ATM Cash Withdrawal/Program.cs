using System;

namespace Challenge_3___ATM_Cash_Withdrawal
{
    public class BankInfo
    {
        public decimal amount = 10000;
        public void CheckBalance()
        {
            Console.Write($"Balance: {amount}");
        }

        public void Withdraw()
        {
            Console.Write("Enter Withdraw amount: ");
            decimal w_amount = Convert.ToDecimal(Console.ReadLine());

            if(w_amount<= amount)
            {
               amount = amount - w_amount;
               Console.WriteLine($"Withdrawal successful. New Balance: Rs {amount}/-");
            }
            else
            {
                Console.WriteLine($"Withdrawal failed.");
            }

        }

        public void Deposit()
        {
            Console.Write("Enter Deposit amount: ");
            decimal d_amount = Convert.ToDecimal(Console.ReadLine());

            if (d_amount > 0)
            {
               amount = amount + d_amount;
               Console.WriteLine($"Deposit successful. New Balance: Rs {amount}/-");
            }
            else
            {
                Console.WriteLine($"Deposit Failed.");
            }
        }
    }
    class Program
    {
        

        static void Main(string[] args)
        {
            bool isExit = false;
            BankInfo bank = new BankInfo();

            while (!isExit)
            {
                Console.WriteLine("\nATM MENU:");
                Console.WriteLine("1. Check Balance:");
                Console.WriteLine("2. Deposit:");
                Console.WriteLine("3. Withdraw: ");
                Console.WriteLine("4. Exit: ");
                Console.Write("Enter Your Choice: ");
                int choice = Convert.ToInt16(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        bank.CheckBalance();
                        break;
                    case 2:
                        bank.Deposit();
                        break;
                    case 3:
                        bank.Withdraw();
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
