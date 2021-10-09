using Examination.Shared.SeedWork;
using Examination.Shared.Exams;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PortalApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Examination.Shared.ExamResults;

namespace PortalApp.Services
{
    public class ExamResultService : BaseService, IExamResultService
    {
        public ExamResultService(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor)
        {
        }

        public async Task<ApiResult<ExamResultDto>> GetExamResultByIdAsync(string id)
        {
            return await GetAsync<ExamResultDto>($"/api/v1/ExamResults/{id}", true);
        }
    }
}
