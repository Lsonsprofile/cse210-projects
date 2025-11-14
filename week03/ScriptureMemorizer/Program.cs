// I added a welcome message with my favourite colour yellow
using System;

class Program
{
    static void Main(string[] args)
    {
        ShowWelcomeMessage();

        // Pause so the user can read the heading before continuing
        Console.WriteLine("Press any key to begin...");
        Console.ReadKey();

        // Create scripture reference and text
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string verseText = "Trust in the Lord with all your heart and lean not on your own understanding";

        // Initialize Scripture object
        Scripture scripture = new Scripture(reference, verseText);

        RunMemorizationLoop(scripture);
    }

    static void ShowWelcomeMessage()
    {
        // Set the console header text color to yellow
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("════════════════════════════════════════════════");
        Console.WriteLine("     WELCOME TO THE SCRIPTURE MEMORIZER!        ");
        Console.WriteLine("════════════════════════════════════════════════");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void RunMemorizationLoop(Scripture scripture)// this is the method that will run the memorization loop
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide more words");
            Console.WriteLine("Type 'undo' to unhide last hidden words");
            Console.WriteLine("Type 'quit' to exit:");

            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.ToLower() == "quit")
                {
                    Console.WriteLine("Thanks for practicing! Goodbye!");
                    break;
                }
                else if (input.ToLower() == "undo")
                {
                    scripture.UndoLastHide();
                    continue;
                }
            }

            if (scripture.IsCompletelyHidden())// this is the method that will check if the scripture is completely hidden
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nCONGRATULATIONS!");
                Console.WriteLine("You memorized the entire scripture!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                break;
            }

            scripture.HideRandomWordsWithTracking(2);// this is the method that will hide 2 random words
        }
    }
}
