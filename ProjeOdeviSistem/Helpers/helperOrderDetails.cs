using MongoDB.Bson;
using MongoDB.Driver;
using ProjeOdeviSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeOdeviSistem.Helper
{
    public class helperOrderDetails
    {
        private readonly IMongoCollection<OrderDetail> mongoUserCollection;

        public helperOrderDetails(string connStr, string dbName, string collName)
        {
            var client = new MongoClient(connStr);
            var database = client.GetDatabase(dbName);
            mongoUserCollection = database.GetCollection<OrderDetail>(collName);
        }

        // Listeleme

        public List<OrderDetail> getList()
        {
            return mongoUserCollection.Find(r => true).ToList();
        }

        // OrderID ile getirme

        public List<OrderDetail> getList(string orderID)
        {
            var docId = new ObjectId(orderID);
            return mongoUserCollection.Find(r => r.Id==docId).ToList();
        }

        // id ile getirme
        public OrderDetail getById(string id)
        {
            var docId = new ObjectId(id);
            return mongoUserCollection.Find<OrderDetail>(m => m.Id == docId).FirstOrDefault();
        }

        // Ekleme
        public OrderDetail Create(OrderDetail model)
        {
            mongoUserCollection.InsertOne(model);
            return model;
        }

        // Güncelleme
        public void Update(string id, OrderDetail model)
        {
            var docId = new ObjectId(id);
            mongoUserCollection.ReplaceOne(m => m.Id == docId, model);
        }

        // Silme
        public void Delete(string id)
        {
            var docID = new ObjectId(id);
            mongoUserCollection.DeleteOne(m => m.Id == docID);
        }
    }
}
