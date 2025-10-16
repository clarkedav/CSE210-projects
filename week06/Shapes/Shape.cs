using System;

namespace Shapes
{
    public abstract class Shape
    {
        private string _color;

        // Constructor
        public Shape(string color)
        {
            _color = color;
        }

        // Getter and setter
        public string GetColor()
        {
            return _color;
        }

        public void SetColor(string color)
        {
            _color = color;
        }

        // Virtual or abstract method for polymorphism
        public abstract double GetArea();
    }
}
