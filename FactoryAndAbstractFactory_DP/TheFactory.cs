using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAndAbstractFactory_DP
{
    /*
     * The Factory Design Pattern is a creational design pattern used to abstract the process of object creation. 
     * It provides an interface for creating objects but allows subclasses or classes to alter the type of objects that will be created. 
     * This pattern is often used when there is a need to create objects of different types based on certain conditions, but without exposing the object creation logic to the client.
     
     * Benefits of the Factory Design Pattern:
        Factory Method: A method that is responsible for creating objects, but the actual class of the object is determined at runtime.
        Encapsulation: The object creation logic is hidden, and the client uses a common interface to obtain the required object without knowing how it is created.
        Flexibility: The client code is decoupled from the specific classes that need to be instantiated, making it easier to add new classes without changing the client code.
     
     * Components:
        Product: The common interface or abstract class that defines the object that is being created.
        ConcreteProduct: The actual implementation of the product interface or abstract class.
        Creator (Factory): An abstract class or interface that declares the factory method.
        ConcreteCreator: A class that implements the factory method to instantiate the concrete product.
     */

    //Step 1: Define the Shape interface
    public interface IShape
    {
        void Draw();
    }

    //Step 2: Create concrete Shape classes
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Circle");
        }
    }
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Square");
        }
    }

    //Step 3: Define the ShapeFactory (Creator)
    public abstract class ShapeFactory
    {
        public abstract IShape CreateShape();
    }

    //Step 4: Create Concrete ShapeFactory classes
    public class CircleFactory : ShapeFactory
    {
        public override IShape CreateShape()
        {
            return new Circle(); // Return a new Circle object
        }
    }
    public class SquareFactory : ShapeFactory
    {
        public override IShape CreateShape()
        {
            return new Square(); // Return a new Square object
        }
    }
}
