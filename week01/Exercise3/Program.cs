using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;
        do
        {
            // Create a random number between 1 and 10
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 11);

            int guess = -1; // Start with a wrong guess
            int attempts = 0; // Count how many guesses

            Console.WriteLine("Welcome to 'Guess My Number'!");
            Console.WriteLine("I'm thinking of a number between 1 and 10.");
            Console.WriteLine();

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
                        Console.WriteLine($"You guessed it in {attempts} attempt!");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it in {attempts} attempts!");
                    }
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes");
    }
}
