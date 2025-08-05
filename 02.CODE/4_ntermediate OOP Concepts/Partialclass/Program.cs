using System;
using System.Collections.Generic;
using System.ComponentModel;

// =============================================================================
// TOPIC 7: PARTIAL CLASSES AND METHODS
// =============================================================================

// WHAT ARE PARTIAL CLASSES AND METHODS?
// Partial classes allow you to split a single class definition across multiple files
// Partial methods allow you to define a method signature in one part and implement it in another
// Real-world analogy: Like a book written by multiple authors, where each author writes different chapters

// =============================================================================
// 1. PARTIAL CLASSES - BASIC EXAMPLE
// =============================================================================

// File 1: Employee.Business.cs (imagine this is in a separate file)
public partial class Employee
{
    // Business logic properties
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }

    // Business logic methods
    public void CalculateBonus()
    {
        Console.WriteLine($"Calculating bonus for {FirstName} {LastName}");
        decimal bonus = Salary * 0.10m; // 10% bonus
        Console.WriteLine($"Annual bonus: ${bonus:F2}");
    }

    public bool IsEligibleForPromotion()
    {
        var yearsOfService = DateTime.Now.Year - HireDate.Year;
        return yearsOfService >= 2;
    }
}

// File 2: Employee.DataAccess.cs (imagine this is in a separate file)
public partial class Employee
{
    // Data access related methods
    public void SaveToDatabase()
    {
        Console.WriteLine($"Saving employee {EmployeeId} to database...");
        // Database saving logic would go here
        Console.WriteLine("Employee saved successfully!");
    }

    public static Employee LoadFromDatabase(int employeeId)
    {
        Console.WriteLine($"Loading employee {employeeId} from database...");
        // Database loading logic would go here
        return new Employee
        {
            EmployeeId = employeeId,
            FirstName = "John",
            LastName = "Doe",
            Salary = 50000m,
            HireDate = new DateTime(2020, 1, 15)
        };
    }

    public void DeleteFromDatabase()
    {
        Console.WriteLine($"Deleting employee {EmployeeId} from database...");
        // Database deletion logic would go here
        Console.WriteLine("Employee deleted successfully!");
    }
}

// File 3: Employee.Validation.cs (imagine this is in a separate file)
public partial class Employee
{
    // Validation methods
    public bool ValidateEmployee()
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(FirstName))
            errors.Add("First name is required");

        if (string.IsNullOrWhiteSpace(LastName))
            errors.Add("Last name is required");

        if (Salary <= 0)
            errors.Add("Salary must be greater than zero");

        if (HireDate > DateTime.Now)
            errors.Add("Hire date cannot be in the future");

        if (errors.Count > 0)
        {
            Console.WriteLine("Validation errors found:");
            foreach (var error in errors)
            {
                Console.WriteLine($"- {error}");
            }
            return false;
        }

        Console.WriteLine("Employee validation passed!");
        return true;
    }
}

// =============================================================================
// 2. PARTIAL METHODS - BASIC EXAMPLE
// =============================================================================

// Partial methods are particularly useful for code generation scenarios
public partial class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    // Partial method declaration - no implementation here
    // This can be implemented in another partial class file or left unimplemented
    partial void OnCustomerCreated();
    partial void OnCustomerUpdated();
    partial void ValidateCustomerData();

    // Constructor that calls partial method
    public Customer(int id, string name, string email)
    {
        CustomerId = id;
        Name = name;
        Email = email;

        // Call partial method - if not implemented, this does nothing
        OnCustomerCreated();
    }

    public void UpdateCustomer(string name, string email)
    {
        Name = name;
        Email = email;

        // Validate before updating
        ValidateCustomerData();

        // Call partial method after update
        OnCustomerUpdated();
    }
}

// Implementation of partial methods (could be in another file)
public partial class Customer
{
    // Implementation of partial method
    partial void OnCustomerCreated()
    {
        Console.WriteLine($"Customer {Name} (ID: {CustomerId}) has been created!");
        LogActivity("Customer Created");
    }

    // Implementation of another partial method
    partial void OnCustomerUpdated()
    {
        Console.WriteLine($"Customer {Name} (ID: {CustomerId}) has been updated!");
        LogActivity("Customer Updated");
    }

    // This partial method is implemented
    partial void ValidateCustomerData()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentException("Customer name cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
        {
            throw new ArgumentException("Valid email address is required");
        }

        Console.WriteLine("Customer data validation passed");
    }

    private void LogActivity(string activity)
    {
        Console.WriteLine($"[LOG] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {activity} for Customer ID: {CustomerId}");
    }
}

// =============================================================================
// 3. PRACTICAL EXAMPLE: CODE-GENERATED ENTITY WITH PARTIAL CLASSES
// =============================================================================

