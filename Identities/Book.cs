﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace version1.Identities
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }

        public string ISBN { get; set; }
        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string CoverImageLink { get; set; }
    }
}
