using System;
using System.Collections.Generic;

// TOPIC 5: POLYMORPHISM
// Real-world analogy: Think of a remote control
// The same "Play" button works differently for TV, DVD player, or music system,
// but you use the same interface (the button) for all of them

// POLYMORPHISM means "many forms" - the ability for objects of different types
// to be treated as instances of the same type through a common interface

// BASE CLASS for demonstrating inheritance-based polymorphism
public abstract class Shape
{
    protected string name;
    protected string color;

    public string Name { get { return name; } }
    public string Color { get { return color; } set { color = value; } }

    public Shape(string name, string color)
    {
        this.name = name;
        this.color = color;
    }

    // VIRTUAL METHOD - Can be overridden (Runtime Polymorphism)
    public virtual void Draw()
    {
        Console.WriteLine($"Drawing a {color} {name}");
    }

    // ABSTRACT METHOD - Must be overridden (Pure Polymorphism)
    public abstract double CalculateArea();

    // VIRTUAL METHOD - Default implementation that can be customized
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Shape: {name}, Color: {color}, Area: {CalculateArea():F2}");
    }

    // Template method that uses polymorphic behavior
    public void ProcessShape()
    {
        Draw();           // Calls overridden version
        DisplayInfo();    // Calls overridden version
        Console.WriteLine($"Area calculation: {CalculateArea():F2}"); // Calls overridden version
    }
}

// DERIVED CLASSES demonstrating polymorphic behavior
public class Circle : Shape
{
    private double radius;

    public double Radius { get { return radius; } set { radius = value; } }

    public Circle(double radius, string color) : base("Circle", color)
    {
        this.radius = radius;
    }

    // OVERRIDE virtual method - Runtime Polymorphism
    public override void Draw()
    {
        Console.WriteLine($"🔵 Drawing a {color} circle with radius {radius}");
    }

    // MUST override abstract method
    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    // Override virtual method with additional behavior
    public override void DisplayInfo()
    {
        base.DisplayInfo(); // Call base implementation
        Console.WriteLine($"   Radius: {radius}, Circumference: {2 * Math.PI * radius:F2}");
    }
}

public class Rectangle : Shape
{
    private double width;
    private double height;

    public double Width { get { return width; } set { width = value; } }
    public double Height { get { return height; } set { height = value; } }

    public Rectangle(double width, double height, string color) : base("Rectangle", color)
    {
        this.width = width;
        this.height = height;
    }

    // OVERRIDE - Different implementation for rectangles
    public override void Draw()
    {
        Console.WriteLine($"⬜ Drawing a {color} rectangle {width}x{height}");
    }

    public override double CalculateArea()
    {
        return width * height;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"   Dimensions: {width}x{height}, Perimeter: {2 * (width + height):F2}");
    }
}

public class Triangle : Shape
{
    private double baseLength;
    private double heightValue;

    public double BaseLength { get { return baseLength; } set { baseLength = value; } }
    public double HeightValue { get { return heightValue; } set { heightValue = value; } }

    public Triangle(double baseLength, double height, string color) : base("Triangle", color)
    {
        this.baseLength = baseLength;
        this.heightValue = height;
    }

    public override void Draw()
    {
        Console.WriteLine($"🔺 Drawing a {color} triangle with base {baseLength} and height {heightValue}");
    }

    public override double CalculateArea()
    {
        return 0.5 * baseLength * heightValue;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"   Base: {baseLength}, Height: {heightValue}");
    }
}

// INTERFACE-BASED POLYMORPHISM
// Different classes can implement the same interface in different ways
public interface IDrawable
{
    void Draw();
    void Erase();
}

public interface IResizable
{
    void Resize(double factor);
    double GetSize();
}

public interface IMovable
{
    void MoveTo(int x, int y);
    (int X, int Y) GetPosition();
}

// MULTIPLE INTERFACE IMPLEMENTATION showing polymorphism
public class DrawableCircle : IDrawable, IResizable, IMovable
{
    private double radius;
    private int x, y;
    private string color;

    public DrawableCircle(double radius, string color, int x = 0, int y = 0)
    {
        this.radius = radius;
        this.color = color;
        this.x = x;
        this.y = y;
    }

    // IDrawable implementation
    public void Draw()
    {
        Console.WriteLine($"Drawing {color} circle at ({x},{y}) with radius {radius}");
    }

    public void Erase()
    {
        Console.WriteLine($"Erasing circle at ({x},{y})");
    }

    // IResizable implementation
    public void Resize(double factor)
    {
        radius *= factor;
        Console.WriteLine($"Circle resized by factor {factor}, new radius: {radius:F2}");
    }

    public double GetSize()
    {
        return Math.PI * radius * radius; // Return area as size
    }

    // IMovable implementation
    public void MoveTo(int newX, int newY)
    {
        Console.WriteLine($"Moving circle from ({x},{y}) to ({newX},{newY})");
        x = newX;
        y = newY;
    }

