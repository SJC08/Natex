using Asjc.Natex;

Natex natex = new("Number:>=1 Text:H*");
Foo foo = new(1, "Hi");
var b = natex.Match(foo);
Console.WriteLine(b);

record Foo(int Number, string Text);
