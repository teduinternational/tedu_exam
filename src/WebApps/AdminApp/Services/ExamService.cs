using Examination.Shared.SeedWork;
using Examination.Shared.Exams;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace AdminApp.Services.Interfaces
{
    public class ExamService : IExamService
    {
        public HttpClient _httpClient;

        public ExamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResult<ExamDto>> CreateAsync(CreateExamRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/v1/Exams", request);
            var content = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ApiResult<ExamDto>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<ApiResult<bool>> DeleteAsync(string id)
        {
            var result = await _httpClient.DeleteAsync($"/api/v1/Exams/{id}");
            var content = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ApiResult<bool>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<ApiResult<ExamDto>> GetExamByIdAsync(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResult<ExamDto>>($"/api/v1/Exams/{id}");
            return result;
        }

        public async Task<ApiResult<PagedList<ExamDto>>> GetExamsPagingAsync(ExamSearch searchInput)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageIndex"] = searchInput.PageNumber.ToString(),
                ["pageSize"] = searchInput.PageSize.ToString()
            };

            if (!string.IsNullOrEmpty(searchInput.Name))
                queryStringParam.Add("searchKeyword", searchInput.Name);

            if (!string.IsNullOrEmpty(searchInput.CategoryId))
                queryStringParam.Add("categoryId", searchInput.CategoryId);

            string url = QueryHelpers.AddQueryString("/api/v1/Exams/paging", queryStringParam);

            var result = await _httpClient.GetFromJsonAsync<ApiResult<PagedList<ExamDto>>>(url);
            return result;
        }

        public async Task<ApiResult<bool>> UpdateAsync(UpdateExamRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/v1/Exams", request);
            var content = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ApiResult<bool>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


    }
}