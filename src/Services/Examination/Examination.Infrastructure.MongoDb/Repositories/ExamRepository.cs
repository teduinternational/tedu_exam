using System.Collections.Generic;
using System.Threading.Tasks;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Infrastructure.SeedWork;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Examination.Infrastructure.Repositories
{
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        public ExamRepository(
            IMongoClient mongoClient,
            IOptions<ExamSettings> settings)
        : base(mongoClient, settings, Constants.Collections.Exam)
        {
        }

        public async Task<Exam> GetExamByIdAsync(string id)
        {
            var filter = Builders<Exam>.Filter.Eq(s => s.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Exam>> GetAllExamsAsync()
        {
            return await Collection.AsQueryable().ToListAsync();
        }

        public async Task<PagedList<Exam>> GetExamsPagingAsync(string categoryId, string searchKeyword, int pageIndex, int pageSize)
        {
            FilterDefinition<Exam> filter = Builders<Exam>.Filter.Empty;
            if (!string.IsNullOrEmpty(searchKeyword))
                filter = Builders<Exam>.Filter.Where(s => s.Name.Contains(searchKeyword));

            if (!string.IsNullOrEmpty(categoryId))
                filter = Builders<Exam>.Filter.Eq(s => s.CategoryId, categoryId);

            var totalRow = await Collection.Find(filter).CountDocumentsAsync();
            var items = await Collection.Find(filter)
                .SortByDescending(x => x.DateCreated)
                .Skip((pageIndex - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return new PagedList<Exam>(items, totalRow, pageIndex, pageSize);
        }
    }
}