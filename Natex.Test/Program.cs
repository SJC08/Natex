// See https://aka.ms/new-console-template for more information
using Asjc.Natex;

Natex natex = new(">=1");
var b = natex.Match(1);
Console.WriteLine(b);

class MyClass()
{
    public int Number { get; set; } = 1;
}