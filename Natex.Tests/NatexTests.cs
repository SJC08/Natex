using Asjc.Natex.Matchers;

namespace Asjc.Natex.Tests
{
    [TestClass]
    public class NatexTests
    {
        [TestMethod]
        public void Natex1() => Assert.IsTrue(new Natex(">0").Match(1));

        [TestMethod]
        public void Natex2() => Assert.IsTrue(new Natex("¡Ý1").Match(1));

        [TestMethod]
        public void Natex3() => Assert.IsFalse(new Natex("£¾1").Match(1));

        [TestMethod]
        public void Natex4() => Assert.IsTrue(new Natex("A.*D").Match("ABCD"));

        [TestMethod]
        public void Natex5() => Assert.IsTrue(new Natex("Text:H. Number:1").Match(new Record("Hi", 1)));

        [TestMethod]
        public void Natex6() => Assert.IsTrue(new Natex("1-3").Match(2));

        [TestMethod]
        public void Natex7() => Assert.IsTrue(new Natex("Text.Length:1").Match(new Record("0", 0)));

        [TestMethod]
        public void Natex8() => Assert.IsTrue(new Natex("<today>").Match(DateTime.Today));

        [TestMethod]
        public void Natex9() => Assert.IsTrue(new Natex(">2024/1/1 00:00:00").Match(new DateTime(2024, 1, 1, 12, 0, 0)));

        [TestMethod]
        public void Natex10() => Assert.IsTrue(new Natex("Record { Text = A, Number = 1 }").Match(new Record("A", 1)));

        [TestMethod]
        public void Natex11()
        {
            Natex natex = new("\\");
            natex.Match("");
            natex.Match("");
        }

        [TestMethod]
        public void Natex12()
        {
            Natex natex = new("A");
            Assert.IsFalse(natex.Match("AB"));
            natex.Mode = NatexMode.Partial;
            Assert.IsTrue(natex.Match("AB"));
        }

        [TestMethod]
        public void Natex13() => Assert.IsTrue(new Natex("0") { Mode = NatexMode.Partial }.Match("101"));

        [TestMethod]
        public void Natex14()
        {
            Natex natex = new("A");
            Assert.IsTrue(natex.Match("a"));
            natex.CaseInsensitive = false;
            Assert.IsFalse(natex.Match("a"));
        }

        [TestMethod]
        public void Natex15()
        {
            Natex natex = new("3");
            natex.Matchers.Get<PropertyMatcher>().DefaultPaths = [["Foo"], ["Text", "Length"], ["Foo"]];
            Assert.IsTrue(natex.Match(new Record("ABC", 1)));
        }

        [TestMethod]
        public void Natex16() => Assert.IsTrue(new Natex("a,b").Match(new List<string>() { "a", "b" }));

        [TestMethod]
        public void Natex17() => Assert.IsFalse(new Natex("b,a").Match(new List<string>() { "a", "b" }));

        [TestMethod]
        public void Natex18() => Assert.IsTrue(new Natex("0,>0") { Mode = NatexMode.Partial }.Match(new int[] { 0, 1, 2 }));

        [TestMethod]
        public void Natex19() => Assert.IsFalse(new Natex(">foo").Match(0));

        [TestMethod]
        public void Natex20() => Assert.IsTrue(new Natex("!1").Match(0));

        [TestMethod]
        public void Natex21() => Assert.IsTrue(new Natex("null").Match(null));

        [TestMethod]
        public void Natex22() => Assert.IsTrue(new Natex("empty").Match(string.Empty));

        [TestMethod]
        public void Natex23() => Assert.IsTrue(new Natex("empty").Match(Array.Empty<int>()));

        [TestMethod]
        public void Natex24() => Assert.IsFalse(new Natex("").Match(new object()));

        [TestMethod]
        public void Natex25() => Assert.IsTrue(new Natex("*").Match(new object()));

        [TestMethod]
        public void Natex26() => Assert.IsTrue(new Natex("6/1").Match(DateTime.Parse("6/1")));

        [TestMethod]
        public void Natex27()
        {
            Natex natex = new("{Date}");
            Assert.IsTrue(natex.Match(DateTime.Today));
            Assert.IsTrue(natex.Match(DateTime.Today));
        }

        [TestMethod]
        public void Natex28() => Assert.IsTrue(new Natex("number:0").Match(new Record("", 0)));
    }
}