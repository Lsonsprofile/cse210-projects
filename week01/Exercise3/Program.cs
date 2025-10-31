using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a random number between 1 and 100
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 11);

        int guess = -1; // Start with a wrong guess
        int attempts = 0; // Count how many guesses

        Console.WriteLine("Welcome to 'Guess My Number'!");
        Console.WriteLine("I'm thinking of a number between 1 and 10.");

        // Keep asking user until they guess the magic number
        while (guess != magicNumber)
        {
            Console.Write("What is the magic number? ");
            guess = int.Parse(Console.ReadLine());
            attempts++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher. Try again.");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower. Try again.");
            }
            else
            {
                if (attempts == 1)
                {
                    Console.WriteLine($"You guess it in {attempts} attempt");
                }
                else
                {
                    Console.WriteLine($"You guess it in {attempts} attempts");
                }
            }
        }
    }
}
        
    