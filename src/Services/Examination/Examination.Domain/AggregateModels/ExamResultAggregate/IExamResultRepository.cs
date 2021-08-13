using System.Threading.Tasks;
using Examination.Domain.SeedWork;

namespace Examination.Domain.AggregateModels.ExamResultAggregate
{
    public interface IExamResultRepository : IRepositoryBase<ExamResult>
    {
        Task<ExamResult> GetDetails(string userId, string examId);
    }
}