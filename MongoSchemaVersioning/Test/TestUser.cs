using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoSchemaVersioning.Test
{
  public static class TestUser
  {
    public static DTO.Feature1.User CreateUserFeature1()
    {
      var user = new DTO.Feature1.User();
      user.Id = ObjectId.GenerateNewId();
      user.SchemaVersion = 1;
      user.FirstName = "Vorname";
      user.LastName = "Nachname";
      user.PhoneNumber = "0815";

      return user;
    }
    public static DTO.Feature2.User CreateUserFeature2()
    {
      var user = new DTO.Feature2.User();
      user.Id = ObjectId.GenerateNewId();
      user.SchemaVersion = 2;
      user.FirstName = "Vorname";
      user.LastName = "Nachname";
      user.Contacts = new List<DTO.Feature2.Contact> { new DTO.Feature2.Contact { Method = "phone", Value = "0816" } }.ToArray();

      return user;
    }
  }
}
