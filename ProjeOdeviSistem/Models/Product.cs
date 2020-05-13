using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeOdeviSistem.Models
{
    public class Product
    {
        public ObjectId Id { get; set; }
        [BsonElement("productName")]
        [Required]
        public string productName { get; set; }

        [BsonElement("productDesc")]
        [Required]
        public string productDesc { get; set; }
        [BsonElement("productPrice")]
        [Required]
        public double productPrice { get; set; }
        [BsonElement("productImage")]
        [Required]
        public string productImage { get; set; }
        [BsonElement("categoryName")]
        [Required]
        public string categoryName { get; set; }



        public Product (string productName, string productDesc, double productPrice,string productImage, string categoryName)
        {
            this.productName = productName;
            this.productDesc = productDesc;
            this.productPrice = productPrice;
            this.productImage = productImage;
            this.categoryName = categoryName;
        }

    }
}
