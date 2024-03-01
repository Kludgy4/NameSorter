using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter;

public class DyeAndDurhamNameParsingStrategy : NameParsingStrategy
{
    // Parse a name that "must have at least 1 given name and may have up to 3 given names."
    // ASSUMPTION: Every person will have at least 1 last name as well.
    // ASSUMPTION: All full names will be given as "given (given)? (given)? (given)? last"
    public (List<string> givenNames, List<string> lastNames) ParseName(string fullName)
    {
        
        string[] splitName = fullName.Split(" ", 4);

        if (splitName.Length < 2)
        {
            throw new ArgumentOutOfRangeException("Not enough subnames provided: " + fullName);
        }

        if (splitName.Length == 4 && splitName[3].Contains(" "))
        {
            throw new ArgumentOutOfRangeException("Too many subnames provided: " + fullName);
        }

        List<string> givenNames = new List<string>();
        for (int i = 0; i < splitName.Length - 1; ++i)
        {
            givenNames.Add(splitName[i]);
        }

        List<string> lastNames = new List<string>();
        lastNames.Add(splitName[splitName.Length - 1]);

        return (givenNames, lastNames);
    }
}
