using System;
using System.Collections.Generic;
namespace Codewars.ShapeSort;

public abstract class Shape : IComparable<Shape>
{
    // Abstract property that each shape must implement.
    public abstract double Area { get; }

    // Compare shapes based on their area.
    public int CompareTo(Shape other)
    {
        if (other == null) return 1;
        return this.Area.CompareTo(other.Area);
    }
}

public class Square : Shape
{
    public double Side { get; }
    
    public Square(double side)
    {
        Side = side;
    }
    
    public override double Area => Side * Side;
}

public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }
    
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    
    public override double Area => Width * Height;
}

public class Triangle : Shape
{
    public double Base { get; }
    public double Height { get; }
    
    public Triangle(double @base, double height)
    {
        Base = @base;
        Height = height;
    }
    
    public override double Area => (Base * Height) / 2;
}

public class Circle : Shape
{
    public double Radius { get; }
    
    public Circle(double radius)
    {
        Radius = radius;
    }
    
    public override double Area => Math.PI * Radius * Radius;
}

public class CustomShape : Shape
{
    public double CustomArea { get; }
    
    public CustomShape(double area)
    {
        CustomArea = area;
    }
    
    public override double Area => CustomArea;
}
