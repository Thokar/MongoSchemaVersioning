using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoSchemaVersioning.DTO.Feature1
{
  public abstract class Entity : IIdentified
  {
    public ObjectId Id { set; get; }

    public int SchemaVersion { get; set; }
  }
}
