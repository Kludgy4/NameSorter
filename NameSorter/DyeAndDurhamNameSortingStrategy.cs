using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter;

public class DyeAndDurhamNameSortingStrategy : NameSortingStrategy
{
    /**
     * A sorting algorithm that sorts fullnames by
     * 1. Last names, then by
     * 2. Given names
     */
    public int Compare(Name? n1, Name? n2)
    {
        // Always sort broken null names to the end
        if (n1 == null && n2 == null) return 0;
        if (n1 == null) return 1;
        if (n2 == null) return -1;

        // Sort on lastNames then on givenNames, in order as stored
        int givenComp = String.Compare(n1.LastNames(), n2.LastNames());
        if (givenComp == 0)
        {
            return String.Compare(n1.GivenNames(), n2.GivenNames());
        }
        return givenComp;
    }
}
