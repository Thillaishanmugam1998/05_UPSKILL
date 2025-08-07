using System;
using System.Collections.Generic;

// TOPIC 4: INTERFACES AND INTERFACE IMPLEMENTATION
// Real-world analogy: Think of interfaces like contracts or job descriptions
// A "driver" interface defines what someone must be able to do to drive,
// but doesn't care if they're driving a car, truck, or motorcycle

// BASIC INTERFACE
// Interfaces define WHAT must be implemented, not HOW
// All members are implicitly public and abstract
public interface IVehicle
{
    // Properties - only declaration, no implementation
    string Brand { get; set; }
    int Year { get; set; }
    bool IsRunning { get; }

    // Methods - only signatures, no implementation
    void Start();
    void Stop();
    void Accelerate(int speed);

    // C# 8.0+ allows default implementations (optional)
    void DisplayInfo()
    {
        Console.WriteLine($"Vehicle: {Brand} ({Year}) - Running: {IsRunning}");
    }
}

// SPECIALIZED INTERFACES
public interface IFlyable
{
    int MaxAltitude { get; }
    void TakeOff();
    void Land();
    void Fly(int altitude);
}

public interface ISwimmable
{
    int MaxDepth { get; }
    void Dive();
    void Surface();
    void Swim(int depth);
}

// Interface for maintenance operations
public interface IMaintainable
{
    DateTime LastMaintenanceDate { get; set; }
    bool NeedsMaintenance { get; }
    void PerformMaintenance();
    void ScheduleMaintenance(DateTime date);
}

// IMPLEMENTING INTERFACES - Class can implement multiple interfaces
public class Car : IVehicle, IMaintainable
{
    // Private fields
    private string brand;
    private int year;
    private bool isRunning;
    private DateTime lastMaintenanceDate;

    // Properties required by IVehicle interface
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

    public bool IsRunning
    {
        get { return isRunning; }
    }

    // Properties required by IMaintainable interface
    public DateTime LastMaintenanceDate
    {
        get { return lastMaintenanceDate; }
        set { lastMaintenanceDate = value; }
    }

    public bool NeedsMaintenance
    {
        get { return DateTime.Now.Subtract(lastMaintenanceDate).TotalDays > 180; }
    }

    // Constructor
    public Car(string brand, int year)
    {
        this.brand = brand;
        this.year = year;
        this.isRunning = false;
        this.lastMaintenanceDate = DateTime.Now.AddDays(-100); // Default maintenance date
    }

    // MUST implement all IVehicle methods
    public void Start()
    {
        if (!isRunning)
        {
            isRunning = true;
            Console.WriteLine($"{brand} car engine started!");
        }
        else
        {
            Console.WriteLine($"{brand} car is already running");
        }
    }

    public void Stop()
    {
        if (isRunning)
        {
            isRunning = false;
            Console.WriteLine($"{brand} car engine stopped");
        }
        else
        {
            Console.WriteLine($"{brand} car is already stopped");
        }
    }

    public void Accelerate(int speed)
    {
        if (isRunning)
        {
            Console.WriteLine($"{brand} car accelerating to {speed} mph");
        }
        else
        {
            Console.WriteLine($"Cannot accelerate - {brand} car is not running!");
        }
    }

    // MUST implement all IMaintainable methods
    public void PerformMaintenance()
    {
        lastMaintenanceDate = DateTime.Now;
        Console.WriteLine($"{brand} car maintenance completed on {lastMaintenanceDate:MM/dd/yyyy}");
    }

    public void ScheduleMaintenance(DateTime date)
    {
        Console.WriteLine($"Maintenance scheduled for {brand} car on {date:MM/dd/yyyy}");
    }
}

// MULTIPLE INTERFACE IMPLEMENTATION - Airplane implements three interfaces
public class Airplane : IVehicle, IFlyable, IMaintainable
{
    private string brand;
    private int year;
    private bool isRunning;
    private int currentAltitude;
    private DateTime lastMaintenanceDate;

    // IVehicle properties
    public string Brand { get { return brand; } set { brand = value; } }
    public int Year { get { return year; } set { year = value; } }
    public bool IsRunning { get { return isRunning; } }

    // IFlyable properties
    public int MaxAltitude { get { return 35000; } } // Commercial airplane max altitude

    // IMaintainable properties
    public DateTime LastMaintenanceDate { get { return lastMaintenanceDate; } set { lastMaintenanceDate = value; } }
    public bool NeedsMaintenance { get { return DateTime.Now.Subtract(lastMaintenanceDate).TotalDays > 30; } } // More frequent for airplanes

    public int CurrentAltitude { get { return currentAltitude; } }

    public Airplane(string brand, int year)
    {
        this.brand = brand;
        this.year = year;
        this.isRunning = false;
        this.currentAltitude = 0;
        this.lastMaintenanceDate = DateTime.Now.AddDays(-15);
    }

