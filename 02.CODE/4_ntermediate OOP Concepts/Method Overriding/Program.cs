using System;

// TOPIC 2: METHOD OVERRIDING (virtual, override)
// Real-world analogy: Different animals make different sounds, but they all "make a sound"
// The base behavior exists, but each type has its own specific implementation

// BASE CLASS with virtual methods
public class Animal
{
    protected string name;
    protected string species;

    public string Name { get { return name; } }
    public string Species { get { return species; } }

    public Animal(string name, string species)
    {
        this.name = name;
        this.species = species;
    }

    // VIRTUAL METHOD - Can be overridden by derived classes
    // The 'virtual' keyword allows derived classes to provide their own implementation
    public virtual void MakeSound()
    {
        Console.WriteLine($"{name} the {species} makes a generic animal sound");
    }

    // Another virtual method to demonstrate overriding
    public virtual void Move()
    {
        Console.WriteLine($"{name} moves in a basic way");
    }

    // Regular (non-virtual) method - CANNOT be overridden
    // This will be inherited as-is by all derived classes
    public void Sleep()
    {
        Console.WriteLine($"{name} is sleeping peacefully");
    }

    // Virtual method that provides base functionality
    // Derived classes can extend this behavior using base.MethodName()
    public virtual void Eat(string food)
    {
        Console.WriteLine($"{name} is eating {food}");
    }
}

// DERIVED CLASS - Dog
public class Dog : Animal
{
    private string breed;

    public string Breed { get { return breed; } }

    // Constructor calls base constructor
    public Dog(string name, string breed) : base(name, "Dog")
    {
        this.breed = breed;
    }

    // OVERRIDE - Provides Dog-specific implementation
    // The 'override' keyword is required when overriding virtual methods
    public override void MakeSound()
    {
        Console.WriteLine($"{name} the {breed} barks: Woof! Woof!");
    }

    // Override with different behavior
    public override void Move()
    {
        Console.WriteLine($"{name} runs around wagging its tail");
    }

    // Override that EXTENDS base functionality using base.MethodName()
    public override void Eat(string food)
    {
        // Call the base class implementation first
        base.Eat(food);
        // Then add Dog-specific behavior
        Console.WriteLine($"{name} wags tail happily after eating");
    }
}

// DERIVED CLASS - Cat
public class Cat : Animal
{
    private bool isIndoor;

    public bool IsIndoor { get { return isIndoor; } }

    public Cat(string name, bool indoor) : base(name, "Cat")
    {
        this.isIndoor = indoor;
    }

    // Different override implementation for Cat
    public override void MakeSound()
    {
        Console.WriteLine($"{name} the cat meows: Meow... meow...");
    }

    public override void Move()
    {
        if (isIndoor)
            Console.WriteLine($"{name} gracefully jumps from furniture to furniture");
        else
            Console.WriteLine($"{name} prowls through the neighborhood");
    }

    // Cat doesn't override Eat(), so it will use the base Animal.Eat() method
}

// DERIVED CLASS - Bird (shows more complex overriding)
public class Bird : Animal
{
    private bool canFly;

    public bool CanFly { get { return canFly; } }

    public Bird(string name, string birdType, bool canFly) : base(name, birdType)
    {
        this.canFly = canFly;
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{name} the {species} chirps: Tweet tweet!");
    }

    public override void Move()
    {
        if (canFly)
            Console.WriteLine($"{name} soars through the sky");
        else
            Console.WriteLine($"{name} walks and hops on the ground");
    }

    // Override with conditional base call
    public override void Eat(string food)
    {
        Console.WriteLine($"{name} pecks at {food}");
        // Only call base if it's seeds (just an example of conditional base calling)
        if (food.ToLower().Contains("seed"))
        {
            base.Eat(food); // This would print the base eating message too
        }
    }
}

// DEMONSTRATION CLASS
public class MethodOverridingDemo
{
    public static void RunDemo()
    {
        Console.WriteLine("=== METHOD OVERRIDING (virtual, override) DEMO ===\n");

        // Create different animals
        Dog myDog = new Dog("Buddy", "Golden Retriever");
        Cat myCat = new Cat("Whiskers", true);
        Bird myBird = new Bird("Tweety", "Canary", true);
        Bird myPenguin = new Bird("Pingu", "Penguin", false);

        Console.WriteLine("--- Testing MakeSound() Override ---");
        // Each animal makes its own specific sound due to method overriding
        myDog.MakeSound();    // Dog's version: "Woof! Woof!"
        myCat.MakeSound();    // Cat's version: "Meow... meow..."
        myBird.MakeSound();   // Bird's version: "Tweet tweet!"
        myPenguin.MakeSound(); // Also Bird's version

        Console.WriteLine("\n--- Testing Move() Override ---");
        myDog.Move();         // Dog-specific movement
        myCat.Move();         // Indoor cat movement
        myBird.Move();        // Flying bird movement
        myPenguin.Move();     // Non-flying bird movement

        Console.WriteLine("\n--- Testing Sleep() - Non-Virtual Method ---");
        // Sleep() is NOT virtual, so all animals use the same base implementation
        myDog.Sleep();        // Same message for all
        myCat.Sleep();        // Same message for all
        myBird.Sleep();       // Same message for all

        Console.WriteLine("\n--- Testing Eat() with base.Method() calls ---");
        myDog.Eat("dog food");      // Calls base.Eat() then adds dog behavior
        myCat.Eat("fish");          // Uses base Animal.Eat() only (no override)
        myBird.Eat("bird seeds");   // Custom implementation with conditional base call

        Console.WriteLine("\n--- Polymorphism Preview ---");
        // This demonstrates polymorphism (covered in detail later)
        // We can treat all animals as Animal type, but they still use their overridden methods
        Animal[] animals = { myDog, myCat, myBird, myPenguin };

        Console.WriteLine("All animals making sounds:");
        foreach (Animal animal in animals)
        {
            // Even though we're calling through Animal reference,
            // each object uses its own overridden MakeSound() method
            animal.MakeSound(); // This is POLYMORPHISM in action!
        }
    }
}

// ADDITIONAL EXAMPLES: Method Overriding Best Practices
public class OverridingBestPractices
{
    // Example of a well-designed base class for overriding
    public abstract class Shape  // We'll cover abstract in the next topic
    {
        protected double x, y; // Position

        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Virtual method that provides default behavior
        public virtual void Draw()
        {
            Console.WriteLine($"Drawing shape at ({x}, {y})");
        }

        // Virtual method that MUST be overridden for meaningful behavior
        public virtual double CalculateArea()
        {
            return 0; // Default "unknown" area
        }

        // Template method pattern - calls virtual methods
        public void Display()
        {
            Draw();
            Console.WriteLine($"Area: {CalculateArea():F2}");
        }
    }

    public class Circle : Shape
    {
        private double radius;

        public Circle(double x, double y, double radius) : base(x, y)
        {
            this.radius = radius;
        }

        // Override to provide Circle-specific drawing
        public override void Draw()
        {
            base.Draw(); // Call base implementation first
            Console.WriteLine($"  -> Circle with radius {radius}");
        }

        // Override to provide actual area calculation
        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }
    }

    public static void ShowBestPractices()
    {
        Console.WriteLine("\n=== METHOD OVERRIDING BEST PRACTICES ===");
        Circle circle = new Circle(10, 20, 5);
        circle.Display(); // Uses both overridden methods
    }
}

// PROGRAM ENTRY POINT
class Program
{
    static void Main(string[] args)
    {
        MethodOverridingDemo.RunDemo();
        OverridingBestPractices.ShowBestPractices();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}