    public (int X, int Y) GetPosition()
    {
        return (x, y);
    }
}

public class DrawableRectangle : IDrawable, IResizable, IMovable
{
    private double width, height;
    private int x, y;
    private string color;

    public DrawableRectangle(double width, double height, string color, int x = 0, int y = 0)
    {
        this.width = width;
        this.height = height;
        this.color = color;
        this.x = x;
        this.y = y;
    }

    // IDrawable - Different implementation than Circle
    public void Draw()
    {
        Console.WriteLine($"Drawing {color} rectangle at ({x},{y}) - {width}x{height}");
    }

    public void Erase()
    {
        Console.WriteLine($"Erasing rectangle at ({x},{y})");
    }

    // IResizable - Different algorithm than Circle
    public void Resize(double factor)
    {
        width *= factor;
        height *= factor;
        Console.WriteLine($"Rectangle resized by factor {factor} - new size: {width:F2}x{height:F2}");
    }

    public double GetSize()
    {
        return width * height; // Area for rectangles
    }

    // IMovable - Same interface, different object
    public void MoveTo(int newX, int newY)
    {
        Console.WriteLine($"Moving rectangle from ({x},{y}) to ({newX},{newY})");
        x = newX;
        y = newY;
    }

    public (int X, int Y) GetPosition()
    {
        return (x, y);
    }
}

// POLYMORPHIC COLLECTIONS AND METHODS
public class GraphicsEngine
{
    // Method that works with ANY IDrawable object (Polymorphism!)
    public static void RenderObject(IDrawable drawable)
    {
        Console.WriteLine("--- Rendering Object ---");
        drawable.Draw(); // Calls the specific implementation
        Console.WriteLine("--- Render Complete ---\n");
    }

    // Method that works with ANY IResizable object
    public static void ScaleObject(IResizable resizable, double factor)
    {
        Console.WriteLine($"Original size: {resizable.GetSize():F2}");
        resizable.Resize(factor);
        Console.WriteLine($"New size: {resizable.GetSize():F2}\n");
    }

    // Method that works with collections of polymorphic objects
    public static void ProcessShapes(List<Shape> shapes)
    {
        Console.WriteLine("=== PROCESSING SHAPE COLLECTION ===");

        double totalArea = 0;
        foreach (Shape shape in shapes)
        {
            // Each shape uses its own implementation (Polymorphism!)
            shape.ProcessShape();
            totalArea += shape.CalculateArea();
            Console.WriteLine();
        }

        Console.WriteLine($"Total area of all shapes: {totalArea:F2}");
    }

    // Generic method demonstrating polymorphism with interfaces
    public static void AnimateObjects<T>(List<T> objects) where T : IMovable, IDrawable
    {
        Console.WriteLine("=== ANIMATING OBJECTS ===");
        Random random = new Random();

        foreach (T obj in objects)
        {
            // Draw at current position
            obj.Draw();

            // Move to random position
            int newX = random.Next(0, 100);
            int newY = random.Next(0, 100);
            obj.MoveTo(newX, newY);

            // Draw at new position
            obj.Draw();
            Console.WriteLine();
        }
    }
}

// POLYMORPHISM DEMO CLASS
public class PolymorphismDemo
{
    public static void RunDemo()
    {
        Console.WriteLine("=== POLYMORPHISM DEMONSTRATION ===\n");

        Console.WriteLine("--- 1. INHERITANCE-BASED POLYMORPHISM ---");

        // Create different shapes, but treat them all as Shape (base class)
        Shape[] shapes = {
            new Circle(5.0, "Red"),
            new Rectangle(4.0, 6.0, "Blue"),
            new Triangle(8.0, 3.0, "Green"),
            new Circle(3.0, "Yellow")
        };

        // Polymorphism in action: Same method call, different behavior
        Console.WriteLine("Drawing all shapes:");
        foreach (Shape shape in shapes)
        {
            shape.Draw(); // Each shape draws differently!
        }

        Console.WriteLine("\nCalculating areas:");
        foreach (Shape shape in shapes)
        {
            // Same method call, different calculations!
            Console.WriteLine($"{shape.Name}: {shape.CalculateArea():F2}");
        }

        Console.WriteLine("\n--- 2. INTERFACE-BASED POLYMORPHISM ---");

        // Create objects that implement common interfaces
        DrawableCircle circle = new DrawableCircle(4.0, "Purple", 10, 20);
        DrawableRectangle rectangle = new DrawableRectangle(6.0, 8.0, "Orange", 30, 40);

        // Polymorphism through interfaces
        IDrawable[] drawables = { circle, rectangle };
        IResizable[] resizables = { circle, rectangle };
        IMovable[] movables = { circle, rectangle };

        Console.WriteLine("Using IDrawable interface:");
        foreach (IDrawable drawable in drawables)
        {
            GraphicsEngine.RenderObject(drawable); // Same method, different behavior
        }

        Console.WriteLine("Using IResizable interface:");
        foreach (IResizable resizable in resizables)
        {
            GraphicsEngine.ScaleObject(resizable, 1.5); // Same method, different scaling
        }

        Console.WriteLine("--- 3. POLYMORPHIC COLLECTIONS ---");

        List<Shape> shapeList = new List<Shape>
        {
            new Circle(2.5, "Cyan"),
            new Rectangle(3.0, 4.0, "Magenta"),
            new Triangle(5.0, 6.0, "Pink")
        };

        GraphicsEngine.ProcessShapes(shapeList);

        Console.WriteLine("\n--- 4. GENERIC POLYMORPHISM ---");

        List<IMovable> movableObjects = new List<IMovable> { circle, rectangle };
        // This won't work because we need both IMovable AND IDrawable
        // GraphicsEngine.AnimateObjects(movableObjects);

        // Create a list that satisfies both constraints
        var animatableObjects = new List<DrawableCircle> {
            new DrawableCircle(2.0, "Gold", 0, 0),
            new DrawableCircle(3.0, "Silver", 50, 50)
        };

        // This works because DrawableCircle implements both IMovable and IDrawable
        GraphicsEngine.AnimateObjects(animatableObjects);

        Console.WriteLine("--- 5. RUNTIME TYPE CHECKING ---");
        DemonstrateRuntimePolymorphism(shapes);
    }

