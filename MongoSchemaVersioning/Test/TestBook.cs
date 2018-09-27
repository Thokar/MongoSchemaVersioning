using MongoDB.Bson;
using MongoSchemaVersioning.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoSchemaVersioning.Test
{
  public class TestBook
  {
    public Book CreateBook()
    {
      var b = new Book();
      b.PublisherId = ObjectId.GenerateNewId();
      b.Title = "MyBook";
      b.Id = ObjectId.GenerateNewId();

      return b;
    }
  }
}
