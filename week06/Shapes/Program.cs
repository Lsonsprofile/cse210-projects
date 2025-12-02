using System;

class Program
{
    static void Main(string[] args)
    {
        // craete a list that hold shape objects of any kind and add some shapes to it
        List<Shape> shapes = new List<Shape>();
        // add different king of shapes to the list with their colors 
        shapes.Add(new Circle("red", 3));
        shapes.Add(new Rectangle("blue", 2, 4));
        shapes.Add(new Square("green", 5));
        shapes.Add(new Circle("yellow", 7));
        shapes.Add(new Rectangle("purple", 6, 8));
        shapes.Add(new Square("orange", 9));

        // print out the area of each shape in the list
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.CalculateArea();

            Console.WriteLine($"The area of the {color} shape is {area:F2}");
        }
    }
}