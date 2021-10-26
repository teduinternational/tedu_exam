using Examination.Shared.SeedWork;
using Examination.Shared.Exams;
using System.Threading.Tasks;
using Examination.Shared.ExamResults;

namespace AdminApp.Services.Interfaces
{
    public interface IExamResultService
    {
        Task<ApiResult<PagedList<ExamResultDto>>> GetExamResultsPagingAsync(ExamResultSearch search);
        Task<ApiResult<ExamResultDto>> GetExamResultByIdAsync(string id);
      
    }
}