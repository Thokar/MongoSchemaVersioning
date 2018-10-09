using MongoDB.Bson;

namespace MongoSchemaVersioning.Test
{
  public static class TestCustomer
  {
    public static DTO.Feature1.Customer CreateUserFeature1()
    {
      var customer = new DTO.Feature1.Customer();
      customer.Id = ObjectId.GenerateNewId();
      customer.SchemaVersion = 1;
      customer.Name = "Vorname Nachname";
      return customer;
    }
    public static DTO.Feature2.Customer CreateUserFeature2()
    {
      var customer = new DTO.Feature2.Customer();
      customer.Id = ObjectId.GenerateNewId();
      customer.SchemaVersion = 2;
      customer.FirstName = "Vorname";
      customer.LastName = "Nachname";

      return customer;
    }
  }
}
