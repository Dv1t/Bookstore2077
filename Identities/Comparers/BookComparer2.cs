using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace version1.Identities.Comparers
{
    public class BookComparer2 : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return String.Compare(x.Author, y.Author);
        }
    }
}