// This represents what a code generator might create (like Entity Framework)
// File: Product.Generated.cs
public partial class Product
{
    // Generated properties (typically created by tools)
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }

    // Generated partial method declarations
    partial void OnProductCreating();
    partial void OnProductCreated();
    partial void OnPriceChanging(decimal newPrice);
    partial void OnPriceChanged();

    // Generated constructor
    public Product()
    {
        CreatedDate = DateTime.Now;
        OnProductCreating(); // Hook for custom logic
    }

    // Generated method with partial method calls
    public void SetPrice(decimal newPrice)
    {
        OnPriceChanging(newPrice); // Hook before change
        Price = newPrice;
        ModifiedDate = DateTime.Now;
        OnPriceChanged(); // Hook after change
    }

    // Generated method
    public void MarkAsCreated()
    {
        OnProductCreated();
    }
}

// File: Product.Custom.cs (hand-written customizations)
public partial class Product
{
    // Custom properties not generated
    public string FormattedPrice => $"${Price:F2}";
    public bool IsExpensive => Price > 100m;

    // Implementation of partial methods for custom business logic
    partial void OnProductCreating()
    {
        Console.WriteLine("Preparing to create new product...");
        // Custom initialization logic
        if (string.IsNullOrEmpty(ProductName))
        {
            ProductName = "New Product";
        }
    }

    partial void OnProductCreated()
    {
        Console.WriteLine($"Product '{ProductName}' has been created with ID: {ProductId}");
        // Custom post-creation logic
        SendNotificationToInventorySystem();
    }

    partial void OnPriceChanging(decimal newPrice)
    {
        Console.WriteLine($"Price changing from ${Price:F2} to ${newPrice:F2}");
        // Custom validation before price change
        if (newPrice < 0)
        {
            throw new ArgumentException("Price cannot be negative");
        }

        if (newPrice > Price * 2)
        {
            Console.WriteLine("WARNING: Price increase is more than 100%!");
        }
    }

    partial void OnPriceChanged()
    {
        Console.WriteLine($"Price has been updated to ${Price:F2}");
        // Custom logic after price change
        NotifyPriceChangeToCustomers();
    }

    // Custom methods
    private void SendNotificationToInventorySystem()
    {
        Console.WriteLine("Notifying inventory system of new product...");
    }

    private void NotifyPriceChangeToCustomers()
    {
        Console.WriteLine("Sending price change notifications to customers...");
    }

    // Custom business methods
    public void ApplyDiscount(decimal discountPercentage)
    {
        if (discountPercentage < 0 || discountPercentage > 100)
        {
            throw new ArgumentException("Discount percentage must be between 0 and 100");
        }

        decimal discountAmount = Price * (discountPercentage / 100);
        decimal newPrice = Price - discountAmount;

        Console.WriteLine($"Applying {discountPercentage}% discount (${discountAmount:F2})");
        SetPrice(newPrice);
    }
}

// =============================================================================
// 4. ADVANCED EXAMPLE: PARTIAL CLASSES WITH INTERFACES AND INHERITANCE
// =============================================================================

// Interface for auditing
public interface IAuditable
{
    DateTime CreatedDate { get; set; }
    string CreatedBy { get; set; }
    DateTime? ModifiedDate { get; set; }
    string ModifiedBy { get; set; }
}

// Base class
public abstract class BaseEntity
{
    public int Id { get; set; }
    public bool IsActive { get; set; } = true;
}

// Partial class that inherits and implements interface
// File: Order.Core.cs
public partial class Order : BaseEntity, IAuditable
{
    // Core properties
    public string OrderNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }

    // IAuditable implementation
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }

    // Partial method declarations
    partial void OnStatusChanged(OrderStatus oldStatus, OrderStatus newStatus);
    partial void ValidateOrder();

    // Core business logic
    public void ChangeStatus(OrderStatus newStatus, string userId)
    {
        var oldStatus = Status;
        Status = newStatus;
        ModifiedDate = DateTime.Now;
        ModifiedBy = userId;

        OnStatusChanged(oldStatus, newStatus);
    }

    public void ProcessOrder()
    {
        ValidateOrder();
        Console.WriteLine($"Processing order {OrderNumber} for ${TotalAmount:F2}");
    }
}

// File: Order.Notifications.cs
public partial class Order
{
    // Implementation of status change notification
    partial void OnStatusChanged(OrderStatus oldStatus, OrderStatus newStatus)
    {
        Console.WriteLine($"Order {OrderNumber} status changed from {oldStatus} to {newStatus}");

        // Send different notifications based on status
        switch (newStatus)
        {
            case OrderStatus.Confirmed:
                SendConfirmationEmail();
                break;
            case OrderStatus.Shipped:
                SendShippingNotification();
                break;
            case OrderStatus.Delivered:
                SendDeliveryNotification();
                break;
            case OrderStatus.Cancelled:
                SendCancellationNotification();
                break;
        }
    }

