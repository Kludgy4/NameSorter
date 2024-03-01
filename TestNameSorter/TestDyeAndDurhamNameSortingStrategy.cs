namespace TestNameSorter;

[TestClass]
public class TestDyeAndDurhamNameSortingStrategy
{

    [TestMethod]
    public void TestExampleUsage()
    {
        List<NameSorter.Name> exampleNames = new List<NameSorter.Name> {
            new NameSorter.Name((["Janet"], ["Parsons"])),
            new NameSorter.Name((["Vaughn"], ["Lewis"])),
            new NameSorter.Name((["Adonis Julius"], ["Archer"])),
            new NameSorter.Name((["Shelby Nathan"], ["Yoder"])),
            new NameSorter.Name((["Marin"], ["Alvarez"])),
            new NameSorter.Name((["London"], ["Lindsey"])),
            new NameSorter.Name((["Beau Tristan"], ["Bentley"])),
            new NameSorter.Name((["Leo"], ["Gardner"])),
            new NameSorter.Name((["Hunter Uriah Mathew"], ["Clarke"])),
            new NameSorter.Name((["Mikayla"], ["Lopez"])),
            new NameSorter.Name((["Frankie Conner"], ["Ritter"])),
        };
        
        var strat = new NameSorter.DyeAndDurhamNameSortingStrategy();
        exampleNames.Sort(strat);

        List<NameSorter.Name> exampleNamesSorted = new List<NameSorter.Name> {
            new NameSorter.Name((["Marin"], ["Alvarez"])),
            new NameSorter.Name((["Adonis Julius"], ["Archer"])),
            new NameSorter.Name((["Beau Tristan"], ["Bentley"])),
            new NameSorter.Name((["Hunter Uriah Mathew"], ["Clarke"])),
            new NameSorter.Name((["Leo"], ["Gardner"])),
            new NameSorter.Name((["Vaughn"], ["Lewis"])),
            new NameSorter.Name((["London"], ["Lindsey"])),
            new NameSorter.Name((["Mikayla"], ["Lopez"])),
            new NameSorter.Name((["Janet"], ["Parsons"])),
            new NameSorter.Name((["Frankie Conner"], ["Ritter"])),
            new NameSorter.Name((["Shelby Nathan"], ["Yoder"])),
        };

        Assert.IsTrue(compareNameLists(exampleNames, exampleNamesSorted));
    }

    [TestMethod]
    public void TestIdenticalFirstNames()
    {
        List<NameSorter.Name> names = new List<NameSorter.Name> {
            new NameSorter.Name((["William Henry"], ["Vanderbilt"])),
            new NameSorter.Name((["William Henry"], ["Harrison"])),
            new NameSorter.Name((["Jeffrey Preston"], ["Jorgensen"])),
            new NameSorter.Name((["Steven Paul"], ["Jobs"])),
            new NameSorter.Name((["William Henry"], ["Gates"])),
            new NameSorter.Name((["Mark Elliot"], ["Zuckerberg"])),
            new NameSorter.Name((["Wilmot Reed"], ["Hastings"])),
            new NameSorter.Name((["Sergey Mikhailovich"], ["Brin"])),
            new NameSorter.Name((["Lawrence Edward"], ["Page"])),
        };
        // TODO: Should randomise the order of names arrays then run several times

        var strat = new NameSorter.DyeAndDurhamNameSortingStrategy();
        names.Sort(strat);

        List<NameSorter.Name> namesSorted = new List<NameSorter.Name> {
            new NameSorter.Name((["Sergey Mikhailovich"], ["Brin"])),
            new NameSorter.Name((["William Henry"], ["Gates"])),
            new NameSorter.Name((["William Henry"], ["Harrison"])),
            new NameSorter.Name((["Wilmot Reed"], ["Hastings"])),
            new NameSorter.Name((["Steven Paul"], ["Jobs"])),
            new NameSorter.Name((["Jeffrey Preston"], ["Jorgensen"])),
            new NameSorter.Name((["Lawrence Edward"], ["Page"])),
            new NameSorter.Name((["William Henry"], ["Vanderbilt"])),
            new NameSorter.Name((["Mark Elliot"], ["Zuckerberg"])),
        };

        Assert.IsTrue(compareNameLists(names, namesSorted));
    }

