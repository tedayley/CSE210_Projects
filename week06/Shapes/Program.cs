using System;
using System.Collections.Generic;

// Base class
abstract class Shape
{
    public string Color { get; set; }

    public Shape(string color)
    {
        Color = color;
    }

    public abstract double ComputeArea();

    public override string ToString()
    {
        return $"{this.GetType().Name} ({Color})";
    }
}

// Derived class for Square
class Square : Shape
{
    public double Side { get; set; }

    public Square(string color, double side) : base(color)
    {
        Side = side;
    }

    public override double ComputeArea()
    {
        return Side * Side;
    }
}

// Derived class for Rectangle
class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(string color, double length, double width) : base(color)
    {
        Length = length;
        Width = width;
    }

    public override double ComputeArea()
    {
        return Length * Width;
    }
}

// Derived class for Circle
class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(string color, double radius) : base(color)
    {
        Radius = radius;
    }

    public override double ComputeArea()
    {
        return Math.PI * Radius * Radius;
    }
}

class Program
{
    static void Main()
    {
        // Create a list of shapes
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 4),
            new Rectangle("Blue", 5, 3),
            new Circle("Green", 2.5),
            new Square("Yellow", 6),
            new Rectangle("Purple", 7, 2)
        };

        // Iterate and display areas
        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape}: Area = {shape.ComputeArea():F2}");
        }
    }
}
