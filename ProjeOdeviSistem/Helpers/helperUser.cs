using MongoDB.Bson;
using MongoDB.Driver;
using ProjeOdeviSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeOdeviSistem.Helper
{
    public class helperUser
    {
        private readonly IMongoCollection<User> mongoUserCollection;

        public helperUser (string connStr,string dbName,string collName)
        {
            var client = new MongoClient(connStr);
            var database = client.GetDatabase(dbName);
            mongoUserCollection = database.GetCollection<User>(collName);
        }

        // Listeleme

        public List<User> getList()
        {
            return mongoUserCollection.Find(r => true).ToList();
        }

        // id ile getirme
        public User getById(string id)
        {
            var docId = new ObjectId(id);
            return mongoUserCollection.Find<User>(m => m.Id == docId).FirstOrDefault();
        }

        // Ekleme
        public User Create(User model)
        {
            mongoUserCollection.InsertOne(model);
            return model;
        }

        // Güncelleme
        public void Update(string id,User model)
        {
            var docId = new ObjectId(id);
            mongoUserCollection.ReplaceOne(m => m.Id == docId,model);
        }

        // Silme
        public void Delete(string id)
        {
            var docID = new ObjectId(id);
            mongoUserCollection.DeleteOne(m => m.Id == docID);
        }

    }
}
