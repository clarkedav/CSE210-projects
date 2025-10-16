using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public int Points { get; protected set; }
        public bool IsComplete { get; protected set; }

        protected Goal() { }

        protected Goal(string title, string description, int points)
        {
            Title = title;
            Description = description;
            Points = points;
            IsComplete = false;
        }

        public abstract int RecordEvent();
        public abstract string GetDetailsString();
        public abstract string Serialize();

        public static Goal Deserialize(string line)
        {
            var parts = line.Split('|');
            if (parts.Length == 0) return null;
            string type = parts[0];
            switch (type)
            {
                case "Simple":
                    return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                case "Eternal":
                    return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                case "Checklist":
                    return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
                case "Progress":
                    return new ProgressGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                default:
                    return null;
            }
        }
    }
}
