using Examination.Shared.SeedWork;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PortalApp.Services
{
    public class BaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseService(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<T>> GetAsync<T>(string url, bool isSecuredServie = false)
        {
            using (var client = _httpClientFactory.CreateClient("BackendApi"))
            {
                if (isSecuredServie)
                {
                    var token = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                return await client.GetFromJsonAsync<ApiResult<T>>(url, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }

        public async Task<ApiResult<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest requestContent, bool isSecuredServie = true)
        {
            var client = _httpClientFactory.CreateClient("BackendApi");
            StringContent httpContent = null;
            if (requestContent != null)
            {
                var json = JsonSerializer.Serialize(requestContent);
                httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            }

            if (isSecuredServie)
            {
                var token = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await client.PostAsync(url, httpContent);
            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<ApiResult<TResponse>>(body, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            throw new Exception(body);
        }

        public async Task<ApiResult<bool>> PutAsync<TRequest, TResponse>(string url, TRequest requestContent, bool isSecuredServie = true)
        {
            var client = _httpClientFactory.CreateClient("BackendApi");
            HttpContent httpContent = null;
            if (requestContent != null)
            {
                var json = JsonSerializer.Serialize(requestContent);
                httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            }

            if (isSecuredServie)
            {
                var token = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await client.PutAsJsonAsync(url, httpContent);
            var body = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ApiResult<bool>>(body, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }
    }
}
