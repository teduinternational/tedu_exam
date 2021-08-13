using Examination.Domain.AggregateModels.CategoryAggregate;
using Examination.Infrastructure.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examination.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(
          IMongoClient mongoClient,
          IOptions<ExamSettings> settings,
          IMediator mediator)
      : base(mongoClient, settings, Constants.Collections.Category)
        {
        }

        public async Task<Category> GetCategoriesByIdAsync(string id)
        {
            FilterDefinition<Category> filter = Builders<Category>.Filter.Eq(s => s.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Category> GetCategoriesByNameAsync(string name)
        {
            FilterDefinition<Category> filter = Builders<Category>.Filter.Eq(s => s.Name, name);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Tuple<List<Category>, long>> GetCategoriesPagingAsync(string searchKeyword, int pageIndex, int pageSize)
        {
            FilterDefinition<Category> filter = Builders<Category>.Filter.Empty;
            if (!string.IsNullOrEmpty(searchKeyword))
                filter = Builders<Category>.Filter.Eq(s => s.Name, searchKeyword);

            var totalRow = await Collection.Find(filter).CountDocumentsAsync();
            var items = await Collection.Find(filter)
                .Skip((pageIndex - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return new Tuple<List<Category>, long>(items, totalRow);
        }
    }
}
