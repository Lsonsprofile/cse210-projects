using System;
using System.Threading;
using System.Collections.Generic;

public class ListingActivity : Activity   // Inherits from Activity base class
{
    // Prompts the user will see randomly
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // Tracks unused prompts in the current session
    private List<string> _unusedPrompts;

    public ListingActivity()
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        // Constructor passes name + description to parent Activity
    }

    public void Run()
    {
        string repeat = "yes";

        while (repeat == "yes")
        {
            StartActivity();  // Calls parent method: shows welcome, asks duration, shows spinner

            // Reset unused prompts at the start of each new session
            _unusedPrompts = new List<string>(_prompts);

            Random rand = new Random();

            // 1. Show a random prompt — no repeats until all 5 are used once
            string prompt = GetNextUniquePrompt(rand);
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($" --- {prompt} --- ");
            
            Console.Write("You may begin in: ");
            ShowSpinner(5);  // Countdown before starting (from base class)

            // 2. Let user type items until time runs out
            List<string> items = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);

            Console.WriteLine("Go!");

            while (DateTime.Now < endTime)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }
            }

            // 3. Show result
            Console.WriteLine($"\nYou listed {items.Count} items!");

            EndActivity();  // Calls parent method: shows "Well done!" + completion message

            // Ask if user wants to repeat or exit
            Console.Write("\nDo you want to repeat the Listing Activity? (yes/no): ");
            repeat = Console.ReadLine().Trim().ToLower();

            while (repeat != "yes" && repeat != "no")
            {
                Console.Write("Please type 'yes' or 'no': ");
                repeat = Console.ReadLine().Trim().ToLower();
            }
        }

        // Clean return to menu
        Console.WriteLine("\nReturning to main menu...");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    // Picks a random unused prompt and removes it so it can't repeat until all are used
    private string GetNextUniquePrompt(Random rand)
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts); // Refill when all used once
        }

        int index = rand.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return prompt;
    }
}