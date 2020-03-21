using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace version1.Identities.Comparers
{
    public class BookComparer1 : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Price < y.Price)
                return 1;
            else if (x.Price > y.Price)
                return -1;
            else
                return 0;
        }
    }
}
