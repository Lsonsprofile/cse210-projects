using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    public void Run()
    {
        string repeat = "yes";

        while (repeat == "yes")
        {
            StartActivity();   // Shows welcome, description, duration prompt

            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                Console.WriteLine("Breathe in...\n");
                ShowSpinner(4);   // Inhale for 4 seconds (from base class)
                Console.WriteLine("Breathe out...");
                ShowSpinner(6);   // Exhale for 6 seconds (from base class)
                Console.WriteLine();
            }

            EndActivity();   // Shows ending message + spinner

            // Use private helper for yes/no input validation
            repeat = GetYesNoInput("\nDo you want to repeat the Breathing Activity? (yes/no): ");
        }

        // Clean return to menu
        Console.WriteLine("\nReturning to main menu...");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    // Private helper method for yes/no input validation
    private string GetYesNoInput(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine().Trim().ToLower();

        while (input != "yes" && input != "no")
        {
            Console.Write("Please type 'yes' or 'no': ");
            input = Console.ReadLine().Trim().ToLower();
        }

        return input;
    }
}
