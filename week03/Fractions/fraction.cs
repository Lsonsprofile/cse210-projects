// Fraction.cs
// This file defines a Fraction class using proper encapsulation.
// Class name starts with capital letter: Fraction (PascalCase)

using System; // Import basic C# tools: int, string, Console, Exception, etc.

public class Fraction // Class name: Fraction (capital F) — correct style
{
    // Private field: stores the numerator (top number). Only this class can access it.
    private int _top;

    // Private field: stores the denominator (bottom number). Hidden from outside code.
    private int _bottom;

    // Default constructor: creates 1/1 when no numbers are given
    public Fraction()
    {
        _top = 1;     // Set top to 1
        _bottom = 1;  // Set bottom to 1
    }

    // Constructor with one parameter: treats input as whole number → e.g., 5 becomes 5/1
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber; // Use input as numerator
        _bottom = 1;        // Bottom is always 1 for whole numbers
    }

    // Constructor with two parameters: full fraction → e.g., 3, 4 becomes 3/4
    public Fraction(int top, int bottom)
    {
        _top = top;     // Store the top value
        _bottom = bottom; // Store the bottom value
    }

    // Getter: returns the current numerator
    public int GetTop()
    {
        return _top; // Return the private field value
    }

    // Getter: returns the current denominator
    public int GetBottom()
    {
        return _bottom; // Return the private field value
    }

    // Setter: changes the numerator to a new value
    public void SetTop(int top)
    {
        _top = top; // Update the private field
    }

    // Setter: changes the denominator, but prevents zero (division by zero error)
    public void SetBottom(int bottom)
    {
        if (bottom == 0) // Check for invalid input
            throw new ArgumentException("Denominator cannot be zero!"); // Stop program with clear message
        _bottom = bottom; // Only update if safe
    }

    // Returns the fraction as a string like "3/4"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}"; // Combine top, slash, bottom using string interpolation
    }

    // Returns the decimal value (e.g., 3/4 → 0.75)
    public double GetDecimalValue()
    {
        return (double)_top / _bottom; // Cast top to double before dividing to get decimal result
    }
}