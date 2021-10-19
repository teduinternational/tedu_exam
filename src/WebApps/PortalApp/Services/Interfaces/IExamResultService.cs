using Examination.Shared.ExamResults;
using Examination.Shared.Exams;
using Examination.Shared.SeedWork;
using System.Threading.Tasks;

namespace PortalApp.Services.Interfaces
{
    public interface IExamResultService
    {
        Task<ApiResult<ExamResultDto>> GetExamResultByIdAsync(string id);
        Task<ApiResult<ExamResultDto>> NextQuestionAsync(NextQuestionRequest request);
        Task<ApiResult<bool>> SkipExamAsync(SkipExamRequest request);
        Task<ApiResult<bool>> FinishExamAsync(FinishExamRequest request);
    }
}
