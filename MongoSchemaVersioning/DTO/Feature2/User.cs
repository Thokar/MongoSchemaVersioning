using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoSchemaVersioning.DTO.Feature2
{
  public class User : IIdentified
  {
    public ObjectId Id { get; set; }
    public int SchemaVersion { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Contact[] Contacts { get; set; }
  }
}
