using System;

public class Square : Shape
{
    private double _side;
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }
    public override double CalculateArea() //override method to calculate area in square
    {
        return _side * _side;
    }

}