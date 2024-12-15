using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_DP
{
    /*
      * The Builder Design Pattern is a creational pattern that provides a way to construct a complex object step by step. 
      * This pattern allows you to create different representations of an object using the same construction process. 
      * It's especially useful when you need to create objects that require multiple steps, or when you want to avoid creating objects with constructors that take too many parameters (known as the telescoping constructor anti-pattern).
      * 
      * Components:
          * Product: The complex object that is being constructed.
          * Builder: Abstract class or interface that defines the methods for building parts of the product.
          * Concrete Builder: A class that implements the builder interface and provides specific implementations of the building methods.
          * Director: A class that constructs the object using the builder interface.
     */


    //Step 1: Define the Product (Car)
    public class Car
    {
        public string Engine { get; set; }
        public int Wheels { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return $"Car with {Engine}, {Wheels} wheels, and color {Color}.";
        }
    }

    //Step 2: Create the Builder Interface
    public interface ICarBuilder
    {
        void BuildEngine();
        void BuildWheels();
        void BuildColor();
        Car GetCar();
    }

    //Step 3: Concrete Builder Implementation
    public class SedanCarBuilder : ICarBuilder
    {
        private Car _car = new Car();

        public void BuildEngine()
        {
            _car.Engine = "V6 Engine";
        }

        public void BuildWheels()
        {
            _car.Wheels = 4;
        }

        public void BuildColor()
        {
            _car.Color = "Red";
        }

        public Car GetCar()
        {
            return _car;
        }
    }

    public class SUVCarBuilder : ICarBuilder
    {
        private Car _car = new Car();

        public void BuildEngine()
        {
            _car.Engine = "V8 Engine";
        }

        public void BuildWheels()
        {
            _car.Wheels = 4;
        }

        public void BuildColor()
        {
            _car.Color = "Black";
        }

        public Car GetCar()
        {
            return _car;
        }
    }

    //Step 4: Director
    public class CarDirector
    {
        private ICarBuilder _builder;

        public CarDirector(ICarBuilder builder)
        {
            _builder = builder;
        }

        public Car ConstructCar()
        {
            _builder.BuildEngine();
            _builder.BuildWheels();
            _builder.BuildColor();
            return _builder.GetCar();
        }
    }
}
