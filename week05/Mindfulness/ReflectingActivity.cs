using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    public class ReflectingActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private readonly List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        // This will track which prompts and questions have been used in the session
        private readonly HashSet<string> _usedPrompts = new HashSet<string>();
        private readonly HashSet<string> _usedQuestions = new HashSet<string>();

        public ReflectingActivity() : base(
            "Reflecting Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
            "This will help you recognize the power you have and how you can use it in other aspects of your life.")
        { }

        public override void Run()
        {
            SetDurationFromUser();
            DisplayStartingMessage();

            string prompt = GetUniquePrompt();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press Enter to continue...");
            Console.ReadLine();

            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.Write("You may begin in: ");
            Countdown(5);

            Console.Clear();
            DateTime endTime = DateTime.Now.AddSeconds(_durationSeconds);

            while (DateTime.Now < endTime)
            {
                string question = GetUniqueQuestion();
                Console.Write($"> {question} ");
                PauseWithSpinner(5); // short pause for reflection
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }

        private string GetUniquePrompt()
        {
            // This will reset if all prompts are used
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

        private string GetUniqueQuestion()
        {
            // This will reset if all questions are used
            if (_usedQuestions.Count == _questions.Count)
                _usedQuestions.Clear();

            string question;
            do
            {
                question = _questions[_random.Next(_questions.Count)];
            } while (_usedQuestions.Contains(question));

            _usedQuestions.Add(question);
            return question;
        }
    }
}
