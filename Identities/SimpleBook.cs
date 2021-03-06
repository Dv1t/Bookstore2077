﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace version1.Identities
{
    public class SimpleBook
    {
        public string Id { get; set; }
        public string BookName { get; set; }

        public float Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string CoverImageLink { get; set; }

        public float Rating { get; set; }
    }
}
