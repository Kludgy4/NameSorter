using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter;

public interface NameParsingStrategy
{
    /**
     * Returns in-order the "given names" and "last names" of a person.
     */
    (List<string> givenNames, List<string> lastNames) ParseName(string fullName);
}
