using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoSchemaVersioning.DTO.Feature2
{
  public class User : Entity
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Contact[] Contacts { get; set; }
  }
}
