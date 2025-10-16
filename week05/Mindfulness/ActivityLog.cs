using System;
using System.Collections.Generic;
using System.IO;

namespace Mindfulness
{
    public class ActivityLog
    {
        private string _filePath;
        private Dictionary<string, int> _activityCounts = new Dictionary<string, int>();

        public ActivityLog(string filePath)
        {
            _filePath = filePath;
            LoadLog();
        }

        public void RecordActivity(string activityName)
        {
            if (_activityCounts.ContainsKey(activityName))
                _activityCounts[activityName]++;
            else
                _activityCounts[activityName] = 1;

            SaveLog();
        }

        public void DisplayLog()
        {
            Console.WriteLine("\n=== Activity Log ===");
            foreach (var entry in _activityCounts)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} times");
            }
            Console.WriteLine("====================\n");
        }

        private void SaveLog()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var entry in _activityCounts)
                {
                    writer.WriteLine($"{entry.Key}:{entry.Value}");
                }
            }
        }

        private void LoadLog()
        {
            if (!File.Exists(_filePath))
                return;

            foreach (var line in File.ReadAllLines(_filePath))
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int count))
                {
                    _activityCounts[parts[0]] = count;
                }
            }
        }
    }
}
