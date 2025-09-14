using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
     {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int userNumber = -1;

        while (userNumber != 0)
        {
            Console.WriteLine("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Average
        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Maximum
        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }
        Console.WriteLine($"The largest number is: {max}");

        // Stretch 1: Smallest positive
        int smallestPositive = int.MaxValue;
        foreach (int num in numbers)
        {
            if (num > 0 && num < smallestPositive)
            {
                smallestPositive = num;
            }
        }
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Stretch 2: Sorted list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}