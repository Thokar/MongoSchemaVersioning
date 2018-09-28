using MongoDB.Bson;
using MongoDB.Driver;
using MongoSchemaVersioning.DTO.Feature1;
using System;
using System.Collections.Generic;

namespace MongoSchemaVersioning.DAL
{
  public class MongoDbUser
  {
    private MongoClient client;
    private IMongoDatabase db;

    public MongoDbUser()
    {
      client = new MongoClient();
      db = this.client.GetDatabase("BookShelf");
    }

    public void ReadUserObjectById(string id)
    {
      //var query_id = Query.EQ("_id", ObjectId.Parse("50ed4e7d5baffd13a44d0153"));
   
      var stringFilter = "{ _id: ObjectId('" + id + "') }";
      var raw = this.db.GetCollection<object>("User").Find(stringFilter).ToList().ToArray()[0];

      var entity = this.db.GetCollection<Entity>("User").ToJson(); // (e => e.Id == ObjectId.Parse(id)).Count();

      //var results = this.db.GetCollection<Entity>("User").Find(x => x.Id ==  new ObjectId(id)).ToList();
      //var results = this.db.GetCollection<Entity>("User").Find(x => x.Id == ObjectId.Parse(id)).ToList();

      var _collection = db.GetCollection<BsonDocument>("User");
      var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
      var result = _collection.Find(filter).CountDocuments();
     
      var _collection1 = db.GetCollection<Entity>("User");
      var filter1 = Builders<Entity>.Filter.Eq("_id", id);
      var result1 = _collection1.Find(filter1).CountDocuments();

      //Console.WriteLine(entity.Id);

    }

    public List<DTO.Feature1.User> ReadUsers()
    {
      var coll = this.db.GetCollection<DTO.Feature1.User>("User");
      var userId = new ObjectId("bae1dcb91a4d6eb68523307");

      var users = coll
        .Find(b => b.Id == userId)
        .Limit(5)
        .ToListAsync()
        .Result;

      Console.WriteLine("User:");

      foreach (var user in users)
      {
        Console.WriteLine(" * " + user.FirstName);
      }

      return users;
    }

    public void InsertUser(DTO.Feature1.User user)
    {
      var coll = db.GetCollection<DTO.Feature1.User>("User");

      coll.InsertOne(user);
    }

    public void UpdateUser(DTO.Feature1.User user)
    {
      user.FirstName = user.FirstName.ToUpper();

      var coll = db.GetCollection<User>("User");

      coll.SaveAsync(user).Wait();
    }
  }
}
