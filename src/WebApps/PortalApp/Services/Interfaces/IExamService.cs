using Examination.Shared.Exams;
using Examination.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApp.Services.Interfaces
{
    public interface IExamService
    {
        Task<ApiResult<PagedList<ExamDto>>> GetExamsPagingAsync(ExamSearch search);
        Task<ApiResult<ExamDto>> GetExamByIdAsync(string id);
    }
}
