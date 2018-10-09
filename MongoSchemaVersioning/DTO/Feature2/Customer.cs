using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MongoSchemaVersioning.DTO.Feature2
{

  // not supported in core 2.1 see https://jira.mongodb.org/browse/CSHARP-2138
  public class Customer : Entity, ISupportInitialize
  {
    [BsonIgnore]
    public static string CollectionName = "Customer";
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [BsonExtraElements]
    public IDictionary<string, object> ExtraElements { get; set; }

    public void BeginInit()
    {
      // nothing to do at beginning
    }

    public void EndInit()
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
