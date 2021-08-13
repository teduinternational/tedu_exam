using System.Collections.Generic;
using System.Threading.Tasks;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Infrastructure.SeedWork;
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

        public async Task<IEnumerable<Exam>> GetExamListAsync()
        {
            return await Collection.AsQueryable().ToListAsync();
        }
    }
}