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

      TestUsers();

      Console.ReadLine();
    }

    private static void TestUsers()
    {
      var client = new MongoDbUser();

      var user = TestUser.CreateUserFeature1();

      client.InsertUser(user);

      client.ReadUserObjectById("5bad02c8eb4f0d7850c09964");

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
