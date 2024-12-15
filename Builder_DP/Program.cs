

using Builder_DP;

//Builder Simple
ICarBuilder sedanBuilder = new SedanCarBuilder();
CarDirector sedanDirector = new CarDirector(sedanBuilder);
Car sedan = sedanDirector.ConstructCar();
Console.WriteLine(sedan);

// Create the builder for SUV
ICarBuilder suvBuilder = new SUVCarBuilder();
CarDirector suvDirector = new CarDirector(suvBuilder);
Car suv = suvDirector.ConstructCar();
Console.WriteLine(suv);




//Builder Facated
var pb = new PersonBuilder();
Person person = pb
  .Lives
    .At("123 London Road")
    .In("London")
    .WithPostcode("SW12BC")
  .Works
    .At("Fabrikam")
    .AsA("Engineer")
    .Earning(123000);

Console.WriteLine(person);
