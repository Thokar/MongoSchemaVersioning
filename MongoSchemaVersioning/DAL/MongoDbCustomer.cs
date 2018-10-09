using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoSchemaVersioning.DAL
{
  public class MongoDbCustomer
  {
    private MongoClient client;
    private IMongoDatabase db;

    public MongoDbCustomer()
    {
      client = new MongoClient();
      db = this.client.GetDatabase("BookShelf");
    }

    public void ReadCustomerObjectById(string id)
    {
      //var query_id = Query.EQ("_id", ObjectId.Parse("50ed4e7d5baffd13a44d0153"));

      var stringFilter = "{ _id: ObjectId('" + id + "') }";
      var raw = this.db.GetCollection<object>(DTO.Feature1.Customer.CollectionName).Find(stringFilter).ToList().ToArray()[0];

      //var entity = this.db.GetCollection<(DTO.Feature1.Entity>("User").ToJson(); // (e => e.Id == ObjectId.Parse(id)).Count();

      //var results = this.db.GetCollection<Entity>("User").Find(x => x.Id ==  new ObjectId(id)).ToList();
      //var results = this.db.GetCollection<Entity>("User").Find(x => x.Id == ObjectId.Parse(id)).ToList();

      var _collection = db.GetCollection<BsonDocument>("User");
      var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
      var result = _collection.Find(filter).CountDocuments();

      /*
      var _collection1 = db.GetCollection<Entity>("User");
      var filter1 = Builders<Entity>.Filter.Eq("_id", id);
      var result1 = _collection1.Find(filter1).Count();
      */

      //Console.WriteLine(entity.Id);
    }

    public List<DTO.Feature1.Customer> ReadCustomersFeature1()
    {
      var coll = this.db.GetCollection<DTO.Feature1.Customer>(DTO.Feature1.Customer.CollectionName);

      /*
      var users = coll
      .Find(b => true)
      .Limit(5)
      .ToListAsync()
      .Result;
      */

      var users = coll
        .Find(b => true)
        .ToListAsync()
        .Result;

      Console.WriteLine("Customer found :" + users.Count());

      foreach (var user in users)
      {
        Console.WriteLine("Schema_version {0} * " + user.Name, user.SchemaVersion);
      }

      return users;
    }

    public List<DTO.Feature2.Customer> ReadCustomersFeature2()
    {
      var coll = this.db.GetCollection<DTO.Feature2.Customer>(DTO.Feature2.Customer.CollectionName);

      /*
      var users = coll
     .Find(b => true)
     .Limit(5)
     .ToListAsync()
     .Result;
     */


      var users = coll
        .Find(b => true)
        .ToListAsync()
        .Result;

      Console.WriteLine("Customer :" + users.Count());

      foreach (var user in users)
      {
        Console.WriteLine("Schema_version {0} *  Vorname  " + user.FirstName + "Nachname " + user.LastName , user.SchemaVersion);
      }

      return users;
    }

    public void InsertCustomerFeature1(DTO.Feature1.Customer user)
    {
      var coll = db.GetCollection<DTO.Feature1.Customer>(DTO.Feature1.Customer.CollectionName);

      coll.InsertOne(user);
    }

    public void InsertCustomerFeature2(DTO.Feature2.Customer user)
    {
      var coll = db.GetCollection<DTO.Feature2.Customer>(DTO.Feature2.Customer.CollectionName);

      coll.InsertOne(user);
    }

    public void UpdateUser(DTO.Feature1.Customer user)
    {
      user.Name = user.Name.ToUpper();

      var coll = db.GetCollection<DTO.Feature1.Customer>(DTO.Feature1.Customer.CollectionName);

      coll.SaveAsync(user).Wait();
    }
  }
}
