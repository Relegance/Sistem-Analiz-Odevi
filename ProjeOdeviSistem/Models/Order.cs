using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeOdeviSistem.Models
{
    public class Order
    {
        public ObjectId Id { get; set; }

        [BsonElement("customerID")]
        [Required]
        public string customerID { get; set; }
        [BsonElement("orderDate")]
        [Required]
        public DateTime orderDate { get; set; }
        [BsonElement("totalPrice")]
        [Required]
        public double totalPrice { get; set; }

        public Order(string customerID,DateTime orderDate,double totalPrice)
        {
            this.customerID = customerID;
            this.orderDate = orderDate;
            this.totalPrice = totalPrice;
        }
    }
}
