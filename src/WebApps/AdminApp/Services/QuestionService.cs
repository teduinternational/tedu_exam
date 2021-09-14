using Examination.Shared.SeedWork;
using Examination.Shared.Questions;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Examination.Shared.Categories;

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
            var result = await _httpClient.PostAsJsonAsync("/api/v1/Questions", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _httpClient.DeleteAsync($"/api/v1/Questions/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<ApiResult<QuestionDto>> GetQuestionByIdAsync(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResult<QuestionDto>>($"/api/v1/Questions/{id}");
            return result;
        }

        public async Task<ApiResult<PagedList<QuestionDto>>> GetQuestionsPagingAsync(QuestionSearch searchInput)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageIndex"] = searchInput.PageNumber.ToString(),
                ["pageSize"] = searchInput.PageSize.ToString()
            };

            if (!string.IsNullOrEmpty(searchInput.Name))
                queryStringParam.Add("searchKeyword", searchInput.Name);

            if(!string.IsNullOrEmpty(searchInput.CategoryId))
                queryStringParam.Add("categoryId", searchInput.CategoryId);

            string url = QueryHelpers.AddQueryString("/api/v1/Questions/paging", queryStringParam);

            var result = await _httpClient.GetFromJsonAsync<ApiResult<PagedList<QuestionDto>>>(url);
            return result;
        }

        public async Task<bool> UpdateAsync(UpdateQuestionRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/v1/Questions", request);
            return result.IsSuccessStatusCode;
        }

       
    }
}
