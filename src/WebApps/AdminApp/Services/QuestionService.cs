using Examination.Dtos.SeedWork;
using Examination.Shared.Questions;
using Examination.Shared.SeedWork;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdminApp.Services.Interfaces
{
    public class QuestionService : IQuestionService
    {
        public HttpClient _httpClient;

        public QuestionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAsync(CreateQuestionRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/v1/questions", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _httpClient.DeleteAsync($"/api/v1/questions/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<QuestionDto> GetQuestionByIdAsync(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<ApiSuccessResult<QuestionDto>>($"/api/v1/questions/{id}");
            return result.ResultObj;
        }

        public async Task<PagedList<QuestionDto>> GetQuestionsPagingAsync(QuestionSearch searchInput)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageIndex"] = searchInput.PageNumber.ToString(),
                ["pageSize"] = searchInput.PageSize.ToString()
            };

            if (!string.IsNullOrEmpty(searchInput.Name))
                queryStringParam.Add("searchKeyword", searchInput.Name);


            string url = QueryHelpers.AddQueryString("/api/v1/questions/paging", queryStringParam);

            var result = await _httpClient.GetFromJsonAsync<ApiSuccessResult<PagedList<QuestionDto>>>(url);
            return result.ResultObj;
        }

        public async Task<bool> UpdateAsync(UpdateQuestionRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/v1/questions", request);
            return result.IsSuccessStatusCode;
        }
    }
}
