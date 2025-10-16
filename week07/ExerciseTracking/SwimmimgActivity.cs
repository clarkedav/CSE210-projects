namespace ExerciseTracking
{
    public class SwimmingActivity : Activity
    {
        private int _laps;
        private const double LapLengthMeters = 50;

        public SwimmingActivity(DateTime date, double lengthMinutes, int laps)
            : base(date, lengthMinutes)
        {
            _laps = laps;
        }

        public override double GetDistance() => (_laps * LapLengthMeters / 1000) * 0.62; // miles
        public override double GetSpeed() => (GetDistance() / LengthMinutes) * 60;
        public override double GetPace() => LengthMinutes / GetDistance();
    }
}
