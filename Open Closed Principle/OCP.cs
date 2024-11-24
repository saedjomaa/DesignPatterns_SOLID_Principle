using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Closed_Principle
{
    /*
    * Open Closed Principle = open for extension but closed for modification
    * Open Closed Principle is the ISpecification & IFilter Interfaces for filtering as a strong example.
    * Without it as the ProductFilter example will ... state space explosion (too much code will added) if we want to make 3 criteria then we need 7 methods
   
    */

    /*
    * yield allows the code inside the iterator method to "yield" each item in the collection, one at a time, rather than returning the entire collection all at once.
    * So the compiler will know that the collection will be returned but one by one
    * Do you think it has a performance issue? No. memory consumption is not affected because there is no additional temporary lists to store the results
    * 
    * New School
    public IEnumerable<T> GetList1()
       {
           foreach( var item in collection )
               yield return item.Property;
       }

    * Old School
       public IEnumerable<T> GetList2()
       {
           List<T> outputList = new List<T>( collection.Count() );
           foreach( var item in collection )
               outputList.Add( item.Property );

           return outputList;
       }
      */


    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Yuge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Color = color;
            Size = size;
        }
    }
    #region Old way need to much code
    public class ProductOldFilter
    {
        // let's suppose we don't want ad-hoc queries on products
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
                if (p.Color == color)
                    yield return p;

        }

        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
                if (p.Size == size)
                    yield return p;
        }

        public static IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (var p in products)
                if (p.Size == size && p.Color == color)
                    yield return p;
        }

        // state space explosion
        // 3 criteria = 7 methods
    }
    #endregion


    #region New way is open for extension
    // we introduce two new interfaces that are open for extension
    public interface ISpecification<T>
    {
        bool IsSatisfied(Product p);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Product p)
        {
            return p.Color == color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }

        public bool IsSatisfied(Product p)
        {
            return p.Size == size;
        }
    }

    // combinator
    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }

        public bool IsSatisfied(Product p)
        {
            return first.IsSatisfied(p) && second.IsSatisfied(p);
        }
    }

    public class ProductFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
                if (spec.IsSatisfied(i))
                    yield return i;
        }
    }

    #endregion

}
