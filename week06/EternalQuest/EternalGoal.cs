namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string title, string desc, int points) : base(title, desc, points) { }

        public override int RecordEvent()
        {
            return Points;
        }

        public override string GetDetailsString()
        {
            return $"[ ~ ] {Title} ({Description}) - repeatable, +{Points} pts each time";
        }

        public override string Serialize()
        {
            return $"Eternal|{Title}|{Description}|{Points}";
        }
    }
}
