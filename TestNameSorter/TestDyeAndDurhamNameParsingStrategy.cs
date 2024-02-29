namespace TestNameSorter
{
    [TestClass]
    public class TestDyeAndDurhamNameParsingStrategy
    {
        [TestMethod]
        public void TestBadShortName()
        {
            var strat = new NameSorter.DyeAndDurhamNameParsingStrategy();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => strat.ParseName("Matthew"));
        }

        [TestMethod]
        public void TestBadLongName()
        {
            var strat = new NameSorter.DyeAndDurhamNameParsingStrategy();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => strat.ParseName("Matthew Anthony David Attenborough Brian"));
        }

        [TestMethod]
        public void TestShortName()
        {
            var strat = new NameSorter.DyeAndDurhamNameParsingStrategy();
            (List<string> givenNames, List<string> lastNames) = strat.ParseName("Matthew Brian");
            Assert.AreEqual(givenNames.Count, 1);
            Assert.AreEqual(givenNames[0], "Matthew");

            Assert.AreEqual(lastNames.Count, 1);
            Assert.AreEqual(lastNames[0], "Brian");
        }

        [TestMethod]
        public void TestMediumName()
        {
            var strat = new NameSorter.DyeAndDurhamNameParsingStrategy();
            (List<string> givenNames, List<string> lastNames) = strat.ParseName("Matthew Anthony Brian");
            Assert.AreEqual(givenNames.Count, 2);
            Assert.AreEqual(givenNames[0], "Matthew");
            Assert.AreEqual(givenNames[1], "Anthony");

            Assert.AreEqual(lastNames.Count, 1);
            Assert.AreEqual(lastNames[0], "Brian");
        }

        [TestMethod]
        public void TestLongName()
        {
            var strat = new NameSorter.DyeAndDurhamNameParsingStrategy();
            (List<string> givenNames, List<string> lastNames) = strat.ParseName("Matthew Anthony David Brian");
            Assert.AreEqual(givenNames.Count, 3);
            Assert.AreEqual(givenNames[0], "Matthew");
            Assert.AreEqual(givenNames[1], "Anthony");
            Assert.AreEqual(givenNames[2], "David");

            Assert.AreEqual(lastNames.Count, 1);
            Assert.AreEqual(lastNames[0], "Brian");
        }
    }
}