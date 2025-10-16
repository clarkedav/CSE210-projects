namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        public int TimesRequired { get; private set; }
        public int BonusPoints { get; private set; }
        public int TimesCompleted { get; private set; }

        public ChecklistGoal(string title, string desc, int pointsPer, int timesRequired, int bonus)
            : base(title, desc, pointsPer)
        {
            TimesRequired = timesRequired;
            BonusPoints = bonus;
            TimesCompleted = 0;
        }

        public ChecklistGoal(string title, string desc, int pointsPer, int timesRequired, int bonus, int timesCompleted)
            : base(title, desc, pointsPer)
        {
            TimesRequired = timesRequired;
            BonusPoints = bonus;
            TimesCompleted = timesCompleted;
            IsComplete = timesCompleted >= timesRequired;
        }

        public override int RecordEvent()
        {
            if (IsComplete) return 0;
            TimesCompleted++;
            int awarded = Points;
            if (TimesCompleted >= TimesRequired)
            {
                IsComplete = true;
                awarded += BonusPoints;
            }
            return awarded;
        }

        public override string GetDetailsString()
        {
            return $"[ {(IsComplete ? 'X' : ' ')} ] {Title} ({Description}) -- Completed {TimesCompleted}/{TimesRequired}";
        }

        public override string Serialize()
        {
            return $"Checklist|{Title}|{Description}|{Points}|{TimesRequired}|{BonusPoints}|{TimesCompleted}";
        }
    }
}
