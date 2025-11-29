using System;
using System.Threading;
using System.Collections.Generic;

public class Activity
{
    protected string _name;         
    protected string _description;   
    protected int _duration;      

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"***Welcome to the {_name} Activity***");
        Console.WriteLine(_description);
        Console.WriteLine();

        int seconds;
        string input;
        do
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            input = Console.ReadLine();

            if (int.TryParse(input, out seconds) && seconds > 0)
            {
                _duration = seconds;
                break;
            }
            Console.Write("Invalid input. Please enter a positive number: ");
        } while (true);

        Console.WriteLine("\nGet ready...");
        ShowSpinner(4);
    }

    public void EndActivity()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(4);
        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name} Activity\n");
        ShowSpinner(5);
    }

    private readonly List<string> _spinnerFrames = new List<string>
    {
        "|", "/", "-", "\\", "|", "/", "-", "\\"
    };

    public void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(_spinnerFrames[index]);
            Thread.Sleep(200);
            Console.Write("\b");
            index = (index + 1) % _spinnerFrames.Count;
        }
        Console.Write(" ");
    }
}