using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MongoSchemaVersioning.DTO
{
  public class Person : ISupportInitialize
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [BsonExtraElements]
    public IDictionary<string, object> ExtraElements { get; set; }

    void ISupportInitialize.BeginInit()
    {
      // nothing to do at beginning
    }

    void ISupportInitialize.EndInit()
    {
      object nameValue;
      if (!ExtraElements.TryGetValue("Name", out nameValue))
      {
        return;
      }

      var name = (string)nameValue;

      // remove the Name element so that it doesn't get persisted back to the database
      ExtraElements.Remove("Name");

      // assuming all names are "First Last"
      var nameParts = name.Split(' ');

      FirstName = nameParts[0];
      LastName = nameParts[1];
    }
  }
}
