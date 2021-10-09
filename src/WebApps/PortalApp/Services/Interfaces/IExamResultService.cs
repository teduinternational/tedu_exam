using Examination.Shared.ExamResults;
using Examination.Shared.Exams;
using Examination.Shared.SeedWork;
using System.Threading.Tasks;

namespace PortalApp.Services.Interfaces
{
    public interface IExamResultService
    {
        Task<ApiResult<ExamResultDto>> GetExamResultByIdAsync(string id);
    }
}
