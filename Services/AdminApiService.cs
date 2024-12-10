using System.Text.Json;
using SymptomChecker_Admin2.Models;
using SymptomChecker_Admin2.Services.Interfaces;

namespace SymptomChecker_Admin2.Services
{
    public class AdminApiService : IAdminApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public AdminApiService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/users");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<IEnumerable<Dictionary<string, object>>>(responseBody);

            return users.Select(user => new UserModel
            {
                Username = user["username"].ToString(),
                RegistrationTime = user["registeredAt"].ToString()
            });
        }
    }
}