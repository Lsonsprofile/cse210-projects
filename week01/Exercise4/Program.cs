using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number = -1;

        while (number != 0)
        {
            Console.Write("Enter number: ");
            string digits = Console.ReadLine();

            //use 'number' consistently here
            number = int.Parse(digits);  

            if (number == 0)
            {
                break;
            }

            numbers.Add(number);
        }

        // add the numbers together and print the sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum is: {sum}");

        // finds the average and print it
        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // finds the largest number and print it
        int largest = numbers[0];
        foreach (int num in numbers)
        {
            if (num > largest)
            {
                largest = num;
            }
        }
        Console.WriteLine($"The largest number is: {largest}");

        // finds the smallest positive number and print it
        int smallestPositive = int.MaxValue; // <-- fixed: start high
        foreach (int num in numbers)
        {
            if (num > 0 && num < smallestPositive)
            {
                smallestPositive = num;
            }
        }

        if (smallestPositive == int.MaxValue)
        {
            Console.WriteLine("No positive numbers in the list.");
        }
        else
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // the sorted list of the inputed numbers
        List<int> sortedNumbers = new List<int>(numbers);
        sortedNumbers.Sort();
        Console.WriteLine("The sorted list of numbers is:");
        foreach (int num in sortedNumbers)
        {
            Console.WriteLine(num);
        }

    }
}
