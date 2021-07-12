
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Examination.Domain.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Examination.Infrastructure.SeedWork
{
    public class BaseRepository<T> : IRepositoryBase<T> where T : Entity, IAggregateRoot
    {
        private readonly IMongoClient _mongoClient;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly string _collection;
        private readonly ExamSettings _settings;
        private readonly IMediator _mediator;

        public BaseRepository(IMongoClient mongoClient,
         IClientSessionHandle clientSessionHandle,
         IOptions<ExamSettings> settings,
         IMediator mediator,
         string collection)
        {
            _settings = settings.Value;
            (_mongoClient, _clientSessionHandle, _collection) = (mongoClient, clientSessionHandle, collection);

            if (!_mongoClient.GetDatabase(_settings.DatabaseSettings.DatabaseName).ListCollectionNames().ToList().Contains(collection))
                _mongoClient.GetDatabase(_settings.DatabaseSettings.DatabaseName).CreateCollection(collection);

            _mediator = mediator;
        }

        protected virtual IMongoCollection<T> Collection =>
                   _mongoClient.GetDatabase(_settings.DatabaseSettings.DatabaseName).GetCollection<T>(_collection);

        public async Task AbortTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _clientSessionHandle.AbortTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _clientSessionHandle.CommitTransactionAsync(cancellationToken);

            var domainEvents = entity.DomainEvents.ToList();

            entity.ClearDomainEvents();

            foreach (var domainEvent in domainEvents)
                await _mediator.Publish(domainEvent);
        }

        public async Task DeleteAsync(string id)
        {
            await Collection.DeleteOneAsync(_clientSessionHandle, f => f.Id == id);
        }

        public async Task InsertAsync(T obj)
        {
            await Collection.InsertOneAsync(_clientSessionHandle, obj);
        }

        public void StartTransaction()
        {
            _clientSessionHandle.StartTransaction();
        }

        public async Task UpdateAsync(T obj)
        {
            Expression<Func<T, string>> func = f => f.Id;
            var value = (string)obj.GetType().GetProperty(func.Body.ToString().Split(".")[1])?.GetValue(obj, null);
            var filter = Builders<T>.Filter.Eq(func, value);

            await Collection.ReplaceOneAsync(_clientSessionHandle, filter, obj);
        }
    }
}