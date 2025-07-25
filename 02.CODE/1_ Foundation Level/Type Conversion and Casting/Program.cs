using System;

class TypeConversionAndCasting
{
    static void Main()
    {
        Console.WriteLine("=== Type Conversion and Casting ===");


        // Implicit conversion (widening)
        Console.WriteLine("=== Implicit Conversion ===");
        int intValue = 100;
        long longValue = intValue;     // int to long (safe) 
        float floatValue = intValue;   // int to float (safe)
        double doubleValue = floatValue; // float to double (safe)

        Console.WriteLine($"int: {intValue}");
        Console.WriteLine($"long: {longValue}");
        Console.WriteLine($"float: {floatValue}");
        Console.WriteLine($"double: {doubleValue}");

        // Explicit conversion (casting)
        Console.WriteLine("\n=== Explicit Conversion (Casting) ===");
        double largeNumber = 123.456;
        int truncatedInt = (int)largeNumber;  // Data loss - decimal part removed
        float smallerFloat = (float)largeNumber;

        Console.WriteLine($"Original double: {largeNumber}");
        Console.WriteLine($"Casted to int: {truncatedInt}");
        Console.WriteLine($"Casted to float: {smallerFloat}");

        // String to number conversion using Parse
        Console.WriteLine("\n=== String to Number Conversion (Parse) ===");
        string numberString = "456";
        string decimalString = "78.9";
        string boolString = "true";

        int parsedInt = int.Parse(numberString);
        double parsedDouble = double.Parse(decimalString);
        bool parsedBool = bool.Parse(boolString);

        Console.WriteLine($"String '{numberString}' to int: {parsedInt}");
        Console.WriteLine($"String '{decimalString}' to double: {parsedDouble}");
        Console.WriteLine($"String '{boolString}' to bool: {parsedBool}");

        // Safe parsing with TryParse
        Console.WriteLine("\n=== Safe Parsing with TryParse ===");
        string validNumber = "123";
        string invalidNumber = "abc";

        // TryParse returns bool indicating success/failure
        if (int.TryParse(validNumber, out int result1))
        {
            Console.WriteLine($"Successfully parsed '{validNumber}' to: {result1}");
        }

        if (int.TryParse(invalidNumber, out int result2))
        {
            Console.WriteLine($"Successfully parsed '{invalidNumber}' to: {result2}");
        }
        else
        {
            Console.WriteLine($"Failed to parse '{invalidNumber}' - not a valid integer");
        }

        // Using Convert class
        Console.WriteLine("\n=== Using Convert Class ===");
        string convertString = "789";
        double convertDouble = 45.67;
        bool convertBool = true;

        int convertedInt = Convert.ToInt32(convertString);
        string convertedString = Convert.ToString(convertDouble);
        int convertedFromBool = Convert.ToInt32(convertBool); // true = 1, false = 0
        
        Console.WriteLine($"Convert string to int: {convertedInt}");
        Console.WriteLine($"Convert double to string: '{convertedString}'");
        Console.WriteLine($"Convert bool to int: {convertedFromBool}");

        // Demonstration of overflow in casting
        Console.WriteLine("\n=== Overflow in Casting ===");
        int largeInt = 300;
        byte smallByte = (byte)largeInt; // byte range: 0-255
        Console.WriteLine($"Large int {largeInt} casted to byte: {smallByte}");
        Console.WriteLine("Notice the overflow - value wrapped around!");

        // Character to number conversion
        Console.WriteLine("\n=== Character Conversions ===");
        char digitChar = '5';
        char letterChar = 'A';

        int digitValue = (int)digitChar; // ASCII value
        int letterValue = (int)letterChar; // ASCII value
        int numericValue = digitChar - '0'; // Convert char digit to actual number

        Console.WriteLine($"Character '{digitChar}' ASCII value: {digitValue}");
        Console.WriteLine($"Character '{letterChar}' ASCII value: {letterValue}");
        Console.WriteLine($"Character '{digitChar}' numeric value: {numericValue}");
    }
}

