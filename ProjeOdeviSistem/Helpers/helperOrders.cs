using MongoDB.Bson;
using MongoDB.Driver;
using ProjeOdeviSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeOdeviSistem.Helper
{
    public class helperOrders
    {
        private readonly IMongoCollection<Order> mongoUserCollection;

        public helperOrders(string connStr, string dbName, string collName)
        {
            var client = new MongoClient(connStr);
            var database = client.GetDatabase(dbName);
            mongoUserCollection = database.GetCollection<Order>(collName);
        }

        // Listeleme

        public List<Order> getList()
        {
            return mongoUserCollection.Find(r => true).ToList();
        }

        // id ile getirme
        public Order getById(string id)
        {
            var docId = new ObjectId(id);
            return mongoUserCollection.Find<Order>(m => m.Id == docId).FirstOrDefault();
        }

        // Ekleme
        public Order Create(Order model)
        {
            mongoUserCollection.InsertOne(model);
            return model;
        }

        // Güncelleme
        public void Update(string id, Order model)
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
