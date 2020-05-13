using MongoDB.Bson;
using MongoDB.Driver;
using ProjeOdeviSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeOdeviSistem.Helpers
{
    public class helperCart
    {
        private readonly IMongoCollection<Cart> mongoProductCollection;

        public helperCart(string connStr, string dbName, string collName)
        {
            var client = new MongoClient(connStr);
            var database = client.GetDatabase(dbName);
            mongoProductCollection = database.GetCollection<Cart>(collName);
        }

        // Listeleme

        public List<Cart> getList(string id)
        {
            return mongoProductCollection.Find(r => r.uid.Equals(id)).ToList();
        }


        // id ile getirme
        public Cart getById(string id)
        {
            var docId = new ObjectId(id);
            return mongoProductCollection.Find<Cart>(m => m.Id == docId).FirstOrDefault();
        }

        // Ekleme
        public Cart Create(Cart model)
        {
            mongoProductCollection.InsertOne(model);
            return model;
        }

        // Güncelleme
        public void Update(string id, Cart model)
        {
            var docId = new ObjectId(id);
            mongoProductCollection.ReplaceOne(m => m.Id == docId, model);
        }

        // Silme
        public void Delete(string id)
        {
            var docID = new ObjectId(id);
            mongoProductCollection.DeleteOne(m => m.Id == docID);
        }
    }
}
