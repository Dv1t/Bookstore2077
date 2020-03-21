using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace version1.Identities
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }

        [BsonElement("ISBN")]
        public string ISBN { get; set; }

        [BsonElement("Price")]
        public float Price { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }

        [BsonElement("CoverImageLink")]
        public string CoverImageLink { get; set; }

        public float Rating { get; set; }

        public string Description { get; set; }

        public List<string> Tags;
        
        public List<Comment> Comments { get; set; }

        public SimpleBook GetSimple()
        {
            SimpleBook simpleBook = new SimpleBook();
            simpleBook.Id = this.Id;
            simpleBook.Author = this.Author;
            simpleBook.BookName = this.BookName;
            simpleBook.Category = this.Category;
            simpleBook.Price = this.Price;
            simpleBook.CoverImageLink = this.CoverImageLink;
            simpleBook.Rating = this.Rating;
            return simpleBook;
        }
    }
}
