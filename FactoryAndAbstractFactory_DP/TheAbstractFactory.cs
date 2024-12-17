using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAndAbstractFactory_DP
{
    /*
    * The Abstract Factory design pattern is a creational pattern that allows you to create families of related or dependent objects without specifying their concrete classes. 
    * It provides an interface for creating families of related or dependent objects. 
    * This pattern is particularly useful when the system needs to be independent of how its products are created, composed, and represented.
    
    * When to Use the Abstract Factory Pattern:
        When your system should be independent of how its products are created, composed, and represented.
        When the client code needs to work with various families of related objects, but it doesn't want to explicitly specify the concrete classes.
        When you need to ensure that the products created by the factory are compatible with each other.

    * Components:
        Abstract Factory: This is an abstract class or interface that declares methods for creating abstract products.
        Concrete Factory: These are the classes that implement the abstract factory and create specific product families.
        Abstract Products: These are interfaces or abstract classes for the products that the factory will create.
        Concrete Products: These are the specific implementations of the abstract products created by the concrete factories.
     */

    //Step 1: Define Abstract Products (UI Components)
    public interface IButton
    {
        void Render();
    }
    public interface ICheckbox
    {
        void Render();
    }

    //Step 2: Define Concrete Products (Platform-Specific Components)
    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Windows Button");
        }
    }

    // Windows implementation of ICheckbox
    public class WindowsCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering Windows Checkbox");
        }
    }

    // Mac implementation of IButton
    public class MacButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Mac Button");
        }
    }

    // Mac implementation of ICheckbox
    public class MacCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering Mac Checkbox");
        }
    }

    //Step 3: Define Abstract Factory
    public interface IUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    //Step 4: Define Concrete Factories
    public class WindowsUIFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton(); // Returns a WindowsButton
        }

        public ICheckbox CreateCheckbox()
        {
            return new WindowsCheckbox(); // Returns a WindowsCheckbox
        }
    }

    // Mac Factory
    public class MacUIFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new MacButton(); // Returns a MacButton
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacCheckbox(); // Returns a MacCheckbox
        }
    }
}
