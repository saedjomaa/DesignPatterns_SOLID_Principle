using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Closed_Principle
{
    #region Old way need to much code and you will chanage the base class if you need extra methods
    public class AreaCalculator_Old
    {
        public double CalculateArea(object shape)
        {
            if (shape is Circle_Old circle)
            {
                return Math.PI * circle.Radius * circle.Radius;
            }
            else if (shape is Rectangle_Old rectangle)
            {
                return rectangle.Width * rectangle.Height;
            }
            else
            {
                throw new ArgumentException("Shape type is not supported.");
            }
        }
    }

    public class Circle_Old
    {
        public double Radius { get; set; }
    }

    public class Rectangle_Old
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }
    #endregion


    #region New way is open for extension
    /*
     * Now, if you want to add a new shape (e.g., Triangle), you don't need to modify the AreaCalculator class at all.
     * You just create a new class that implements IShape and provides its own CalculateArea() method.
     */
    public interface IShape
    {
        double CalculateArea();
    }

    public class AreaCalculator
    {
        public double CalculateArea(IShape shape)
        {
            return shape.CalculateArea();
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Triangle : IShape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }

    #endregion
}
