using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        Shape square = new Square(5, "Red");
        Shape rect = new Rectangle(4,6,"Blue");
        Shape circle = new Circle(3, "Green");

        List<Shape> shapes = new List<Shape>();

        shapes.Add(square);
        shapes.Add(rect);
        shapes.Add(circle);

        foreach(Shape shape in shapes)
        {
            Console.WriteLine(shape.GetArea());
            Console.WriteLine(shape.GetColor());
        }
    }
}