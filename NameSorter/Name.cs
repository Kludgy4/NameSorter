using System.Xml.Linq;

namespace NameSorter;

/**
 * 
 * A class that parses names from a given string.
 * ASSUMPTION: All names that will be parsed consist only of "given names" and "last names"
 */
public class Name
{
    private List<String> givenNames;
    private List<String> lastNames;

    /**
     * Takes a space separated string name and creates a name object with it
     * All space separated substrings, apart from the last one, are
     * considered to be "given names". The last substring is the "last name".
     * @param fullName - The string used to create the Name object
     */
    public Name((List<string> givenNames, List<string> lastNames) parsedNames)
    {
        (this.givenNames, this.lastNames) = (parsedNames.givenNames, parsedNames.lastNames);
    }

    /**
     * Output the person's full name in a standard givenNames lastNames format
     */
    public string FullName()
    {
        return string.Join(" ", givenNames) + " " + string.Join(" ", lastNames);
    }

    /**
     * Output the given names of the person
     */
    public string GivenNames()
    {
        return string.Join(" ", givenNames);
    }

    /**
     * Output the last names of the person
     */
    public string LastNames()
    {
        return string.Join(" ", lastNames);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || !(obj is Name)) return false;
        if (ReferenceEquals(this, obj)) return true;

        Name name = (Name) obj;

        return CompareArrays(givenNames, name.givenNames) == 0 &&
               CompareArrays(lastNames, name.lastNames) == 0;
    }

    // Apparently I'm meant to update this whenever I override Equals() so that
    // collections that require hashing will work properly.
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            foreach (string name in givenNames)
            {
                hash = hash * 23 + name.GetHashCode();
            }

            foreach (string name in lastNames)
            {
                hash = hash * 23 + name.GetHashCode();
            }

            return hash;
        }
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
