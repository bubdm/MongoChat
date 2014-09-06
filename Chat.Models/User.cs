using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chat.Models
{
    public class User
    {
        public User(string name)
        {
            this.Name = name;
            this.LoggedTimeFrom = DateTime.Now;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime LoggedTimeFrom { get; set; }
    }
}
