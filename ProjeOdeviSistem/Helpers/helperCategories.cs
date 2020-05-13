using MongoDB.Bson;
using MongoDB.Driver;
using ProjeOdeviSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeOdeviSistem.Helper
{
    public class helperCategories
    {
        private readonly IMongoCollection<Categorie> mongoUserCollection;

        public helperCategories(string connStr, string dbName, string collName)
        {
            var client = new MongoClient(connStr);
            var database = client.GetDatabase(dbName);
            mongoUserCollection = database.GetCollection<Categorie>(collName);
        }

        // Listeleme

        public List<Categorie> getList()
        {
            return mongoUserCollection.Find(r => true).ToList();
        }

        // id ile getirme
        public Categorie getById(string id)
        {
            var docId = new ObjectId(id);
            return mongoUserCollection.Find<Categorie>(m => m.Id == docId).FirstOrDefault();
        }

        // Ekleme
        public Categorie Create(Categorie model)
        {
            mongoUserCollection.InsertOne(model);
            return model;
        }

        // Güncelleme
        public void Update(string id, Categorie model)
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
