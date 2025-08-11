using System;

namespace Challenge_2___Student_Grade_Evaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] marks = new int[5];
            int total = 0;
            int percentage = 0;
            string Grade;
            string result;

            for (int i = 0; i <marks.Length; i++)
            {
                Console.Write($"Enter Mark[{i+1}]:");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int j = 0; j < marks.Length; j++) 
            {
                total = total + marks[j];
            }

            percentage = ((total / 5));

            if (percentage >= 90 && percentage <=100)
            {
                Grade = "A+";
            }
            else if (percentage >=80 && percentage <=89)
            {
                Grade = "A";
            }
            else if (percentage >= 70 && percentage <= 79)
            {
                Grade = "B";
            }
            else if (percentage >= 60 && percentage <= 69)
            {
                Grade = "C";
            }
            else
            {
                Grade = "Fail";
            }

            result = Grade.Contains("Fail") ? "Fail": "Pass";
            Console.WriteLine($"Percentage: {percentage}");
            Console.WriteLine($"Grade: {Grade}");
            Console.WriteLine($"Result: {result}");

        }
    }
}
