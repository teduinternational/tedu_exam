using AdminApp.Services.Interfaces;
using Examination.Dtos.Categories;
using Examination.Dtos.SeedWork;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdminApp.Services
{
    public class CategoryService : ICategoryService
    {
        public HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Create(CategoryRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/categories", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync($"/api/categories/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<CategoryDto> GetDetail(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<CategoryDto>($"/api/categories/{id}");
            return result;
        }

        public async Task<PagedList<CategoryDto>> GetListPaging(CategorySearch searchInput)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = searchInput.PageNumber.ToString()
            };

            if (!string.IsNullOrEmpty(searchInput.Name))
                queryStringParam.Add("name", searchInput.Name);
          

            string url = QueryHelpers.AddQueryString("/api/categories", queryStringParam);

            var result = await _httpClient.GetFromJsonAsync<PagedList<CategoryDto>>(url);
            return result;
        }

        public async Task<bool> Update(string id, CategoryRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/categories/{id}", request);
            return result.IsSuccessStatusCode;
        }
    }
}
