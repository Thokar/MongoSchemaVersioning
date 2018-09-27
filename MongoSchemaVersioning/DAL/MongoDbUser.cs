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
      var raw = this.db.GetCollection<object>("User");

      

    }

    public List<DTO.Feature1.User> ReadUsers()
    {
      var coll = this.db.GetCollection<DTO.Feature1.User>("User");
      var userId = new ObjectId("5bacef35f70b136d84e3d376");

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
