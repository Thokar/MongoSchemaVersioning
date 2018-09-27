using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoSchemaVersioning.DTO.Feature1
{
  public class User : IIdentified
  {
    public ObjectId Id { get; set; }
    public int SchemaVersion { get; set; }
    public string FirstName { get; set; }
    public string LastName{ get; set; }
    public string PhoneNumber { get; set; }
  }
}
