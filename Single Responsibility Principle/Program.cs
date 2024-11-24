using Single_Responsibility_Principle;
using System.Diagnostics;
using static System.Console;

var j = new Journal();
j.AddEntry("I cried today.");
j.AddEntry("I ate a bug.");
WriteLine(j);

var p = new JournalFiles();
var filename = $"./journal.txt";
p.SaveToFile(j, filename);
Process.Start(filename);