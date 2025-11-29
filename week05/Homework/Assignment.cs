using System;
public class Assignment
{
    // These two pieces of memory belong to EVERY assignment object
    private string _studentName;  // Example: "Roberto Rodriguez" lives here
    private string _topic;       // Example: "Fractions" lives here

    // Constructor = the moment a new Assignment is born
    public Assignment(string studentName, string topic)
    {
        // We take the strings from outside and store them safely inside the object
        _studentName = studentName;   // → memory location _studentName now holds "Samuel Bennett"
        _topic       = topic;         // → memory location _topic now holds "Multiplication"
    }

    // This method reads the two private fields and builds one string
    public string GetSummary()
    {
        // $"{...}" creates a new string in memory using the current values
        return $"{_studentName} - {_topic}";  // → returns "Samuel Bennett - Multiplication"
    }

    // Child classes need the name, but can't touch _studentName directly (it's private)
    // So we give them a safe "reading glasses" → a public method
    public string GetStudentName()
    {
        return _studentName;  // safely hands out the name without letting anyone change it
    }
}