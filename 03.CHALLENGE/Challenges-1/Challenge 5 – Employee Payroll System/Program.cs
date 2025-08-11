using System;

namespace Challenge_5___Employee_Payroll_System
{
    public class Employee
    {
        protected int id { get; set; }
        protected string Name { get; set; }
        protected decimal BaseSalary { get; set; }

        public Employee(int id, string Name, decimal BaseSalary)
        {
            this.id = id;
            this.Name = Name;
            this.BaseSalary = BaseSalary;
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Base class method");
        }
    }

    public class Fulltime : Employee
    {
        public Fulltime(int id, string Name, decimal BaseSalary):base(id,Name,BaseSalary)
        {
            Console.WriteLine($"Full Time Employee: {BaseSalary}");
        }

        public override void CalculatePay()
        {
            Console.WriteLine($"Monthly Pay: {Name}");
        }
    }

    public class Partime : Employee
    {
        private int HoursWorked;

        public Partime(int id, string Name, decimal BaseSalary, int HoursWorked) : base(id, Name, BaseSalary)
        {
            this.HoursWorked = HoursWorked;
            Console.WriteLine($"Part Time Employee: {((BaseSalary/160) * (HoursWorked))}");
        }

        public override void CalculatePay()
        {
            Console.WriteLine($"Monthly Pay: {Name}");
        }
    }

    public class Contract : Employee
    {
        private int HoursWorked;

        public Contract (int id, string Name, int HourlyBased, int HoursWorked) : base(id, Name,0.0m)
        {
            this.HoursWorked = HoursWorked;
            Console.WriteLine($"Contract Time Employee: {(HourlyBased*HoursWorked)}");
        }

        public override void CalculatePay()
        {
            Console.WriteLine($"Monthly Pay: {Name}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fulltime emp1 = new Fulltime(1, "Tamil", 50000m);
            Partime emp2 = new Partime(2, "Tamil", 20000m,120);
            Contract emp3 = new Contract(3,"Thillai",160,120);
        }
    }
}
