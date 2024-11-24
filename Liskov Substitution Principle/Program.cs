using Liskov_Substitution_Principle;
using static System.Console;

static int Area(Rectangle r) => r.Width * r.Height;


Rectangle rc = new Rectangle(2, 3);
WriteLine($"{rc} has area {Area(rc)}");

// should be able to substitute a base type for a subtype
/*Square*/
Rectangle sq = new Square();
sq.Width = 4;
WriteLine($"{sq} has area {Area(sq)}");

