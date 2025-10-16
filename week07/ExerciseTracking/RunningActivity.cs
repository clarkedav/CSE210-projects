namespace ExerciseTracking
{
    public class RunningActivity : Activity
    {
        private double _distanceMiles;

        public RunningActivity(DateTime date, double lengthMinutes, double distanceMiles)
            : base(date, lengthMinutes)
        {
            _distanceMiles = distanceMiles;
        }

        public override double GetDistance() => _distanceMiles;
        public override double GetSpeed() => (_distanceMiles / LengthMinutes) * 60;
        public override double GetPace() => LengthMinutes / _distanceMiles;
    }
}
