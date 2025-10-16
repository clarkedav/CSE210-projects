using System;
using System.Threading;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        public override void Run()
        {
            SetDurationFromUser();
            DisplayStartingMessage();

            DateTime endTime = DateTime.Now.AddSeconds(_durationSeconds);

            while (DateTime.Now < endTime)
            {
                Console.Write("Breathe in... ");
                Countdown(4); 
                Console.WriteLine();

                if (DateTime.Now >= endTime) break;

                Console.Write("Breathe out... ");
                Countdown(6); 
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }
    }
}
