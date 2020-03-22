using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace version1.Identities.Comparers
{
    public class BookComparer6 : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Year > y.Year)
                return 1;
            else if (x.Year < y.Year)
                return -1;
            else
                return 0;
        }
    }
}
