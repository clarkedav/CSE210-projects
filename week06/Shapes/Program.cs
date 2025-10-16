using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of shapes
            List<Shape> shapes = new List<Shape>();

            // Add different shape objects (polymorphism in action!)
            shapes.Add(new Square("Red", 5));
            shapes.Add(new Rectangle("Blue", 4, 6));
            shapes.Add(new Circle("Green", 3));

            // Loop through all shapes and display their color + computed area
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Shape color: {shape.GetColor()}");
                Console.WriteLine($"Area: {shape.GetArea():F2}");
                Console.WriteLine();
            }
        }
    }
}
