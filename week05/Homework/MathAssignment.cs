using System;
public class MathAssignment : Assignment   // ← This object IS an Assignment + extra stuff
{
    // These two fields exist ONLY in MathAssignment objects
    private string _textbookSection;  // e.g. "7.3"
    private string _problems;         // e.g. "8-19"

    // Constructor gets 4 pieces of data from the outside world
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)    // ← First, let the parent (Assignment) store name & topic
    {
        // Now we store the two extra pieces that only math assignments have
        _textbookSection = textbookSection;   // → stored in this object's memory
        _problems        = problems;          // → stored in this object's memory
    }

    // New behavior that only math assignments know how to do
    public string GetHomeworkList()
    {
        // Uses the two private fields that live inside THIS object
        return $"Section {_textbookSection} Problems {_problems}";
        // → returns "Section 7.3 Problems 8-19"
    }
}