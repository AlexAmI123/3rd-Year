using System;

// Note: This core program is from:  https://refactoring.guru/design-patterns/factory-method/csharp/example
//       I did not write this program! Please refer to the code owner at link above.
//       However, I have adapted the program to use the same Shape example used earlier.

namespace MyFactoryMethod
{

    // The Creator class declares the factory method that is supposed to return
    // an object of a Product class. The Creator's subclasses usually provide
    // the implementation of this method.
    abstract class Creator
    {
        // Note that the Creator may also provide some default implementation of
        // the factory method.
        public abstract IProduct FactoryMethod();

        // Also note that, despite its name, the Creator's primary
        // responsibility is not creating products. Usually, it contains some
        // core business logic that relies on Product objects, returned by the
        // factory method. Subclasses can indirectly change that business logic
        // by overriding the factory method and returning a different type of
        // product from it.
        public string SomeOperation()
        {
            // Call the factory method to create a Product object.
            var product = FactoryMethod();
            // Now, use the product.
            var result = "Creator: The same creator's code has just worked with "
                + product.Operation();

            return result;
        }
    }

    abstract class ShapeCreator
    {
        // Note that the Creator may also provide some default implementation of
        // the factory method.
        public abstract IShape FactoryMethod();

        // Also note that, despite its name, the Creator's primary
        // responsibility is not creating products. Usually, it contains some
        // core business logic that relies on Product objects, returned by the
        // factory method. Subclasses can indirectly change that business logic
        // by overriding the factory method and returning a different type of
        // product from it.
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

    // Concrete Creators override the factory method in order to change the
    // resulting product's type.
    class ConcreteCreator1 : Creator
    {
        // Note that the signature of the method still uses the abstract product
        // type, even though the concrete product is actually returned from the
        // method. This way the Creator can stay independent of concrete product
        // classes.
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

    // The Product interface declares the operations that all concrete products
    // must implement.

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

    // Concrete Products provide various implementations of the Product
    // interface.
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

    class Program
    {
        static void Main(string[] args)

        {
            // new Client().Main();  Console.WriteLine();
            Console.WriteLine(); new ShapeClient().Main();
        }
    }

}
