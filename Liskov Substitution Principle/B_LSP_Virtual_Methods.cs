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
    public class Bird
    {
        public virtual void Type()
        {
            Console.WriteLine("Is a Bird");
        }

        public virtual void Fly()
        {
            Console.WriteLine("Bird is flying");
        }
    }

    public class Sparrow : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("Sparrow is flying");
        }
    }

    public class Pigon : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("Pigon is flying");
        }
    }

    public class Penguin : Bird
    {
        public override void Fly()
        {
            // Penguins can't fly, so this method would violate LSP.
            // We'll show it with a simple print statement to indicate it doesn't work.
            Console.WriteLine("Penguins cannot fly.");
        }
    }
}
