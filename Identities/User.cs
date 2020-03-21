﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace version1.Identities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Login")]
        public string Login { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Surname")]
        public string Surname { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }
    }
}
