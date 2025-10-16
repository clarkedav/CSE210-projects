namespace EternalQuest
{
    public class ProgressGoal : Goal
    {
        public int PointsPerUnit { get; private set; }
        public int TargetUnits { get; private set; }
        public int CurrentUnits { get; private set; }
        public int CompletionBonus { get; private set; }

        public ProgressGoal(string title, string desc, int pointsPerUnit, int targetUnits, int currentUnits = 0, int completionBonus = 0)
            : base(title, desc, 0)
        {
            PointsPerUnit = pointsPerUnit;
            TargetUnits = targetUnits;
            CurrentUnits = currentUnits;
            CompletionBonus = completionBonus;
            IsComplete = CurrentUnits >= TargetUnits;
        }

        public override int RecordEvent()
        {
            if (IsComplete) return 0;

            CurrentUnits++;
            int awarded = PointsPerUnit;

            if (CurrentUnits >= TargetUnits)
            {
                IsComplete = true;
                awarded += CompletionBonus;
            }

            return awarded;
        }

        public override string GetDetailsString()
        {
            return $"[ {(IsComplete ? 'X' : ' ')} ] {Title} ({Description}) -- Progress {CurrentUnits}/{TargetUnits}, +{PointsPerUnit} per unit";
        }

        public override string Serialize()
        {
            return $"Progress|{Title}|{Description}|{PointsPerUnit}|{TargetUnits}|{CurrentUnits}|{CompletionBonus}";
        }
    }
}
