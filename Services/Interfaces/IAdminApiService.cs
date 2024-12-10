using SymptomChecker_Admin2.Models;

namespace SymptomChecker_Admin2.Services.Interfaces
{
    public interface IAdminApiService
    {
        Task<IEnumerable<UserModel>> GetUsers();
        //Task<IEnumerable<DiagnosisModel>> GetDiagnoses();
    }
}