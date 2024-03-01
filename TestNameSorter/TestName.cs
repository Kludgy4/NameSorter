namespace TestNameSorter;

[TestClass]
public class TestName
{

    [TestMethod]
    public void TestEquals()
    {
        Assert.AreEqual(
            new NameSorter.Name((["Matthew Anthony"], ["Brian"])),
            new NameSorter.Name((["Matthew Anthony"], ["Brian"]))
        );

        Assert.AreNotEqual(
            new NameSorter.Name((["Matthew Anthony"], ["Brian"])),
            new NameSorter.Name((["Matthew Anthony"], ["Bryan"]))
        );

        Assert.AreNotEqual(
            new NameSorter.Name((["Matthew Anthony"], ["Brian"])),
            new NameSorter.Name((["Matthew Anthonee"], ["Brian"]))
        );
    }

}