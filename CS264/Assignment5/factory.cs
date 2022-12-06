abstract class Creator
{
    public abstract IProduct FactoryMethod();

    public string SomeOperation()
    {
        var product = FactoryMethod();
        var result = "Creator: The same creator's code has just worked with "
            + product.Operation();

        return result;
    }
}
abstract class ShapeCreator
{
    public abstract IShape FactoryMethod();

    public string SomeOperation()
    {
        // Call the factory method to create a Product object.
        var shape = FactoryMethod();
        // Now, use the product.
        var result = "Creator: The same creator's code has just worked with ["
            + shape.Operation() + "]";

        return result;
    }
}
class ConcreteCreator1 : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct1();
    }
}
class ConcreteCreator2 : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct2();
    }
}
class SquareFactory : ShapeCreator
{
    public override IShape FactoryMethod()
    {
        return new SquareShape();
    }
}

class TriangleFactory : ShapeCreator
{
    public override IShape FactoryMethod()
    {
        return new TriangleShape();
    }
}
public interface IProduct
{
    string Operation();
}

public interface IShape
{

    public void draw();
    public void show();
    public string Operation();
}
class ConcreteProduct1 : IProduct
{
    public string Operation()
    {
        return "{Result of ConcreteProduct1}";
    }
}
class SquareShape : IShape
{
    public void draw()
    {
        Console.WriteLine("SQUARE: drawing!");
    }
    public void show()
    {
        Console.WriteLine("SQUARE: showing!");
    }
    public string Operation()
    {
        return "SQUARE";
    }
}
class ConcreteProduct2 : IProduct
{
    public string Operation()
    {
        return "{Result of ConcreteProduct2}";
    }
}

class TriangleShape : IShape
{
    public void draw()
    {
        Console.WriteLine("TRIANGLE: drawing!");
    }
    public void show()
    {
        Console.WriteLine("TRIANGLE: showing!");
    }
    public string Operation()
    {
        return "TRIANGLE";
    }
}

class Client
{
    public void Main()
    {
        Console.WriteLine("App: Launched with the ConcreteCreator1.");
        ClientCode(new ConcreteCreator1());

        Console.WriteLine();

        Console.WriteLine("App: Launched with the ConcreteCreator2.");
        ClientCode(new ConcreteCreator2());
    }

    // The client code works with an instance of a concrete creator, albeit
    // through its base interface. As long as the client keeps working with
    // the creator via the base interface, you can pass it any creator's
    // subclass.
    public void ClientCode(Creator creator)
    {
        // ...
        Console.WriteLine("Client: I'm not aware of the creator's class," +
            "but it still works.\n" + creator.SomeOperation());
        // ...
    }

}

class ShapeClient
{
    public void Main()
    {
        Console.WriteLine("App: Launched with SquareShape: ");
        ClientCode(new SquareFactory());

        Console.WriteLine();

        Console.WriteLine("App: Launched with TriangleShape: ");
        ClientCode(new TriangleFactory());
    }

    // The client code works with an instance of a concrete creator, albeit
    // through its base interface. As long as the client keeps working with
    // the creator via the base interface, you can pass it any creator's
    // subclass.
    public void ClientCode(ShapeCreator creator)
    {
        Console.WriteLine("Client: I am not aware of the creator's class, but it still works: [{0}]:"+ 
                            Environment.NewLine,creator.SomeOperation());
    }

}
