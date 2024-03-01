namespace TestNameSorter;

[TestClass]
public class TestArgumentsNum
{
    private const string BadNumArgumentsExpected = "usage: NameSorter relativeInputNamesFilePath";
    private const string yeet = "Unable to open file TestOneArgument.txt";

    [TestMethod]
    public void TestOneArgument()
    {
        using(var sw = new StringWriter())
        {
            Console.SetError(sw);
            NameSorter.Program.Main(args: ["TestOneArgument.txt"]);
            var result = sw.ToString().Split("\n")[0].Trim();
            Assert.AreEqual(yeet, result);
        }
    }

    [TestMethod]
    public void TestEmptyArguments()
    {
        using (var sw = new StringWriter())
        {
            Console.SetError(sw);
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
            Console.SetError(sw);
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
            Console.SetError(sw);
            NameSorter.Program.Main(Enumerable.Repeat("str", 500).ToArray());
            var result = sw.ToString().Trim();
            Assert.AreEqual(BadNumArgumentsExpected, result);
        }
    }
}