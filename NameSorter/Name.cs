namespace NameSorter;

/**
 * 
 * A class that parses names from a given string.
 * ASSUMPTION: All names that will be parsed consist only of "given names" and "last names"
 */
class Name : IComparable<Name>
{
    List<String> givenNames;
    List<String> lastNames;

    /**
     * Takes a space separated string name and creates a name object with it
     * All space separated substrings, apart from the last one, are
     * considered to be "given names". The last substring is the "last name".
     * @param fullName - The string used to create the Name object
     */
    public Name(string fullName) : this(fullName, new DyeAndDurhamNameParsingStrategy())
    {
    
    }

    /**
     * Same as 
     * 
     */
    public Name(string fullName, NameParsingStrategy nameParseStrat)
    {
        (givenNames, lastNames) = nameParseStrat.ParseName(fullName);
    }

    public string FullName()
    {
        return string.Join(" ", givenNames) + " " + string.Join(" ", lastNames);
    }

    public int CompareTo(Name? other)
    {
        // Sort broken null names to the end
        if (other == null) return -1;

        int givenComp = CompareArrays(lastNames, other.lastNames);
        if (givenComp == 0)
        {
            return CompareArrays(givenNames, other.givenNames);
        }
        return givenComp;
    }

    
    private static int CompareArrays(List<string> arr1, List<string> arr2)
    {
        int minSize = Math.Min(arr1.Count, arr2.Count);
        for (int i = 0; i < minSize; ++i)
        {
            int comp = String.Compare(arr1[i], arr2[i]);
            if (comp != 0) return comp;
        }
        // All else being equal, the shorter array should be considered smaller
        return arr1.Count.CompareTo(arr2.Count);
    }
}
