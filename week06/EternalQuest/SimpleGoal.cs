namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string title, string desc, int points) : base(title, desc, points) { }
        public SimpleGoal(string title, string desc, int points, bool isComplete) : base(title, desc, points)
        {
            IsComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (IsComplete) return 0;
            IsComplete = true;
            return Points;
        }

        public override string GetDetailsString()
        {
            return $"[ {(IsComplete ? 'X' : ' ')} ] {Title} ({Description})";
        }

        public override string Serialize()
        {
            return $"Simple|{Title}|{Description}|{Points}|{IsComplete}";
        }
    }
}