    // IVehicle implementation
    public void Start()
    {
        if (!isRunning)
        {
            isRunning = true;
            Console.WriteLine($"{brand} airplane engines started - ready for takeoff!");
        }
    }

    public void Stop()
    {
        if (currentAltitude == 0) // Only stop on ground
        {
            isRunning = false;
            Console.WriteLine($"{brand} airplane engines stopped");
        }
        else
        {
            Console.WriteLine("Cannot stop engines while airborne!");
        }
    }

    public void Accelerate(int speed)
    {
        if (isRunning)
        {
            Console.WriteLine($"{brand} airplane accelerating to {speed} knots");
        }
    }

    // IFlyable implementation
    public void TakeOff()
    {
        if (isRunning && currentAltitude == 0)
        {
            currentAltitude = 1000;
            Console.WriteLine($"{brand} airplane taking off - now at {currentAltitude} feet");
        }
        else if (currentAltitude > 0)
        {
            Console.WriteLine("Already airborne!");
        }
        else
        {
            Console.WriteLine("Start engines first!");
        }
    }

    public void Land()
    {
        if (currentAltitude > 0)
        {
            currentAltitude = 0;
            Console.WriteLine($"{brand} airplane landed safely");
        }
        else
        {
            Console.WriteLine("Already on ground");
        }
    }

    public void Fly(int altitude)
    {
        if (currentAltitude > 0 && altitude <= MaxAltitude)
        {
            currentAltitude = altitude;
            Console.WriteLine($"{brand} airplane flying at {altitude} feet");
        }
        else if (altitude > MaxAltitude)
        {
            Console.WriteLine($"Cannot fly above maximum altitude of {MaxAltitude} feet");
        }
        else
        {
            Console.WriteLine("Must take off first!");
        }
    }

    // IMaintainable implementation
    public void PerformMaintenance()
    {
        if (currentAltitude == 0 && !isRunning)
        {
            lastMaintenanceDate = DateTime.Now;
            Console.WriteLine($"{brand} airplane underwent thorough maintenance - cleared for flight");
        }
        else
        {
            Console.WriteLine("Cannot perform maintenance while aircraft is operational");
        }
    }

    public void ScheduleMaintenance(DateTime date)
    {
        Console.WriteLine($"Maintenance scheduled for {brand} airplane on {date:MM/dd/yyyy}");
    }
}

// AMPHIBIOUS VEHICLE - Shows interface flexibility
public class AmphibiousVehicle : IVehicle, ISwimmable
{
    private string brand;
    private int year;
    private bool isRunning;
    private int currentDepth;
    private bool isInWater;

    // IVehicle implementation
    public string Brand { get { return brand; } set { brand = value; } }
    public int Year { get { return year; } set { year = value; } }
    public bool IsRunning { get { return isRunning; } }

    // ISwimmable implementation
    public int MaxDepth { get { return 50; } } // Maximum diving depth in feet

    public bool IsInWater { get { return isInWater; } }
    public int CurrentDepth { get { return currentDepth; } }

    public AmphibiousVehicle(string brand, int year)
    {
        this.brand = brand;
        this.year = year;
        this.isRunning = false;
        this.currentDepth = 0;
        this.isInWater = false;
    }

    // IVehicle methods
    public void Start()
    {
        isRunning = true;
        string mode = isInWater ? "marine" : "land";
        Console.WriteLine($"{brand} amphibious vehicle started in {mode} mode");
    }

    public void Stop()
    {
        isRunning = false;
        Console.WriteLine($"{brand} amphibious vehicle stopped");
    }

    public void Accelerate(int speed)
    {
        if (isRunning)
        {
            string unit = isInWater ? "knots" : "mph";
            Console.WriteLine($"{brand} accelerating to {speed} {unit}");
        }
    }

    // ISwimmable methods
    public void Dive()
    {
        if (isInWater)
        {
            currentDepth = Math.Min(10, MaxDepth);
            Console.WriteLine($"{brand} diving to {currentDepth} feet");
        }
        else
        {
            Console.WriteLine("Must be in water to dive!");
        }
    }

    public void Surface()
    {
        if (isInWater && currentDepth > 0)
        {
            currentDepth = 0;
            Console.WriteLine($"{brand} surfaced");
        }
    }

    public void Swim(int depth)
    {
        if (isInWater && depth <= MaxDepth)
        {
            currentDepth = depth;
            Console.WriteLine($"{brand} swimming at {depth} feet depth");
        }
    }

    // Unique method for mode switching
    public void EnterWater()
    {
        if (!isInWater)
        {
            isInWater = true;
            Console.WriteLine($"{brand} entered water - switching to marine mode");
        }
    }

    public void ExitWater()
    {
        if (isInWater && currentDepth == 0)
        {
            isInWater = false;
            Console.WriteLine($"{brand} exited water - switching to land mode");
        }
    }
}

// EXPLICIT INTERFACE IMPLEMENTATION
// Used when a class implements multiple interfaces with conflicting member names
public interface ILogger
{
    void Log(string message);
}

