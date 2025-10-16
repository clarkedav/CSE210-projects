using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime _date;
        private double _lengthMinutes;

        public Activity(DateTime date, double lengthMinutes)
        {
            _date = date;
            _lengthMinutes = lengthMinutes;
        }

        public DateTime Date => _date;
        public double LengthMinutes => _lengthMinutes;

        // Methods to be implemented in derived classes
        public abstract double GetDistance(); // miles or km
        public abstract double GetSpeed();    // mph or kph
        public abstract double GetPace();     // min per mile or min per km

        // Summary method using other methods
        public virtual string GetSummary()
        {
            return $"{_date.ToString("dd MMM yyyy")} {this.GetType().Name} ({_lengthMinutes} min) - " +
                   $"Distance {GetDistance():0.00}, Speed {GetSpeed():0.00}, Pace {GetPace():0.00}";
        }
    }
}
