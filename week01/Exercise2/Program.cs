using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercentage = Console.ReadLine();
        int grade = int.Parse(gradePercentage);

        string letter = "";

        // Determine the letter grade based on the grade percentage
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is in the range of {letter}.");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed your course!");
        }
        else if (grade < 70 && grade >= 60)
        {
            Console.WriteLine("Poor, you barely passed your course. Try harder next time!");
        }
        else if (grade < 60)
        {
            Console.WriteLine("You failed your course. You should not be in college.");
        }

        int lastDigit = grade % 10;

        string sign = "";
        if (lastDigit >= 7) sign = "+";
        else if (lastDigit < 3) sign = "-";

        if (letter == "A" && sign == "+")
        sign = ""; 
        else if (letter == "F")
        sign = ""; 

        // Print only if there’s a sign
        if (!string.IsNullOrEmpty(sign))
        {
            Console.WriteLine($"You have {letter}{sign} as your grade");
        }

        
    }
    
}