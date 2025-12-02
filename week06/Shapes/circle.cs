using System;

public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)// base is the parent class constructor
    // double raduis and string color are the parameters for the parent class constructor
    {
        _radius = radius;
    }
    public override double CalculateArea() // override is used to override the parent class method
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}