using System;

public class WritingAssignment : Assignment
{
    private string _title;   // Only writing assignments have a title

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)   // Parent stores name & topic first
    {
        _title = title;              // Then we store the title in this object
    }

    public string GetWritingInformation()
    {
        // We cannot write: _studentName → it's private in the parent!
        // So we politely ask the parent: "Can I have the name please?"
        string studentName = GetStudentName();   // ← calls the method from Assignment.cs

        // Build and return the final string using data from TWO places:
        // _title comes from this object, studentName comes from parent object
        return $"{_title} by {studentName}";
        // → "The Causes of World War II by Mary Waters"
    }
}