using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeOdeviSistem.Models
{
    public class Categorie
    {
        public ObjectId Id { get; set; }
        [BsonElement("categoryName")]
        [Required]
        public string categoryName { get; set; }


        public Categorie(string name)
        {
            this.categoryName = name;
        }
    }
}
