using Asjc.Natex;

Natex natex = new("Number>1 Text:Hello");
Foo foo = new(1, "Hi");
var b = natex.Match(foo);
Console.WriteLine(b);

record Foo(int Number, string Text);
