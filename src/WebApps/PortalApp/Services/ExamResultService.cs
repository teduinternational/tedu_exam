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

        public Task<ApiResult<bool>> FinishExamAsync(FinishExamRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApiResult<ExamResultDto>> GetExamResultByIdAsync(string id)
        {
            return await GetAsync<ExamResultDto>($"/api/v1/ExamResults/{id}", true);
        }

        public async Task<ApiResult<ExamResultDto>> NextQuestionAsync(NextQuestionRequest request)
        {
            return await PostAsync<NextQuestionRequest, ExamResultDto>("/api/v1/ExamResults/next-question", request, true);
        }

        public Task<ApiResult<bool>> SkipExamAsync(SkipExamRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
