using MongoDB.Driver;
using MongoSchemaVersioning.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoSchemaVersioning.DAL
{
  public static class Extensions
  {
    public static async Task<ReplaceOneResult> SaveAsync<T>(this IMongoCollection<T> collection, T entity) where T : IIdentified
    {
      return await collection.ReplaceOneAsync(
        it => it.Id == entity.Id,
        entity,
        new UpdateOptions { IsUpsert = true });
    }
  }
}