    [TestMethod]
    public void TestIdenticalLastNames()
    {
        List<NameSorter.Name> names = new List<NameSorter.Name> {
            new NameSorter.Name((["Jeffrey Preston"], ["Jorgensen"])),
            new NameSorter.Name((["Steven Paul"], ["Jobs"])),
            new NameSorter.Name((["William Henry"], ["Gates"])),
            new NameSorter.Name((["Mark Elliot"], ["Zuckerberg"])),
            new NameSorter.Name((["Shaun"], ["Hastings"])),
            new NameSorter.Name((["Wilmot Reed"], ["Hastings"])),
            new NameSorter.Name((["Sergey Mikhailovich"], ["Brin"])),
            new NameSorter.Name((["Lawrence Edward"], ["Page"])),
        };

        var strat = new NameSorter.DyeAndDurhamNameSortingStrategy();
        names.Sort(strat);

        List<NameSorter.Name> namesSorted = new List<NameSorter.Name> {
            new NameSorter.Name((["Sergey Mikhailovich"], ["Brin"])),
            new NameSorter.Name((["William Henry"], ["Gates"])),
            new NameSorter.Name((["Shaun"], ["Hastings"])),
            new NameSorter.Name((["Wilmot Reed"], ["Hastings"])),
            new NameSorter.Name((["Steven Paul"], ["Jobs"])),
            new NameSorter.Name((["Jeffrey Preston"], ["Jorgensen"])),
            new NameSorter.Name((["Lawrence Edward"], ["Page"])),
            new NameSorter.Name((["Mark Elliot"], ["Zuckerberg"])),
        };

        Assert.IsTrue(compareNameLists(names, namesSorted));
    }

    [TestMethod]
    public void TestIdenticalLastNamesSimilarFirstNames()
    {
        List<NameSorter.Name> names = new List<NameSorter.Name> {
            new NameSorter.Name((["Jeffrey Preston"], ["Jorgensen"])),
            new NameSorter.Name((["Steven Paul"], ["Jobs"])),
            new NameSorter.Name((["William Henry"], ["Gates"])),
            new NameSorter.Name((["Lawrence Edward Theodore"], ["Page"])),
            new NameSorter.Name((["Mark Elliot"], ["Zuckerberg"])),
            new NameSorter.Name((["Wilmot Reed"], ["Hastings"])),
            new NameSorter.Name((["Sergey Mikhailovich"], ["Brin"])),
            new NameSorter.Name((["Lawrence Edward"], ["Page"])),
        };

        var strat = new NameSorter.DyeAndDurhamNameSortingStrategy();
        names.Sort(strat);

        List<NameSorter.Name> namesSorted = new List<NameSorter.Name> {
            new NameSorter.Name((["Sergey Mikhailovich"], ["Brin"])),
            new NameSorter.Name((["William Henry"], ["Gates"])),
            new NameSorter.Name((["Wilmot Reed"], ["Hastings"])),
            new NameSorter.Name((["Steven Paul"], ["Jobs"])),
            new NameSorter.Name((["Jeffrey Preston"], ["Jorgensen"])),
            new NameSorter.Name((["Lawrence Edward"], ["Page"])),
            new NameSorter.Name((["Lawrence Edward Theodore"], ["Page"])),
            new NameSorter.Name((["Mark Elliot"], ["Zuckerberg"])),
        };

        Assert.IsTrue(compareNameLists(names, namesSorted));
    }

    [TestMethod]
    public void TestIdenticalFullNames()
    {
        List<NameSorter.Name> names = new List<NameSorter.Name> {
            new NameSorter.Name((["William Henry"], ["Gates"])),
            new NameSorter.Name((["Jeffrey Preston"], ["Jorgensen"])),
            new NameSorter.Name((["Steven Paul"], ["Jobs"])),
            new NameSorter.Name((["William Henry"], ["Gates"])),
            new NameSorter.Name((["Mark Elliot"], ["Zuckerberg"])),
            new NameSorter.Name((["Wilmot Reed"], ["Hastings"])),
            new NameSorter.Name((["Sergey Mikhailovich"], ["Brin"])),
            new NameSorter.Name((["Lawrence Edward"], ["Page"])),
        };
        // TODO: Should randomise the order of names arrays then run several times

        var strat = new NameSorter.DyeAndDurhamNameSortingStrategy();
        names.Sort(strat);

        List<NameSorter.Name> namesSorted = new List<NameSorter.Name> {
            new NameSorter.Name((["Sergey Mikhailovich"], ["Brin"])),
            new NameSorter.Name((["William Henry"], ["Gates"])),
            new NameSorter.Name((["William Henry"], ["Gates"])),
            new NameSorter.Name((["Wilmot Reed"], ["Hastings"])),
            new NameSorter.Name((["Steven Paul"], ["Jobs"])),
            new NameSorter.Name((["Jeffrey Preston"], ["Jorgensen"])),
            new NameSorter.Name((["Lawrence Edward"], ["Page"])),
            new NameSorter.Name((["Mark Elliot"], ["Zuckerberg"])),
        };

        Assert.IsTrue(compareNameLists(names, namesSorted));
    }

    private bool compareNameLists(List<NameSorter.Name> l1, List<NameSorter.Name> l2)
    {
        if (l1.Count != l2.Count) return false;

        for (int i = 0; i < l1.Count; i++)
        {
            if (!l1[i].Equals(l2[i])) return false;
        }
        return true;
    }

}