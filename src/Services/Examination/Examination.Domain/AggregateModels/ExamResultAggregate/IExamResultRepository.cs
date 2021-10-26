using System.Threading.Tasks;
using Examination.Domain.SeedWork;
using Examination.Shared.SeedWork;

namespace Examination.Domain.AggregateModels.ExamResultAggregate
{
    public interface IExamResultRepository : IRepositoryBase<ExamResult>
    {
        Task<ExamResult> GetDetails(string id);

        Task<PagedList<ExamResult>> GetExamResultsByUserIdPagingAsync(string userId, int pageIndex, int pageSize);

        Task<PagedList<ExamResult>> GetExamResultsPagingAsync(string searchKeyword, int pageIndex, int pageSize);


    }
}