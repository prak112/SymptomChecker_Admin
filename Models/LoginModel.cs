using System.ComponentModel.DataAnnotations;

namespace SymptomChecker_Admin2.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}