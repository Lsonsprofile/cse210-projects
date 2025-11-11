// Program.cs
// This is the main program that tests the Fraction class.

using System; // Needed for Console output and basic types

class Program // Main class — runs when you start the program
{
    // Main method: entry point of the program
    static void Main()
    {
        // Test 1: Default constructor → should be 1/1
        Fraction f1 = new Fraction();
        Console.WriteLine("Test 1: Default Constructor");
        Console.WriteLine(f1.GetFractionString()); // Expected: 1/1
        Console.WriteLine(f1.GetDecimalValue());   // Expected: 1
        Console.WriteLine(); // Blank line for readability

        // Test 2: Whole number constructor → 5 becomes 5/1
        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString()); // Expected: 5/1
        Console.WriteLine(f2.GetDecimalValue());   // Expected: 5
        Console.WriteLine(); // Blank line for readability

        // Test 3: Full fraction → 3/4
        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString()); // Expected: 3/4
        Console.WriteLine(f3.GetDecimalValue());   // Expected: 0.75
        Console.WriteLine();

        // Test 4: Another fraction → 1/3
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString()); // Expected: 1/3
        Console.WriteLine(f4.GetDecimalValue());   // Expected: ~0.333
        Console.WriteLine();

        // Test 5: Use setters to change values
        f3.SetTop(6);    // Change top to 6
        f3.SetBottom(7); // Change bottom to 7
        Console.WriteLine(f3.GetFractionString()); // Expected: 6/7
        Console.WriteLine(f3.GetDecimalValue());   // Expected: ~0.857
        Console.WriteLine();

        // Optional: Uncomment to test error handling
        // f3.SetBottom(0); // This will crash with: "Denominator cannot be zero!"
    }
}