using MongoDB.Bson;

namespace MongoSchemaVersioning.DTO
{
  public interface IIdentified
  {
    ObjectId Id { get; }
  }
}
