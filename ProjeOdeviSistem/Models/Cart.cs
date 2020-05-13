using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeOdeviSistem.Models
{
    public class Cart
    {
        public ObjectId Id { get; set; }
        [BsonElement("Product")]
        public Product product { get; set; }
        [BsonElement("uid")]
        public string uid { get; set; }
        [BsonElement("quantity")]
        public int quantity { get; set; }


        public Cart(Product pro , string uid, int sayi)
        {
            this.product = pro;
            this.uid = uid;
            this.quantity = sayi;
        }
    }
}
