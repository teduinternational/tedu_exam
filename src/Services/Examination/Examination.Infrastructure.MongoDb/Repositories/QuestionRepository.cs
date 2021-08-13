using System.Reflection.Metadata;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Infrastructure.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Examination.Infrastructure.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(IMongoClient mongoClient,
        IOptions<ExamSettings> settings)
        : base(mongoClient, settings, Constants.Collections.Question)
        {
        }
    }
}