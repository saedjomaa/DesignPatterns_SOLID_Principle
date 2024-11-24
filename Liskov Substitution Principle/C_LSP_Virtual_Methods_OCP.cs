using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_Substitution_Principle
{
    /*
    * Below is an example of Virtual Methods in the base class
    * Penguins can't fly, so this method would violate LSP. 
    * A violation of LSP occurs when a subclass modifies or introduces behaviors that are incompatible with the parent class.
    * This issue the voilation of LSP will be sloved by mixing OCP with LSP to make Interface class that the flyable bird can implement it but the base class will remain the bird
    */
    public interface IFlyable
    {
        // the Bird have this option will implement it
        void Fly();
    }

    public class Bird2
    {
        // Common Bird properties and methods like below
        public virtual void Type()
        {
            Console.WriteLine("Is a Bird");
        }
    }

    public class Sparrow2 : Bird2, IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Sparrow is flying");
        }
    }

    public class Pigon2 : Bird2, IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Sparrow is flying");
        }
    }

    public class Penguin2 : Bird2
    {
        // Penguins don't fly, so they don't implement IFlyable
        public void Swim()
        {
            Console.WriteLine("Penguin is swimming");
        }
    }
}