    private void SendConfirmationEmail()
    {
        Console.WriteLine($"Sending confirmation email for order {OrderNumber}");
    }

    private void SendShippingNotification()
    {
        Console.WriteLine($"Sending shipping notification for order {OrderNumber}");
    }

    private void SendDeliveryNotification()
    {
        Console.WriteLine($"Sending delivery notification for order {OrderNumber}");
    }

    private void SendCancellationNotification()
    {
        Console.WriteLine($"Sending cancellation notification for order {OrderNumber}");
    }
}

// File: Order.Validation.cs
public partial class Order
{
    partial void ValidateOrder()
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(OrderNumber))
            errors.Add("Order number is required");

        if (TotalAmount <= 0)
            errors.Add("Total amount must be greater than zero");

        if (string.IsNullOrWhiteSpace(CreatedBy))
            errors.Add("Created by is required");

        if (errors.Count > 0)
        {
            throw new InvalidOperationException($"Order validation failed: {string.Join(", ", errors)}");
        }

        Console.WriteLine($"Order {OrderNumber} validation passed");
    }
}

// Enum for order status
public enum OrderStatus
{
    Pending,
    Confirmed,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

// =============================================================================
// 5. DEMONSTRATION CLASS
// =============================================================================

public class PartialConceptsDemo
{
    public static void RunExamples()
    {
        Console.WriteLine("=== PARTIAL CLASSES AND METHODS DEMO ===\n");

        // 1. Employee partial class example
        Console.WriteLine("1. Employee Partial Class Example:");
        var employee = Employee.LoadFromDatabase(123);
        employee.CalculateBonus();
        Console.WriteLine($"Eligible for promotion: {employee.IsEligibleForPromotion()}");
        employee.ValidateEmployee();
        employee.SaveToDatabase();
        Console.WriteLine();

        // 2. Customer with partial methods
        Console.WriteLine("2. Customer Partial Methods Example:");
        try
        {
            var customer = new Customer(1, "Alice Johnson", "alice@example.com");
            customer.UpdateCustomer("Alice Smith", "alice.smith@example.com");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.WriteLine();

        // 3. Product with code generation pattern
        Console.WriteLine("3. Product Code Generation Pattern:");
        var product = new Product();
        product.ProductName = "Laptop";
        product.ProductId = 1;
        product.SetPrice(999.99m);
        product.MarkAsCreated();

        Console.WriteLine($"Product: {product.ProductName}");
        Console.WriteLine($"Formatted Price: {product.FormattedPrice}");
        Console.WriteLine($"Is Expensive: {product.IsExpensive}");

        product.ApplyDiscount(15); // 15% discount
        Console.WriteLine();

        // 4. Order with inheritance and interfaces
        Console.WriteLine("4. Order with Inheritance and Interfaces:");
        try
        {
            var order = new Order
            {
                Id = 1,
                OrderNumber = "ORD-2024-001",
                TotalAmount = 299.99m,
                Status = OrderStatus.Pending,
                CreatedDate = DateTime.Now,
                CreatedBy = "user123"
            };

            order.ProcessOrder();
            order.ChangeStatus(OrderStatus.Confirmed, "user123");
            order.ChangeStatus(OrderStatus.Shipped, "system");
            order.ChangeStatus(OrderStatus.Delivered, "system");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// =============================================================================
// BEST PRACTICES FOR PARTIAL CLASSES AND METHODS
// =============================================================================

/*
WHEN TO USE PARTIAL CLASSES:
✅ Code generation scenarios (Entity Framework, WPF forms, etc.)
✅ Large classes that benefit from logical separation
✅ Team development where different developers work on different aspects
✅ Separating auto-generated code from hand-written code
✅ Organizing code by functionality (business logic, data access, validation)

WHEN TO USE PARTIAL METHODS:
✅ Code generation hooks and extension points
✅ Optional event handlers in generated code
✅ Template method pattern implementations
✅ When you want to provide hooks without forcing implementation

BEST PRACTICES:
✅ Use meaningful file naming conventions (ClassName.Aspect.cs)
✅ Keep related functionality together in the same partial file
✅ Use partial methods for optional functionality only
✅ Document which parts are auto-generated vs hand-written
✅ Be consistent with access modifiers across partial declarations

LIMITATIONS TO REMEMBER:
❌ All partial class parts must be in the same assembly
❌ All parts must use the same access modifier
❌ If any part uses abstract/sealed, all parts inherit that constraint
❌ Partial methods must return void and cannot have out parameters
❌ Partial methods are implicitly private
❌ Cannot split method implementations across partial classes

COMMON USE CASES:
- Windows Forms/WPF designer-generated code
- Entity Framework Code First models
- Web service proxy classes
- Large business entities with multiple concerns
- Template-based code generation
- Team development scenarios
*/