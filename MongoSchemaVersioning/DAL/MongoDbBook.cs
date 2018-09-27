using MongoDB.Bson;
using MongoDB.Driver;
using MongoSchemaVersioning.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoSchemaVersioning.DAL
{
  public class MongoDbBook
  {
    private MongoClient client;
    private IMongoDatabase db;

    public MongoDbBook()
    {
      client = new MongoClient();
      db = this.client.GetDatabase("BookShelf");
    }

    public List<Book> ReadBooks()
    {
      var coll = this.db.GetCollection<Book>("Book");
      var publisherId = new ObjectId("5bacef35f70b136d84e3d376");

      var books = coll
        .Find(b => b.PublisherId == publisherId)
        .Limit(5)
        .ToListAsync()
        .Result;

      Console.WriteLine("Books:");

      foreach (var book in books)
      {
        Console.WriteLine(" * " + book.Title);
      }

      return books;
    }

    public void InsertBook(Book b)
    {
      var coll = db.GetCollection<Book>("Book");

      coll.InsertOne(b);
    }

    public void UpdateBook(Book b)
    {
      b.Title = b.Title.ToUpper();

      var coll = db.GetCollection<Book>("Book");

      coll.SaveAsync(b).Wait();
    }
  }
}
