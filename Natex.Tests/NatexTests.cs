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
        public void Natex5() => Assert.IsTrue(new Natex("Text:H* Number:1").Match(new Record("Hi", 1)));

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
    }
}