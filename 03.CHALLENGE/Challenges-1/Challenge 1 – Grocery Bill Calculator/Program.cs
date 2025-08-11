using System;

namespace Challenge_1___Grocery_Bill_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Apple price:");
            decimal apple_price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Apple Quantity:");
            int a_count = Convert.ToInt16(Console.ReadLine());

            Console.Write("Mango price:");
            decimal mango_price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Mango Quantity:");
            int m_amount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Potoato price:");
            decimal potoato_price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Potoato Quantity:");
            int p_count = Convert.ToInt32(Console.ReadLine());

            decimal total = (a_count * apple_price) + (m_amount * mango_price) + (p_count * potoato_price);

            if(total > 500)
            { 
                decimal discount = 10 / 100m;
                total = total - ( (total) * discount);
            }

            Console.Write($"Total Bill Amount: {total:F2}");

        }
    }
}
