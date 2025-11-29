// I use a while loop to allow the user to continue the activity until they choose to stop.
// No prompt or question repeats until every one has been used at least once in this session.
using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    // Prompts for reflection
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    // Questions to ponder
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // These track what hasn't been used yet in the current session
    private List<string> _unusedPrompts;
    private List<string> _unusedQuestions;

    public ReflectingActivity() 
        : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    { }

    public void Run()
    {
        string repeat = "yes";

        while (repeat == "yes")
        {
            StartActivity();   // Shows welcome, description, duration prompt

            // Reset the unused lists at the start of each new session
            _unusedPrompts = new List<string>(_prompts);
            _unusedQuestions = new List<string>(_questions);

            Random rand = new Random();

            // 1. Show a random prompt — no repeats until all are used
            string prompt = GetRandomUniqueItem(_unusedPrompts, rand);
            Console.WriteLine("\nConsider the following prompt:\n");
            Console.WriteLine($" --- {prompt} --- ");
            Console.WriteLine("\nWhen you have something in mind, press any key to continue.");
            Console.ReadKey();

            Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
            Console.Write("You may begin in: ");
            ShowSpinner(7);

            Console.Clear();

            // 2. Show random questions — no repeats until all are used
            DateTime endTime = DateTime.Now.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                string question = GetRandomUniqueItem(_unusedQuestions, rand);
                Console.Write($"> {question} ");
                ShowSpinner(8);
                Console.WriteLine();
            }

            EndActivity();   // Ending message

            // Ask if user wants to repeat or exit
            Console.Write("\nDo you want to repeat the Reflecting Activity? (yes/no): ");
            repeat = Console.ReadLine().Trim().ToLower();

            while (repeat != "yes" && repeat != "no")
            {
                Console.Write("Please type 'yes'yes' or 'no': ");
                repeat = Console.ReadLine().Trim().ToLower();
            }
        }

        // Clean return to menu
        Console.WriteLine("\nReturning to main menu...");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    // Picks a random item from the list and removes it so it can't repeat
    private string GetRandomUniqueItem(List<string> list, Random rand)
    {
        if (list.Count == 0)
        {
            // Refill when all have been used once
            list.AddRange(_prompts);       // this works because we know which list it is
            if (list.Count == _prompts.Count) list = new List<string>(_prompts);
            else list = new List<string>(_questions);
        }

        int index = rand.Next(list.Count);
        string item = list[index];
        list.RemoveAt(index);
        return item;
    }
}