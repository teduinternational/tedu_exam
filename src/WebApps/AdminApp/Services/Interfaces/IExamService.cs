using Examination.Shared.SeedWork;
using Examination.Shared.Exams;
using System.Threading.Tasks;

namespace AdminApp.Services.Interfaces
{
    public interface IExamService
    {
        Task<ApiResult<PagedList<ExamDto>>> GetExamsPagingAsync(ExamSearch search);
        Task<ApiResult<ExamDto>> GetExamByIdAsync(string id);
        Task<bool> CreateAsync(CreateExamRequest request);
        Task<bool> UpdateAsync(UpdateExamRequest request);
        Task<bool> DeleteAsync(string id);
    }
}
