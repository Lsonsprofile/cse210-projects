
using System;

class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "4")   // Loop until user chooses to quit
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nChoose an option (1-4): ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Clear();
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();   
            }
            else if (choice == "2")
            {
                Console.Clear();
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();  
            }
            else if (choice == "3")
            {
                Console.Clear();
                ListingActivity listing = new ListingActivity();
                listing.Run();    
            }
            else if (choice == "4")
            {
                Console.WriteLine("Thank you for practicing mindfulness!");
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please enter 1, 2, 3, or 4.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
