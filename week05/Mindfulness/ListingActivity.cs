using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        // Track which prompts have been used this session
        private readonly HashSet<string> _usedPrompts = new HashSet<string>();

        public ListingActivity() : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        { }

        public override void Run()
        {
            SetDurationFromUser();
            DisplayStartingMessage();

            string prompt = GetUniquePrompt();
            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.Write("You will have 5 seconds to prepare: ");
            Countdown(5);
            Console.WriteLine();
            Console.WriteLine("Start listing items (press Enter after each). Keep going until time is up.");

            DateTime endTime = DateTime.Now.AddSeconds(_durationSeconds);
            List<string> items = new List<string>();

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string line = ReadLineWithTimeout(endTime);
                if (!string.IsNullOrWhiteSpace(line))
                {
                    items.Add(line.Trim());
                }

                if (DateTime.Now >= endTime) break;
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} item(s).");
            DisplayEndingMessage();
        }

        private string GetUniquePrompt()
        {
            // This reset if all prompts are used
            if (_usedPrompts.Count == _prompts.Count)
                _usedPrompts.Clear();

            string prompt;
            do
            {
                prompt = _prompts[_random.Next(_prompts.Count)];
            } while (_usedPrompts.Contains(prompt));

            _usedPrompts.Add(prompt);
            return prompt;
        }

        private string ReadLineWithTimeout(DateTime endTime)
        {
            string input = "";
            while (DateTime.Now < endTime)
            {
                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey(intercept: true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        return input;
                    }
                    else if (keyInfo.Key == ConsoleKey.Backspace)
                    {
                        if (input.Length > 0)
                        {
                            input = input.Substring(0, input.Length - 1);
                            Console.Write("\b \b");
                        }
                    }
                    else
                    {
                        input += keyInfo.KeyChar;
                        Console.Write(keyInfo.KeyChar);
                    }
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            Console.WriteLine();
            return input;
        }
    }
}
