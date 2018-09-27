using MongoDB.Bson;
using System;

namespace MongoSchemaVersioning.DTO
{
  public class Book : IIdentified
  {
    public ObjectId Id { get; set; }
    public string ISBN { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public DateTime Published { get; set; }

    public ObjectId PublisherId { get; set; }

    public ImageUrl[] ImageUrls { get; set; }

    public Rating[] Ratings { get; set; }
  }
}
