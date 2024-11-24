using Open_Closed_Principle;
using static System.Console;

var apple = new Product("Apple", Color.Green, Size.Small);
var tree = new Product("Tree", Color.Green, Size.Large);
var house = new Product("House", Color.Blue, Size.Large);

Product[] products = { apple, tree, house };

// BEFORE OCP
var pf = new ProductOldFilter();
WriteLine("Green products (old):");
foreach (var p in pf.FilterByColor(products, Color.Green))
    WriteLine($" - {p.Name} is green");

// BEFORE OCP

// AFTER OCP
var bf = new ProductFilter();
WriteLine("Green products (new):");
foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
    WriteLine($" - {p.Name} is green");

WriteLine("Large products");
foreach (var p in bf.Filter(products, new SizeSpecification(Size.Large)))
    WriteLine($" - {p.Name} is large");

WriteLine("Large blue items");
foreach (var p in bf.Filter(products,
  new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large)))
)
{
    WriteLine($" - {p.Name} is big and blue");
}
// AFTER OCP
