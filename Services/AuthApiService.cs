using System.Net.Http.Json;
using SymptomChecker_Admin2.Services.Interfaces;

namespace SymptomChecker_Admin2.Services
{
    public class AuthApiService : IAuthApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public AuthApiService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/login", new { username, password });
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            await _httpClient.PostAsync($"{_baseUrl}/logout", null);
        }
    }
}