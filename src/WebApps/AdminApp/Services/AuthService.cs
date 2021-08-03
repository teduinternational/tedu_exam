using System;
using System.Net.Http;
using System.Threading.Tasks;
using AdminApp.Models;
using AdminApp.Services.Interfaces;
using Blazored.LocalStorage;
using IdentityModel.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AdminApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private static DiscoveryDocumentResponse _disco;
        private readonly AppSettings _settings;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            HttpClient httpClient,
            ILogger<AuthService> logger,
            ILocalStorageService localStorage,
            IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _logger = logger;
            _settings = settings.Value;
        }
        public async Task<TokenResponse> Login(LoginRequest loginRequest)
        {
            _disco = await HttpClientDiscoveryExtensions.GetDiscoveryDocumentAsync(
               _httpClient,
               "");

            if (_disco.IsError)
            {
                throw new ApplicationException($"Status code: {_disco.IsError}, Error: {_disco.Error}");
            }

            return await RequestTokenAsync(loginRequest.UserName, loginRequest.Password);
        }

        
        private async Task<TokenResponse> RequestTokenAsync(string user, string password)
        {
            _logger.LogInformation("begin RequestTokenAsync");
            var response = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = _disco.TokenEndpoint,

                ClientId = _settings.IdentityServerConfig.ClientId,
                ClientSecret = _settings.IdentityServerConfig.ClientSecret,
                Scope = "email openid offline_access exam_api",

                UserName = user,
                Password = password
            });

            return response;
        }
    }
}
