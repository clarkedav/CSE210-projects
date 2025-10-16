/*             CREATIVE ENHANCEMENTS 
The program now tracks how many times each activity  
The user can view their progress in the new "View Activity Log" menu option.
The activity log is also saved to a text file ("activity_log.txt") 
after each activity.
When the program starts, it loads the saved data automatically
so progress persists between sessions.
Within the Reflection and Listing activities, random prompts 
are chosen in a way that avoids immediate repetition within 
the same session.*/








using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Mindfulness
{
    class Program
    {
        // Track how many times each activity is performed
        private static Dictionary<string, int> activityLog = new Dictionary<string, int>()
        {
            { "Breathing Activity", 0 },
            { "Reflecting Activity", 0 },
            { "Listing Activity", 0 }
        };

        private const string LogFilePath = "activity_log.txt";

        static void Main(string[] args)
        {
            // Load previous session’s log if available
            LoadActivityLog();

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("-------------------");
                Console.WriteLine("1) Breathing Activity");
                Console.WriteLine("2) Reflecting Activity");
                Console.WriteLine("3) Listing Activity");
                Console.WriteLine("4) View Activity Log");
                Console.WriteLine("5) Exit");
                Console.Write("Choose an option (1-5): ");

                string choice = Console.ReadLine();
                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectingActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        ShowActivityLog();
                        Console.WriteLine("Press Enter to return to the menu...");
                        Console.ReadLine();
                        continue;
                    case "5":
                        exit = true;
                        SaveActivityLog();
                        Console.WriteLine("Thanks for using the Mindfulness Program. Goodbye!");
                        Thread.Sleep(1000);
                        return;
                    default:
                        Console.WriteLine("Unknown option. Press Enter to try again.");
                        Console.ReadLine();
                        continue;
                }

                // Run the selected activity
                if (activity != null)
                {
                    activity.Run();

                    // Log this session
                    if (activityLog.ContainsKey(activity.GetType().Name.Replace("Activity", " Activity")))
                        activityLog[activity.GetType().Name.Replace("Activity", " Activity")]++;
                    else
                        activityLog[activity.GetType().Name.Replace("Activity", " Activity")] = 1;

                    SaveActivityLog(); // Save progress each time
                }
            }
        }

        private static void ShowActivityLog()
        {
            Console.Clear();
            Console.WriteLine("Activity Log");
            Console.WriteLine("-------------");
            foreach (var entry in activityLog)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} time(s) completed");
            }
            Console.WriteLine();
        }

        private static void LoadActivityLog()
        {
            if (!File.Exists(LogFilePath))
                return;

            string[] lines = File.ReadAllLines(LogFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && activityLog.ContainsKey(parts[0].Trim()))
                {
                    if (int.TryParse(parts[1].Trim(), out int count))
                        activityLog[parts[0].Trim()] = count;
                }
            }
        }

        private static void SaveActivityLog()
        {
            using (StreamWriter writer = new StreamWriter(LogFilePath))
            {
                foreach (var entry in activityLog)
                {
                    writer.WriteLine($"{entry.Key}: {entry.Value}");
                }
            }
        }
    }
}


