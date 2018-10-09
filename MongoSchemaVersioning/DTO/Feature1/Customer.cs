using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MongoSchemaVersioning.DTO.Feature1
{
  // not supported in core 2.1 see https://jira.mongodb.org/browse/CSHARP-2138
  public class Customer : Entity, ISupportInitialize
  {
    public string Name { get; set; }

    [BsonIgnore]
    public static string CollectionName = "Customer";

    [BsonExtraElements]
    public IDictionary<string, object> ExtraElements { get; set; }

    public void BeginInit()
    {
      // Nothing to do 
    }

    public void EndInit()
    {
      object firstNameValue;
      if (!ExtraElements.TryGetValue("FirstName", out firstNameValue))
      {
        return;
      }

      var firstName = (string)firstNameValue;

      object lastNameValue;
      if (!ExtraElements.TryGetValue("LastName", out lastNameValue))
      {
        return;
      }

      var lastName = (string)lastNameValue;


      // remove the Name element so that it doesn't get persisted back to the database
      //ExtraElements.Remove("Name");

      // assuming all names are "First Last"
      //var nameParts = name.Split(' ');


      Name = firstName + ' ' + lastName;


    }
  }
}
