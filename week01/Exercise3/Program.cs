using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guess = -1;
        int guessCount = 0;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess?");
            guess = int.Parse(Console.ReadLine());
            guessCount++;

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }

            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }

            else
            {
                Console.WriteLine("Your guess is correct");
                Console.WriteLine($"It took you {guessCount} guesses.");
            }
        }
   
    }
}