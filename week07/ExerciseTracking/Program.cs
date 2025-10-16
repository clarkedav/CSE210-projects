using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>
            {
                new RunningActivity(new DateTime(2022, 11, 3), 30, 3.0),
                new CyclingActivity(new DateTime(2022, 11, 3), 45, 12.0),
                new SwimmingActivity(new DateTime(2022, 11, 3), 60, 40)
            };

            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