    // Demonstrate runtime type checking and casting
    private static void DemonstrateRuntimePolymorphism(Shape[] shapes)
    {
        Console.WriteLine("=== RUNTIME TYPE CHECKING ===");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"\nProcessing {shape.Name}:");

            // Use 'is' operator for type checking
            if (shape is Circle circle)
            {
                Console.WriteLine($"  This is a circle with radius: {circle.Radius}");
                Console.WriteLine($"  Circumference: {2 * Math.PI * circle.Radius:F2}");
            }
            else if (shape is Rectangle rectangle)
            {
                Console.WriteLine($"  This is a rectangle {rectangle.Width}x{rectangle.Height}");
                Console.WriteLine($"  Perimeter: {2 * (rectangle.Width + rectangle.Height):F2}");
            }
            else if (shape is Triangle triangle)
            {
                Console.WriteLine($"  This is a triangle with base {triangle.BaseLength} and height {triangle.HeightValue}");
            }

            // Using 'as' operator for safe casting
            Circle asCircle = shape as Circle;
            if (asCircle != null)
            {
                Console.WriteLine($"  Successfully cast to Circle - radius is {asCircle.Radius}");
            }

            // Pattern matching (C# 7.0+)
            switch (shape)
            {
                case Circle c when c.Radius > 4:
                    Console.WriteLine($"  Large circle detected!");
                    break;
                case Rectangle r when r.Width == r.Height:
                    Console.WriteLine($"  This rectangle is actually a square!");
                    break;
                case Triangle t when t.BaseLength == t.HeightValue:
                    Console.WriteLine($"  This triangle has equal base and height!");
                    break;
                default:
                    Console.WriteLine($"  Standard {shape.Name}");
                    break;
            }
        }
    }
}

// ADVANCED POLYMORPHISM CONCEPTS
public class AdvancedPolymorphismExamples
{
    // Example: Strategy Pattern using polymorphism
    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount);
        string GetPaymentMethod();
    }

    public class CreditCardProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing ${amount:C} via Credit Card");
            return true; // Simulate successful payment
        }

        public string GetPaymentMethod() => "Credit Card";
    }

    public class PayPalProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing ${amount:C} via PayPal");
            return true; // Simulate successful payment
        }

        public string GetPaymentMethod() => "PayPal";
    }

    public class PaymentService
    {
        // Polymorphism: Works with any IPaymentProcessor implementation
        public void ProcessOrder(decimal amount, IPaymentProcessor processor)
        {
            Console.WriteLine($"Processing order for ${amount:C}");
            Console.WriteLine($"Payment method: {processor.GetPaymentMethod()}");

            if (processor.ProcessPayment(amount))
            {
                Console.WriteLine("Order completed successfully!");
            }
            else
            {
                Console.WriteLine("Payment failed!");
            }
        }
    }

    public static void DemonstrateStrategyPattern()
    {
        Console.WriteLine("\n=== STRATEGY PATTERN WITH POLYMORPHISM ===");

        PaymentService service = new PaymentService();

        // Same service method, different payment processors (Polymorphism!)
        service.ProcessOrder(99.99m, new CreditCardProcessor());
        Console.WriteLine();
        service.ProcessOrder(149.99m, new PayPalProcessor());
    }
}

// PROGRAM ENTRY POINT
class Program
{
    static void Main(string[] args)
    {
        PolymorphismDemo.RunDemo();
        AdvancedPolymorphismExamples.DemonstrateStrategyPattern();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}