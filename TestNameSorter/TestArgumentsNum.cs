namespace TestNameSorter;

[TestClass]
public class TestArgumentsNum
{
    private const string BadNumArgumentsExpected = "usage: NameSorter relativeInputNamesFilePath";

    [TestMethod]
    public void TestOneArgument()
    {
        Assert.ThrowsException<FileNotFoundException>(() => NameSorter.Program.Main(["filename.txt"]));
    }

    [TestMethod]
    public void TestNullArguments()
    {
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            NameSorter.Program.Main(args: null);
            var result = sw.ToString().Trim();
            Assert.AreEqual(BadNumArgumentsExpected, result);
        }
    }

    [TestMethod]
    public void TestEmptyArguments()
    {
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            NameSorter.Program.Main(args: []);
            var result = sw.ToString().Trim();
            Assert.AreEqual(BadNumArgumentsExpected, result);
        }
    }

    [TestMethod]
    public void TestTooManyArgumentsSmall()
    {
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            NameSorter.Program.Main(["str", "str"]);
            var result = sw.ToString().Trim();
            Assert.AreEqual(BadNumArgumentsExpected, result);
        }
    }

    [TestMethod]
    public void TestTooManyArgumentsLarge()
    {
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            NameSorter.Program.Main(Enumerable.Repeat("str", 500).ToArray());
            var result = sw.ToString().Trim();
            Assert.AreEqual(BadNumArgumentsExpected, result);
        }
    }
}