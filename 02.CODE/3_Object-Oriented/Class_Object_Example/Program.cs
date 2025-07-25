using System;

// Class definition - blueprint for creating objects
public class Student
{
    // Fields (data members)
    public string name;
    public int age;
    public string studentId;
    public double gpa;

    // Method to display student information
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Student ID: {studentId}");
        Console.WriteLine($"GPA: {gpa:F2}");
        Console.WriteLine("------------------------");
    }

    // Method to calculate if student is eligible for honors
    public bool IsEligibleForHonors()
    {
        return gpa >= 3.5;
    }

    // Method to update GPA
    public void UpdateGPA(double newGPA)
    {
        if (newGPA >= 0.0 && newGPA <= 4.0)
        {
            gpa = newGPA;
            Console.WriteLine($"GPA updated to {gpa:F2}");
        }
        else
        {
            Console.WriteLine("Invalid GPA. Must be between 0.0 and 4.0");
        }
    }
}

// Another class example - Car
public class Car
{
    public string make;
    public string model;
    public int year;
    public string color;
    public double mileage;
    public bool isRunning;

    public void StartEngine()
    {
        if (!isRunning)
        {
            isRunning = true;
            Console.WriteLine($"The {year} {make} {model} engine is now running.");
        }
        else
        {
            Console.WriteLine("Engine is already running.");
        }
    }

    public void StopEngine()
    {
        if (isRunning)
        {
            isRunning = false;
            Console.WriteLine($"The {year} {make} {model} engine has been turned off.");
        }
        else
        {
            Console.WriteLine("Engine is already off.");
        }
    }

    public void Drive(double miles)
    {
        if (isRunning && miles > 0)
        {
            mileage += miles;
            Console.WriteLine($"Drove {miles} miles. Total mileage: {mileage}");
        }
        else if (!isRunning)
        {
            Console.WriteLine("Cannot drive. Engine is not running.");
        }
        else
        {
            Console.WriteLine("Invalid distance.");
        }
    }

    public void DisplayCarInfo()
    {
        Console.WriteLine($"Car: {year} {make} {model}");
        Console.WriteLine($"Color: {color}");
        Console.WriteLine($"Mileage: {mileage} miles");
        Console.WriteLine($"Engine Status: {(isRunning ? "Running" : "Off")}");
        Console.WriteLine("------------------------");
    }
}

class ClassesAndObjectsDemo
{
    static void Main()
    {
        Console.WriteLine("=== CLASSES AND OBJECTS DEMO ===\n");

        // 1. Creating objects (instantiation)
        Console.WriteLine("1. Creating Student Objects:");

        // Create first student object
        Student student1 = new Student();
        student1.name = "Alice Johnson";
        student1.age = 20;
        student1.studentId = "STU001";
        student1.gpa = 3.8;

        // Create second student object
        Student student2 = new Student();
        student2.name = "Bob Smith";
        student2.age = 19;
        student2.studentId = "STU002";
        student2.gpa = 3.2;

        // Display student information
        Console.WriteLine("Student 1 Information:");
        student1.DisplayInfo();

        Console.WriteLine("Student 2 Information:");
        student2.DisplayInfo();

        // 2. Using object methods
        Console.WriteLine("2. Using Object Methods:");

        Console.WriteLine($"Is {student1.name} eligible for honors? {student1.IsEligibleForHonors()}");
        Console.WriteLine($"Is {student2.name} eligible for honors? {student2.IsEligibleForHonors()}");

        // Update GPA
        Console.WriteLine($"\nUpdating {student2.name}'s GPA:");
        student2.UpdateGPA(3.6);
        Console.WriteLine($"Now eligible for honors? {student2.IsEligibleForHonors()}");

        // 3. Working with Car objects
        Console.WriteLine("\n3. Working with Car Objects:");

        // Create car objects
        Car car1 = new Car();
        car1.make = "Toyota";
        car1.model = "Camry";
        car1.year = 2022;
        car1.color = "Blue";
        car1.mileage = 15000;
        car1.isRunning = false;

        Car car2 = new Car();
        car2.make = "Honda";
        car2.model = "Civic";
        car2.year = 2021;
        car2.color = "Red";
        car2.mileage = 25000;
        car2.isRunning = false;

        // Display initial car information
        Console.WriteLine("Initial Car Information:");
        car1.DisplayCarInfo();
        car2.DisplayCarInfo();

        // Demonstrate car operations
        Console.WriteLine("Car Operations:");
        car1.StartEngine();
        car1.Drive(50);
        car1.DisplayCarInfo();

        car2.Drive(30); // This should fail - engine not running
        car2.StartEngine();
        car2.Drive(30); // This should work
        car2.StopEngine();

        // 4. Multiple objects of the same class
        Console.WriteLine("\n4. Multiple Objects Demonstration:");

        Student[] students = new Student[3];

        // Create multiple student objects
        for (int i = 0; i < students.Length; i++)
        {
            students[i] = new Student();
            students[i].name = $"Student {i + 1}";
            students[i].age = 18 + i;
            students[i].studentId = $"STU{(i + 1):D3}";
            students[i].gpa = 2.5 + (i * 0.3);
        }

        // Display all students
        Console.WriteLine("All Students:");
        foreach (Student student in students)
        {
            student.DisplayInfo();
        }

        // Count honors students
        int honorsCount = 0;
        foreach (Student student in students)
        {
            if (student.IsEligibleForHonors())
            {
                honorsCount++;
            }
        }

        Console.WriteLine($"Number of students eligible for honors: {honorsCount}");

        // 5. Object independence demonstration
        Console.WriteLine("\n5. Object Independence:");

        Student original = new Student();
        original.name = "Original Student";
        original.gpa = 3.0;

        Student copy = new Student();
        copy.name = "Copy Student";
        copy.gpa = 3.0;

        Console.WriteLine("Before modifying:");
        Console.WriteLine($"Original GPA: {original.gpa}");
        Console.WriteLine($"Copy GPA: {copy.gpa}");

        // Modify one object
        original.UpdateGPA(4.0);

        Console.WriteLine("After modifying original:");
        Console.WriteLine($"Original GPA: {original.gpa}");
        Console.WriteLine($"Copy GPA: {copy.gpa}");
        Console.WriteLine("Objects are independent - changing one doesn't affect the other");
    }
}