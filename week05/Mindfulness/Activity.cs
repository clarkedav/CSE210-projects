using System;
using System.Threading;

namespace Mindfulness
{
    public abstract class Activity
    {
        protected string _activityName;
        protected string _description;
        protected int _durationSeconds;
        private static readonly string[] _spinnerChars = new[] { "|", "/", "-", "\\" };
        protected static readonly Random _random = new Random();

        protected static ActivityLog _activityLog = new ActivityLog("activity_log.txt");

        public Activity(string name, string description)
        {
            _activityName = name;
            _description = description;
        }

        public void SetDurationFromUser()
        {
            Console.Write($"Enter duration in seconds for the {_activityName}: ");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int seconds) && seconds > 0)
                {
                    _durationSeconds = seconds;
                    break;
                }
                Console.Write("Please enter a positive integer for seconds: ");
            }
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"--- {_activityName} ---");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.WriteLine($"This activity will last {_durationSeconds} seconds.");
            Console.WriteLine();
            Console.WriteLine("Prepare to begin...");
            PauseWithSpinner(3);
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!!");
            Console.WriteLine($"You have completed the {_activityName} for {_durationSeconds} seconds.");
            PauseWithSpinner(3);

            _activityLog.RecordActivity(_activityName);
        }

        protected void PauseWithSpinner(int seconds)
        {
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int idx = 0;
            while (DateTime.Now < endTime)
            {
                Console.Write(_spinnerChars[idx % _spinnerChars.Length]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                idx++;
            }
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        public abstract void Run();
    }
}
