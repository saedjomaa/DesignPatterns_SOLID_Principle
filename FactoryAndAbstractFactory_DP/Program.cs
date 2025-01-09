using FactoryAndAbstractFactory_DP;


//Factory Implementation
ShapeFactory circleFactory = new CircleFactory();
IShape circle = circleFactory.CreateShape();// here we create one instance and we specify the concrete class
circle.Draw();  // Output: Drawing a Circle

// Using Square Factory
ShapeFactory squareFactory = new SquareFactory();
IShape square = squareFactory.CreateShape();
square.Draw();  // Output: Drawing a Square




//Abstract Factory Implementation
static IUIFactory GetFactory(string os)
{
    if (os == "Windows")
        return new WindowsUIFactory();// here we create one instance that have many or families of instances can be created and we didn't specify the concrete class we only create the container that will create the required instance as needed
    else if (os == "Mac")
        return new MacUIFactory();
    else
        throw new ArgumentException("Unknown OS");
}


IUIFactory factory = GetFactory("Windows");
IButton button = factory.CreateButton();
ICheckbox checkbox = factory.CreateCheckbox();

button.Render(); // Output: Rendering Windows Button
checkbox.Render(); // Output: Rendering Windows Checkbox

// Switch to Mac UI factory
factory = GetFactory("Mac");
button = factory.CreateButton();
checkbox = factory.CreateCheckbox();

button.Render(); // Output: Rendering Mac Button
checkbox.Render(); // Output: Rendering Mac Checkbox