public interface IDisplay
{
    void Log(string message); // Same method name as ILogger!
}

public class FileManager : ILogger, IDisplay
{
    // Explicit implementation - can only be called through interface reference
    void ILogger.Log(string message)
    {
        Console.WriteLine($"[FILE LOG] {DateTime.Now}: {message}");
    }

    void IDisplay.Log(string message)
    {
        Console.WriteLine($"[DISPLAY] {message}");
    }

    // Regular public method
    public void SaveFile(string filename)
    {
        Console.WriteLine($"Saving file: {filename}");

        // To call explicit interface methods, cast to interface
        ((ILogger)this).Log($"File {filename} saved successfully");
        ((IDisplay)this).Log($"File saved: {filename}");
    }
}

// DEMONSTRATION CLASS
public class InterfaceDemo
{
    public static void RunDemo()
    {
        Console.WriteLine("=== INTERFACES AND INTERFACE IMPLEMENTATION DEMO ===\n");

        // Create objects that implement interfaces
        Car myCar = new Car("Tesla", 2023);
        Airplane myPlane = new Airplane("Boeing 737", 2020);
        AmphibiousVehicle amphibious = new AmphibiousVehicle("DUKW", 2022);

        Console.WriteLine("--- Testing Car (IVehicle + IMaintainable) ---");
        myCar.Start();
        myCar.Accelerate(60);
        //myCar.DisplayInfo(); // Using default interface implementation
        Console.WriteLine($"Needs maintenance: {myCar.NeedsMaintenance}");
        myCar.PerformMaintenance();
        myCar.Stop();

        Console.WriteLine("\n--- Testing Airplane (IVehicle + IFlyable + IMaintainable) ---");
        myPlane.Start();
        myPlane.TakeOff();
        myPlane.Fly(25000);
        myPlane.Land();
        myPlane.PerformMaintenance();
        myPlane.Stop();

        Console.WriteLine("\n--- Testing Amphibious Vehicle (IVehicle + ISwimmable) ---");
        amphibious.Start();
        amphibious.Accelerate(30);
        amphibious.EnterWater();
        amphibious.Dive();
        amphibious.Swim(25);
        amphibious.Surface();
        amphibious.ExitWater();
        amphibious.Stop();

        Console.WriteLine("\n=== POLYMORPHISM WITH INTERFACES ===");
        // Interface references can point to any implementing object
        IVehicle[] vehicles = { myCar, myPlane, amphibious };

        Console.WriteLine("\nStarting all vehicles:");
        foreach (IVehicle vehicle in vehicles)
        {
            vehicle.Start(); // Each uses its own implementation
            vehicle.DisplayInfo(); // Default interface implementation
        }

        Console.WriteLine("\nMaintaining maintainable vehicles:");
        foreach (IVehicle vehicle in vehicles)
        {
            // Check if the vehicle also implements IMaintainable
            if (vehicle is IMaintainable maintainable)
            {
                Console.WriteLine($"Checking {vehicle.Brand}: Needs maintenance = {maintainable.NeedsMaintenance}");
            }
        }

        Console.WriteLine("\n=== EXPLICIT INTERFACE IMPLEMENTATION ===");
        FileManager fileManager = new FileManager();
        fileManager.SaveFile("document.txt");

        // Direct calls to explicit interface methods
        ILogger logger = fileManager;
        IDisplay display = fileManager;
        logger.Log("This is a log message");
        display.Log("This is a display message");
    }
}

// INTERFACE BEST PRACTICES EXAMPLES
public class InterfaceBestPractices
{
    // Repository pattern using interfaces
    public interface IRepository<T>
    {
        void Add(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T item);
        void Delete(int id);
    }

    // Concrete implementation
    public class UserRepository : IRepository<string>
    {
        private Dictionary<int, string> users = new Dictionary<int, string>();
        private int nextId = 1;

        public void Add(string item)
        {
            users[nextId++] = item;
            Console.WriteLine($"Added user: {item}");
        }

        public string GetById(int id)
        {
            return users.ContainsKey(id) ? users[id] : null;
        }

        public IEnumerable<string> GetAll()
        {
            return users.Values;
        }

        public void Update(string item)
        {
            Console.WriteLine($"Updated user: {item}");
        }

        public void Delete(int id)
        {
            if (users.Remove(id))
                Console.WriteLine($"Deleted user with ID: {id}");
        }
    }

    public static void ShowBestPractices()
    {
        Console.WriteLine("\n=== INTERFACE BEST PRACTICES ===");

        // Program to interface, not implementation
        IRepository<string> userRepo = new UserRepository();
        userRepo.Add("John Doe");
        userRepo.Add("Jane Smith");

        Console.WriteLine("All users:");
        foreach (string user in userRepo.GetAll())
        {
            Console.WriteLine($"- {user}");
        }
    }
}

// PROGRAM ENTRY POINT
class Program
{
    static void Main(string[] args)
    {
        InterfaceDemo.RunDemo();
        InterfaceBestPractices.ShowBestPractices();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}