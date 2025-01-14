

using Prototype_DP;


//TheICloneable_NotGood Class
var john = new Person(new[] { "John", "Smith" }, new TheAddress("London Road", 123));
var jane = (Person)john.Clone();
jane.TheAddress.HouseNumber = 321; // oops, John is now at 321
// this doesn't work
//var jane = john;
// but clone is typically shallow copy
jane.TheNames[0] = "Jane";
Console.WriteLine(john);
Console.WriteLine(jane);



//ThePrototype Class
ConcretePrototypeA prototypeA = new ConcretePrototypeA("Prototype A");

// Clone the prototype
ConcretePrototypeA clonedA = (ConcretePrototypeA)prototypeA.Clone();
Console.WriteLine("Original: " + prototypeA);
Console.WriteLine("Cloned: " + clonedA);

//Here the property is changed successfully
prototypeA.Name = "Hi";
clonedA.Name = "Bye";
Console.WriteLine("Original: " + prototypeA);
Console.WriteLine("Cloned: " + clonedA);

// Create a new instance of ConcretePrototypeB
ConcretePrototypeB prototypeB = new ConcretePrototypeB(101);

// Clone the prototype
ConcretePrototypeB clonedB = (ConcretePrototypeB)prototypeB.Clone();
Console.WriteLine("Original: " + prototypeB);
Console.WriteLine("Cloned: " + clonedB);




//ThePrototypeDeepCopy Class
var Salem = new Employee();
Salem.Names = new[] { "Salem", "Doe" };
Salem.Address = new Address { HouseNumber = 123, StreetName = "London Road" };
Salem.Salary = 321000;


var copy = john.DeepCopy();
copy.Names[1] = "Smith";
copy.Address.HouseNumber++;
copy.Salary = 123000;

Console.WriteLine(john);
Console.WriteLine(copy);