using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;
using Microsoft.AspNetCore.Http;
using PortalApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PortalApp.Services
{
    public class ExamResultService : BaseService, IExamResultService
    {
        
        public ExamResultService(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor)
        {
        }
        public async Task<ApiResult<ExamResultDto>> StartExamAsync(StartExamRequest request)
        {
            return await PostAsync<StartExamRequest, ExamResultDto>("/api/v1/ExamResults/start", request, true);
        }
        public async Task<ApiResult<ExamResultDto>> FinishExamAsync(FinishExamRequest request)
        {
            return await PostAsync<FinishExamRequest, ExamResultDto>("/api/v1/ExamResults/finish", request, true);

        }

        public async Task<ApiResult<ExamResultDto>> GetExamResultByIdAsync(string id)
        {
            return await GetAsync<ExamResultDto>($"/api/v1/ExamResults/{id}", true);
        }

        public async Task<ApiResult<ExamResultDto>> NextQuestionAsync(NextQuestionRequest request)
        {
            return await PostAsync<NextQuestionRequest, ExamResultDto>("/api/v1/ExamResults/next-question", request, true);
        }

        public async Task<ApiResult<bool>> SkipExamAsync(SkipExamRequest request)
        {
            return await PutAsync<SkipExamRequest, bool>("/api/v1/ExamResults/skip", request, true);

        }
    }
}
