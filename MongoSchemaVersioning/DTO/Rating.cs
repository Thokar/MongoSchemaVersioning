using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoSchemaVersioning.DTO
{
  public class Rating
  {
    public ObjectId  UserId{ get; set; }

    public int Value { get; set; }
  }
}
