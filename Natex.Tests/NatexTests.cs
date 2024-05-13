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
        public void Natex8() => Assert.IsTrue(new Natex("[today]").Match(DateTime.Today));

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
            foreach (var matcher in natex.Matchers)
            {
                if (matcher is PropertyMatcher pm)
                    pm.DefaultProperties = [["Foo"], ["Text", "Length"], ["Foo"]];

            }
            Assert.IsTrue(natex.Match(new Record("ABC", 1)));
        }
    }
}