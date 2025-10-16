using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        public List<Goal> Goals { get; private set; } = new List<Goal>();
        public int Score { get; private set; } = 0;
        public int Level { get; private set; } = 1;
        public HashSet<string> Badges { get; private set; } = new HashSet<string>();
        private readonly string saveFile = "savefile.txt";

        public GoalManager()
        {
            if (File.Exists(saveFile))
                Load();
        }

        public void AddGoal(Goal g) => Goals.Add(g);

        public void RecordGoalEvent(int goalIndex)
        {
            if (goalIndex < 0 || goalIndex >= Goals.Count) return;
            var g = Goals[goalIndex];
            int points = g.RecordEvent();
            if (points > 0)
            {
                AddScore(points);
                Console.WriteLine($"You earned {points} points!");
            }
            else
            {
                Console.WriteLine("No points (goal may already be completed).");
            }
        }

        private void AddScore(int points)
        {
            Score += points;
            CheckLevelUp();
            CheckBadges();
        }

        private void CheckLevelUp()
        {
            int newLevel = Score / 1000 + 1;
            if (newLevel > Level)
            {
                Console.WriteLine($"--- Level up! {Level} -> {newLevel} ---");
                Level = newLevel;
            }
        }

        private void CheckBadges()
        {
            var thresholds = new Dictionary<int, string> {
                {500, "Bronze Badge"}, {1000, "Silver Badge"}, {2500, "Gold Badge"}, {5000, "Platinum Badge"}
            };
            foreach (var t in thresholds)
            {
                if (Score >= t.Key && !Badges.Contains(t.Value))
                {
                    Badges.Add(t.Value);
                    Console.WriteLine($"*** You earned a badge: {t.Value}! ***");
                }
            }
        }

        public void ShowGoals()
        {
            Console.WriteLine();
            Console.WriteLine("Your Goals:");
            for (int i = 0; i < Goals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {Goals[i].GetDetailsString()}");
            }
            Console.WriteLine();
        }

        public void ShowStatus()
        {
            Console.WriteLine();
            Console.WriteLine($"Score: {Score}   Level: {Level}");
            Console.WriteLine(Badges.Count > 0 ? "Badges: " + string.Join(", ", Badges) : "Badges: (none)");
            Console.WriteLine();
        }

        public void Save()
        {
            var lines = new List<string> { $"SCORE:{Score}" };
            foreach (var g in Goals) lines.Add(g.Serialize());
            File.WriteAllLines(saveFile, lines);
            Console.WriteLine($"Saved to {saveFile}");
        }

        public void Load()
        {
            try
            {
                var lines = File.ReadAllLines(saveFile);
                Goals.Clear();
                foreach (var line in lines)
                {
                    if (line.StartsWith("SCORE:"))
                    {
                        Score = int.Parse(line.Substring(6));
                        Level = Score / 1000 + 1;
                        CheckBadges();
                    }
                    else
                    {
                        var g = Goal.Deserialize(line);
                        if (g != null) Goals.Add(g);
                    }
                }
                Console.WriteLine($"Loaded {Goals.Count} goals and score {Score} from {saveFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load savefile: " + ex.Message);
            }
        }
    }
}
