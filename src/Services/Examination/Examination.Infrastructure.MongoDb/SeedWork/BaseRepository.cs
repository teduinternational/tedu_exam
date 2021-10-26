
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Examination.Domain.SeedWork;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Examination.Infrastructure.SeedWork
{
    public class BaseRepository<T> : IRepositoryBase<T> where T : Entity, IAggregateRoot
    {
        private readonly IMongoClient _mongoClient;
        private readonly string _collection;
        private readonly ExamSettings _settings;

        public BaseRepository(IMongoClient mongoClient,
         IOptions<ExamSettings> settings,
         string collection)
        {
            _settings = settings.Value;
            (_mongoClient, _collection) = (mongoClient, collection);

            if (!_mongoClient.GetDatabase(_settings.DatabaseSettings.DatabaseName).ListCollectionNames().ToList().Contains(collection))
                _mongoClient.GetDatabase(_settings.DatabaseSettings.DatabaseName).CreateCollection(collection);
        }

        protected virtual IMongoCollection<T> Collection =>
                   _mongoClient.GetDatabase(_settings.DatabaseSettings.DatabaseName).GetCollection<T>(_collection);

      

        public async Task DeleteAsync(string id)
        {
            await Collection.DeleteOneAsync(f => f.Id == id);
        }

        public async Task InsertAsync(T obj)
        {
            await Collection.InsertOneAsync(obj);
        }

        public async Task UpdateAsync(T obj)
        {
            Expression<Func<T, string>> func = f => f.Id;
            var value = (string)obj.GetType().GetProperty(func.Body.ToString().Split(".")[1])?.GetValue(obj, null);
            var filter = Builders<T>.Filter.Eq(func, value);

            await Collection.ReplaceOneAsync(filter, obj);
        }
    }
}