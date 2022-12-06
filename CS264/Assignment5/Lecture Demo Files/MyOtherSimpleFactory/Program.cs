using System;

namespace MyOtherSimpleFactory
{
    public enum ShapeType {
        Square,
        Triangle
    }

    sealed class ShapeFactory
    {
        // create shapes - refer to concrete Shape classes here
        public IShape GetShape(ShapeType Type)
        {
            IShape shape = null;
            if (Type.Equals(ShapeType.Square))
            {
                shape = new SquareShape();
            }
            else if (Type.Equals(ShapeType.Square))
            {
                shape = new TriangleShape();
            }

            return shape;
        }
    }

    // Interface instead of Abstract Class
  interface IShape
    {
        public void draw();
        public void show();

    }

    sealed internal class SquareShape : IShape
    {
        public void draw()
        {
            Console.WriteLine("SQUARE: drawing!");
        }
        public void show()
        {
            Console.WriteLine("SQUARE: showing!");
        }
    }
    sealed internal class TriangleShape : IShape
    {
        public void draw()
        {
            Console.WriteLine("TRIANGLE: drawing!");
        }
        public void show()
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
            IShape shape = shapeFactory.GetShape(ShapeType.Square);   // get a new shape

            shape.show();
            shape.draw();


            Console.ReadLine();

        }
    }
}
