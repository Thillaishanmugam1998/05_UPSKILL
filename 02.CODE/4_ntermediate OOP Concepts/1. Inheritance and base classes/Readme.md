🎯 Topic 1 Complete: Inheritance and Base Classes
Key Concepts You Just Learned:
Inheritance allows you to create new classes based on existing classes. 
The new class (derived/child) inherits all the members of the base class (parent) and can add its own specific features.

Important Points:

Use : syntax for inheritance (class Car : Vehicle)
Derived classes must call base class constructor using base() keyword
protected members are accessible in derived classes but not from outside
IS-A relationship: A Car IS-A Vehicle, so you can treat a Car as a Vehicle
Single inheritance only - C# classes can inherit from only one base class

Best Practices:

Use inheritance for true "IS-A" relationships
Keep base classes focused and not too complex
Use protected for members that derived classes need access to
Always call base constructor explicitly for clarity

Real-world Benefits:

Code reuse (write common functionality once)
Consistent interface across related classes
Easy maintenance (change base class affects all derived classes)