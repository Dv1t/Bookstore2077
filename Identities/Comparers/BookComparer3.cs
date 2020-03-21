﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace version1.Identities.Comparers
{
    public class BookComparer3 : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return String.Compare(x.BookName, y.BookName);
        }
    }
}
