namespace ExerciseTracking
{
    public class CyclingActivity : Activity
    {
        private double _speedMph;

        public CyclingActivity(DateTime date, double lengthMinutes, double speedMph)
            : base(date, lengthMinutes)
        {
            _speedMph = speedMph;
        }

        public override double GetDistance() => (_speedMph * LengthMinutes) / 60.0;
        public override double GetSpeed() => _speedMph;
        public override double GetPace() => 60 / _speedMph;
    }
}
