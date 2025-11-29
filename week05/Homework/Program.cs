using System;
class Program
{
    static void Main(string[] args)
    {
        // 1. A plain Assignment is created → only has name & topic
        Assignment a = new Assignment("Samuel Bennett", "Multiplication");
        // Memory now contains one object with:
        //   _studentName = "Samuel Bennett"
        //   _topic       = "Multiplication"
        Console.WriteLine(a.GetSummary());  // → "Samuel Bennett - Multiplication"

        Console.WriteLine();

        // 2. A MathAssignment is created → it's an Assignment + math extras
        MathAssignment m = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        // This ONE object in memory now has FOUR pieces of data:
        //   _studentName       → "Roberto Rodriguez" (from parent)
        //   _topic             → "Fractions"        (from parent)
        //   _textbookSection   → "7.3"             (only in child)
        //   _problems          → "8-19"            (only in child)

        Console.WriteLine(m.GetSummary());       // → uses parent's method
        Console.WriteLine(m.GetHomeworkList()); // → uses child's own method

        Console.WriteLine();

        // 3. A WritingAssignment is created
        WritingAssignment w = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        // This object has:
        //   _studentName → "Mary Waters"      (from parent)
        //   _topic       → "European History" (from parent)
        //   _title       → "The Causes..."    (only in this child)

        Console.WriteLine(w.GetSummary());
        Console.WriteLine(w.GetWritingInformation());  // ← combines data from parent + child
    }
}