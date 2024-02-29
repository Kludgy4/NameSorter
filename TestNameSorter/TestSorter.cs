namespace TestNameSorter
{
    [TestClass]
    public class TestSorter
    {
        [TestMethod]
        public void TestSortStrings()
        {
            Assert.ThrowsException<FileNotFoundException>(() => NameSorter.Program.Main(["filename.txt"]));
        }
    }
}