sealed class Factory
{
    public Shape GetShape(String Type)
    {
        Shape shape = null;
        if (Type.Equals("square"))
        {
            shape = new SquareShape();
        }
        else if (Type.Equals("triangle"))
        {
            shape = new TriangleShape();
        }
        else if (Type.Equals("circle"))
        {
            shape = new CircleShape();
        }
        else if (Type.Equals("ellipse"))
        {
            shape = new EllipseShape();
        }
        else if (Type.Equals("line"))
        {
            shape = new LineShape();
        }
        else if (Type.Equals("path"))
        {
            shape = new PathShape();
        }
        else if (Type.Equals("pathline"))
        {
            shape = new PathlineShape();
        }
        else if (Type.Equals("polygon"))
        {
            shape = new PolygonShape();
        }
        return shape;
    }
}
abstract class Shape
{
    internal abstract void draw();
    internal abstract void show();
}

sealed internal class SquareShape : Shape
{
    internal override void draw()
    {
        Console.WriteLine("Square: drawing!");
    }
    internal override void show()
    {
        Console.WriteLine("Square: showing!");
    }
}
sealed internal class TriangleShape : Shape
{
    internal override void draw()
    {
        Console.WriteLine("Triangle: drawing!");
    }
    internal override void show()
    {
        Console.WriteLine("Triangle: showing!");
    }
}
sealed internal class CircleShape : Shape
{
    internal override void draw()
    {
        Console.WriteLine("Circle: drawing!");
    }
    internal override void show()
    {
        Console.WriteLine("Circle: showing!");
    }
}
sealed internal class EllipseShape : Shape
{
    internal override void draw()
    {
        Console.WriteLine("Ellipse: drawing!");
    }
    internal override void show()
    {
        Console.WriteLine("Ellipse: showing!");
    }
}
sealed internal class LineShape : Shape
{
    internal override void draw()
    {
        Console.WriteLine("Line: drawing!");
    }
    internal override void show()
    {
        Console.WriteLine("Line: showing!");
    }
}
sealed internal class PathShape : Shape
{
    internal override void draw()
    {
        Console.WriteLine("Path: drawing!");
    }
    internal override void show()
    {
        Console.WriteLine("Path: showing!");
    }
}
sealed internal class PathlineShape : Shape
{
    internal override void draw()
    {
        Console.WriteLine("Pathline: drawing!");
    }
    internal override void show()
    {
        Console.WriteLine("Pathline: showing!");
    }
}
sealed internal class PolygonShape : Shape
{
    internal override void draw()
    {
        Console.WriteLine("Polygon: drawing!");
    }
    internal override void show()
    {
        Console.WriteLine("Polygon: showing!");
    }
}
