using System.Threading.Tasks;
using Examination.Domain.AggregateModels.ExamResultAggregate;
using Examination.Infrastructure.SeedWork;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Examination.Infrastructure.Repositories
{
    public class ExamResultRepository : BaseRepository<ExamResult>, IExamResultRepository
    {
        public ExamResultRepository(IMongoClient mongoClient,
        IOptions<ExamSettings> settings,
        IMediator mediator)
        : base(mongoClient, settings, Constants.Collections.ExamResult)
        {
        }

        public async Task<ExamResult> GetDetails(string id)
        {
            var filter = Builders<ExamResult>.Filter.Where(s => s.Id == id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<PagedList<ExamResult>> GetExamResultsByUserIdPagingAsync(string userId, int pageIndex, int pageSize)
        {
            FilterDefinition<ExamResult> filter = Builders<ExamResult>.Filter.Empty;
            if (!string.IsNullOrEmpty(userId))
                filter = Builders<ExamResult>.Filter.Eq(s => s.UserId, userId);

            var totalRow = await Collection.Find(filter).CountDocumentsAsync();
            var items = await Collection.Find(filter)
                .SortByDescending(x => x.ExamFinishDate)
                .Skip((pageIndex - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return new PagedList<ExamResult>(items, totalRow, pageIndex, pageSize);
        }

        public async Task<PagedList<ExamResult>> GetExamResultsPagingAsync(string searchKeyword, int pageIndex, int pageSize)
        {
            FilterDefinition<ExamResult> filter = Builders<ExamResult>.Filter.Empty;
            if (!string.IsNullOrEmpty(searchKeyword))
                filter = Builders<ExamResult>.Filter.Where(s => (s.ExamTitle != null && s.ExamTitle.Contains(searchKeyword))
                || (s.Email != null && s.Email.Contains(searchKeyword))
                || (s.FullName != null && s.FullName.Contains(searchKeyword)));

            var totalRow = await Collection.Find(filter).CountDocumentsAsync();
            var items = await Collection.Find(filter)
                .SortByDescending(x => x.ExamFinishDate)
                .Skip((pageIndex - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return new PagedList<ExamResult>(items, totalRow, pageIndex, pageSize);
        }
    }
}