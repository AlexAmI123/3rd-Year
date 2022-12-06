using System;

namespace MySimpleFactory
{

    sealed class ShapeFactory
    {
        // create shapes - refer to concrete Shape classes here
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

            return shape;
        }
    }

    // Abstract Class
    abstract class Shape
    {
        internal abstract void draw();
        internal abstract void show();

    }

    sealed internal class SquareShape : Shape
    {
        internal override void draw()
        {
            Console.WriteLine("SQUARE: drawing!");
        }
        internal override void show()
        {
            Console.WriteLine("SQUARE: showing!");
        }
    }
    sealed internal class TriangleShape : Shape
    {
        internal override void draw()
        {
            Console.WriteLine("TRIANGLE: drawing!");
        }
        internal override void show()
        {
            Console.WriteLine("TRIANGLE: showing!");
        }
    }

    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.NewLine + "Simple Factory:" + Environment.NewLine);

            ShapeFactory shapeFactory = new ShapeFactory();           // factory instance
            Shape shape = shapeFactory.GetShape("square");            // get a new shape

            shape.show();
            shape.draw();

            Console.ReadLine();

            shape = shapeFactory.GetShape("triangle");

            shape.show();
            shape.draw();

            Console.ReadLine();

        }
    }
}


