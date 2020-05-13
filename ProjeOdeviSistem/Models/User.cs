using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeOdeviSistem.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [BsonElement("email")]
        public string email { get; set; }
        [BsonElement("city")]
        public string city { get; set; }
        [BsonElement("adress")]
        public string adress { get; set; }
        [BsonElement("role")]
        public string role { get; set; }

        public User(string name,string password,string email, string city, string adress, string role)
        {
            this.name = name;
            this.password = password;
            this.email = email;
            this.city = city;
            this.adress = adress;
            this.role = role;
        }
    }
}
