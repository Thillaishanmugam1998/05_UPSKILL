using System;

// TOPIC 1: INHERITANCE AND BASE CLASSES
// Real-world analogy: Think of inheritance like family relationships
// A "Vehicle" is a general concept, while "Car" and "Motorcycle" are specific types of vehicles

// BASE CLASS (also called Parent Class or Superclass)
// This contains common properties and methods that will be shared
public class Vehicle
{
    // Protected members can be accessed by derived classes but not from outside
    protected string brand;
    protected int year;

    // Public properties - accessible from anywhere
    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    // Constructor for the base class
    // This will be called when creating any derived class object
    public Vehicle(string brand, int year)
    {
        this.brand = brand;  // 'this' refers to the current instance
        this.year = year;
        Console.WriteLine($"Vehicle constructor called for {brand}");
    }

    // Virtual method - can be overridden by derived classes
    // We'll cover this more in the next topic
    public virtual void Start()
    {
        Console.WriteLine($"The {brand} vehicle is starting...");
    }

    // Regular method - inherited as-is by derived classes
    public void DisplayInfo()
    {
        Console.WriteLine($"Brand: {brand}, Year: {year}");
    }
}

// DERIVED CLASS (also called Child Class or Subclass)
// Inherits from Vehicle using the colon (:) syntax
public class Car : Vehicle
{
    // Additional property specific to cars
    private int numberOfDoors;

    public int NumberOfDoors
    {
        get { return numberOfDoors; }
        set { numberOfDoors = value; }
    }

    // Constructor for derived class
    // Must call base class constructor using 'base' keyword
    public Car(string brand, int year, int doors) : base(brand, year)
    {
       
        this.numberOfDoors = doors;
        Console.WriteLine($"Car constructor called - added {doors} doors");
    }

    // Method specific to Car class
    public void OpenTrunk()
    {
        Console.WriteLine($"Opening trunk of {brand} car");
    }

    // We can access protected members from base class
    public void ShowCarDetails()
    {
        // 'brand' and 'year' are accessible because they're protected in base class
        Console.WriteLine($"Car Details: {brand} ({year}) with {numberOfDoors} doors");
    }
}

// Another derived class to show inheritance flexibility 
public class Motorcycle : Vehicle
{
    private bool hasSidecar;

    public bool HasSidecar
    {
        get { return hasSidecar; }
        set { hasSidecar = value; }
    }

    // Constructor chains to base class constructor
    public Motorcycle(string brand, int year, bool sidecar) : base(brand, year)
    {
        this.hasSidecar = sidecar;
        Console.WriteLine($"Motorcycle constructor called - sidecar: {sidecar}");
    }

    // Method specific to Motorcycle
    public void DoWheelie()
    {
        if (!hasSidecar)
            Console.WriteLine($"The {brand} motorcycle is doing a wheelie!");
        else
            Console.WriteLine($"Can't do wheelie with a sidecar attached!");
    }
}

// DEMONSTRATION CLASS
public class InheritanceDemo
{
    public static void RunDemo()
    {
        Console.WriteLine("=== INHERITANCE AND BASE CLASSES DEMO ===\n");

        // Create a Car object
        // Notice: Constructor chaining happens (Vehicle constructor, then Car constructor)
        Car myCar = new Car("Toyota", 2022, 4);

        // Car has access to its own methods
        myCar.OpenTrunk();
        myCar.ShowCarDetails();

        // Car also has access to inherited methods from Vehicle
        myCar.DisplayInfo();  // Inherited from Vehicle
        myCar.Start();        // Inherited from Vehicle

        Console.WriteLine(); // Empty line for spacing

        // Create a Motorcycle object
        Motorcycle myBike = new Motorcycle("Harley-Davidson", 2021, false);

        // Motorcycle has its own methods
        myBike.DoWheelie();

        // Motorcycle also inherits from Vehicle
        myBike.DisplayInfo();  // Inherited method
        myBike.Start();        // Inherited method

        Console.WriteLine();

        // Demonstrate that derived classes ARE their base class type
        // This is fundamental to understanding polymorphism (covered later)
        Vehicle someVehicle = new Car("BMW", 2023, 2);  // Car IS-A Vehicle
        someVehicle.Start();        // Can call Vehicle methods
        someVehicle.DisplayInfo();  // Can call Vehicle methods
        //someVehicle.OpenTrunk();  // ERROR! Vehicle doesn't know about Car-specific methods
    }
}

// PROGRAM ENTRY POINT
class Program
{
    static void Main(string[] args)
    {
        InheritanceDemo.RunDemo();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}