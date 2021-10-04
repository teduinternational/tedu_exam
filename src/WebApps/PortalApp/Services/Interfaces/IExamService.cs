using Examination.Shared.SeedWork;
using Examination.Shared.Exams;
using System.Threading.Tasks;

namespace PortalApp.Services.Interfaces
{
    public interface IExamService
    {
        Task<ApiResult<PagedList<ExamDto>>> GetExamsPagingAsync(ExamSearch search);
        Task<ApiResult<ExamDto>> GetExamByIdAsync(string id);
    }
}