namespace SymptomChecker_Admin2.Services.Interfaces
{
    public interface IAuthApiService
    {
        Task<bool> LoginAsync(string username, string password);
        Task LogoutAsync();
    }
}