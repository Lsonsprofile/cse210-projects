// Program.cs - Main entry point and user interface
// Handles menu loop, user choices, and coordinates Journal actions
// using System: For Console input/output

using System;

class Program
{
    // Main(string[] args):
    // - Creates Journal instance
    // - Runs infinite menu loop until user chooses to quit
    // - Uses switch to route user choice to correct method
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            // Display menu options
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            // Route user choice using switch statement
            // Each case calls a method on the Journal object
            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(loadFile))
                    {
                        Console.WriteLine("No filename entered. Nothing loaded.\n");
                    }
                    else
                {
                        journal.LoadFromFile(loadFile);  
                    }
                    break;

                // Program.cs - Ensure Save is called with user input
                case "4":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(saveFile))
                    {
                        Console.WriteLine("No filename entered. Journal not saved.\n");
                    }
                    else
                    {
                        journal.SaveToFile(saveFile);  
                    }
                    break;

                case "5":
                    Console.WriteLine("Thank you for using the Journal Program!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }
}