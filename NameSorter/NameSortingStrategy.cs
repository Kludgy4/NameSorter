using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter;

interface NameSortingStrategy : IComparer<Name>
{
    // Basically a reskin of an interface used to sort a list of names
}
