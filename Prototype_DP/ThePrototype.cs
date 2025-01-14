using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_DP
{
    /*
     * The Prototype Design Pattern is: a creational design pattern that allows cloning objects, rather than creating new instances from scratch.
     * Purpose: This pattern is particularly useful when creating new objects is more costly than copying existing ones.
     * The prototype pattern typically involves defining a prototype interface with a method for cloning itself.
     
     * When to use Prototype Pattern:
        When object creation is a costly operation.
        When you need to create many objects of the same type, each with different properties.

     
     * Components:
         Prototype Interface: Defines the Clone() method to create a copy of the object.
         Concrete Prototypes: Classes that implement the Prototype interface and define how to clone themselves.
         Client: The class that uses the prototype to clone objects.
     */



    //Step 1: defining a prototype interface with a method for cloning itself
    public interface IPrototype
    {
        IPrototype Clone();
    }

    //Step 2: Concrete Prototype 1
    public class ConcretePrototypeA : IPrototype
    {
        public string Name { get; set; }

        public ConcretePrototypeA(string name)
        {
            Name = name;
        }

        // Implement the Clone method
        public IPrototype Clone()
        {
            // Shallow copy for simplicity
            return new ConcretePrototypeA(Name);
        }

        public override string ToString()
        {
            return $"ConcretePrototypeA with Name: {Name}";
        }
    }

    // Concrete Prototype 2
    public class ConcretePrototypeB : IPrototype
    {
        public int Id { get; set; }

        public ConcretePrototypeB(int id)
        {
            Id = id;
        }

        // Implement the Clone method
        public IPrototype Clone()
        {
            // Shallow copy for simplicity
            return new ConcretePrototypeB(Id);
        }

        public override string ToString()
        {
            return $"ConcretePrototypeB with Id: {Id}";
        }
    }
}
