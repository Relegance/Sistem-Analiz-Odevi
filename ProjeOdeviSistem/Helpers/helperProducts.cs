using MongoDB.Bson;
using MongoDB.Driver;
using ProjeOdeviSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeOdeviSistem.Helper
{
    public class helperProducts
    {
        private readonly IMongoCollection<Product> mongoProductCollection;

        public helperProducts(string connStr, string dbName, string collName)
        {
            var client = new MongoClient(connStr);
            var database = client.GetDatabase(dbName);
            mongoProductCollection = database.GetCollection<Product>(collName);
        }

        // Listeleme

        public List<Product> getList()
        {
            return mongoProductCollection.Find(r => true).ToList();
        }

        // Kategori listeleme
        public List<Product> getList(string category)
        {
            return mongoProductCollection.Find(r => r.categoryName == category).ToList();
        }

        // id ile getirme
        public Product getById(string id)
        {
            var docId = new ObjectId(id);
            return mongoProductCollection.Find<Product>(m => m.Id == docId).FirstOrDefault();
        }

        // Ekleme
        public Product Create(Product model)
        {
            mongoProductCollection.InsertOne(model);
            return model;
        }

        // Güncelleme
        public void Update(string id, Product model)
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
