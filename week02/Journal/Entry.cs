using System;

public class Entry
{
    public string _date = "";
    public string _promptText = "";
    public string _entryText = "";

    public void Display()
    {
        string displayDate = string.IsNullOrEmpty(_date) ? DateTime.Now.ToShortDateString() : _date; // if date is empty, use current date
        Console.WriteLine($"Date: {displayDate} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }
}