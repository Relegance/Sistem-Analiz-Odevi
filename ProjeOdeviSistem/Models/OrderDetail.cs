using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeOdeviSistem.Models
{
    public class OrderDetail
    {
        public ObjectId Id { get; set; }
        [BsonElement("orderID")]
        [Required]
        public string orderID { get; set; }
        [BsonElement("productID")]
        [Required]
        public string productID { get; set; }
        [BsonElement("quantity")]
        [Required]
        public int quantity { get; set; }


        public OrderDetail(string orderID,string productID,int quantity)
        {
            this.orderID = orderID;
            this.productID = productID;
            this.quantity = quantity;
        }
    }
}
