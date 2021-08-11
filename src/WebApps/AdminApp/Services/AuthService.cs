using AdminApp.Core;
using AdminApp.Core.Authentication;
using AdminApp.Models;
using AdminApp.Services.Interfaces;
using Blazored.SessionStorage;
using IdentityModel.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ISessionStorageService _sessionStorage;
        private static DiscoveryDocumentResponse _disco;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(
            HttpClient httpClient,
            ILogger<AuthService> logger,
            ISessionStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _sessionStorage = localStorage;
            _logger = logger;
            _configuration = configuration;
            _authenticationStateProvider = authenticationStateProvider;

        }
        public async Task<TokenResponse> LoginAsync(LoginRequest loginRequest)
        {
            _disco = await HttpClientDiscoveryExtensions.GetDiscoveryDocumentAsync(
               _httpClient,
               _configuration["IdentityServerConfig:IdentityServerUrl"]);

            if (_disco.IsError)
            {
                throw new ApplicationException($"Status code: {_disco.IsError}, Error: {_disco.Error}");
            }

            var token = await RequestTokenAsync(loginRequest.UserName, loginRequest.Password);
            if (token.IsError == false)
            {
                await _sessionStorage.SetItemAsync(KeyConstants.AccessToken, token.AccessToken);
                await _sessionStorage.SetItemAsync(KeyConstants.RefreshToken, token.RefreshToken);
                ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginRequest.UserName);

            }
            return token;
        }


        private async Task<TokenResponse> RequestTokenAsync(string user, string password)
        {
            _logger.LogInformation("begin RequestTokenAsync");
            var response = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = _disco.TokenEndpoint,

                ClientId = _configuration["IdentityServerConfig:ClientId"],
                ClientSecret = _configuration["IdentityServerConfig:ClientSecret"],
                Scope = "email openid roles profile offline_access",

                UserName = user,
                Password = password
            });

            return response;
        }

        public async Task LogoutAsync()
        {
            await _sessionStorage.RemoveItemAsync(KeyConstants.AccessToken);
            await _sessionStorage.RemoveItemAsync(KeyConstants.RefreshToken);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
