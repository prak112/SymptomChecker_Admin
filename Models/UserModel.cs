using System.ComponentModel.DataAnnotations;

namespace SymptomChecker_Admin2.Models
{
    public class UserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string RegistrationTime { get; set; }
    }
}