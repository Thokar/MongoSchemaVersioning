using MongoSchemaVersioning.DAL;
using MongoSchemaVersioning.Test;
using System;

namespace MongoSchemaVersioning
{
  class Program
  {
    static void Main(string[] args)
    {
      //TestBooks();

      //TestUsers();

      TestCustomers();

      Console.ReadLine();
    }

    private static void TestCustomers()
    {
      var client = new MongoDbCustomer();

      var insert = false;

      if (insert)
      {
        var customer1 = TestCustomer.CreateUserFeature1();
        client.InsertCustomerFeature1(customer1);

        var customer2 = TestCustomer.CreateUserFeature2();
        client.InsertCustomerFeature2(customer2);
      }
      client.ReadCustomersFeature1();
      client.ReadCustomersFeature2();
    }

    private static void TestUsers()
    {
      var client = new MongoDbUser();

      var user = TestUser.CreateUserFeature1();

      client.ReadUserObjectById("5bae1dcb91a4d6eb68523307");

      client.ReadUsers();

    }

    private static void TestBooks()
    {
      Console.WriteLine("Hello World!");

      var client = new MongoDbBook();

      var b = new Test.TestBook().CreateBook();

      client.InsertBook(b);

      var books = client.ReadBooks();
    }
  }
}
