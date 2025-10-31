using System;

class Program
{
    static void Main(string[] args)
    {
        // Call functions here
        DisplayWelcome();

        string userName = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number);

        Console.WriteLine($"{userName}, the square of your number is {square}.");


    }

    // FUNCTIONS GO HERE (outside Main)

    static void DisplayWelcome()
    {
        Console.WriteLine("**Welcome to the program!**");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter a number: ");
        int userNumber = int.Parse(Console.ReadLine());
        return userNumber;
    }


    static int SquareNumber(int userNumber)
    {
        int square = userNumber * userNumber;
        return square;
    }


    static void DisplayResult(string userName, int userNumber)
    {
        Console.WriteLine($"{userName}, the square of is {SquareNumber(userNumber)}");
    }
}