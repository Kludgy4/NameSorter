namespace NameSorter;

/**
 * 
 * A class that parses names from a given string
 */
class Name
{
    List<String> givenName;
    List<String> lastNames;

    /**
     * Takes a space separated string name and creates a name object with it
     * All space separated substrings, apart from the last one, are
     * considered to be "given names". The last substring is the "last name".
     * @param fullName - The string used to create the Name object
     * 
     */
    public Name(string fullName)
    {
        string[] splitName = fullName.Split(" ", 4);
        
        if (splitName.Length < 2)
        {
            throw new FormatException("Not enough subnames provided");
        }
        
        if (splitName[4].Contains(" "))
        {
            throw new FormatException("Too many subnames provided");
        }

        givenName = new List<string>();
        givenName.Append(splitName[0]);

        lastNames = new List<string>();
        for (int i = 1; i < splitName.Length; ++i)
        {
            lastNames.Append(splitName[i]);
        }
    }


}
