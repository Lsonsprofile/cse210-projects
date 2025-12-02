using System;

public class Shape
{
    private string _color; // field for color
    public Shape(string color)// constructor to initialize the color by passing a string
    {
        _color = color; // assign the color to the field
    }
    public string GetColor() // method to get the color
    {
        return _color; // return the color
    }
    // virtual method to calculate the area
    public virtual double CalculateArea()
    {
        return 0.0; // return 0.0 for the base class
    }
}