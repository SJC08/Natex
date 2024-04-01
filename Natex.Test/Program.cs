// See https://aka.ms/new-console-template for more information
using Asjc.Natex;

Natex natex = new("Number:>=1");
var b = natex.Match(new MyClass() { Number = 1});
Console.WriteLine(b);

class MyClass()
{
    public int Number { get; set; } = 1;
}