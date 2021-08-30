using Examination.Dtos.Categories;
using Examination.Dtos.SeedWork;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdminApp.Services.Interfaces
{
    public class CategoryService : ICategoryService
    {
        public HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAsync(CreateCategoryRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/v1/categories", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _httpClient.DeleteAsync($"/api/v1/categories/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<CategoryDto>($"/api/v1/categories/{id}");
            return result;
        }

        public async Task<PagedList<CategoryDto>> GetCategoriesPagingAsync(CategorySearch searchInput)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageIndex"] = searchInput.PageNumber.ToString(),
                ["pageSize"] = searchInput.PageSize.ToString()
            };

            if (!string.IsNullOrEmpty(searchInput.Name))
                queryStringParam.Add("searchKeyword", searchInput.Name);


            string url = QueryHelpers.AddQueryString("/api/v1/categories", queryStringParam);

            var result = await _httpClient.GetFromJsonAsync<PagedList<CategoryDto>>(url);
            return result;
        }

        public async Task<bool> UpdateAsync(UpdateCategoryRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/v1/categories", request);
            return result.IsSuccessStatusCode;
        }
    }
}
