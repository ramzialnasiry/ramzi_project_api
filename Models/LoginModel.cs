using System.ComponentModel.DataAnnotations;

namespace ramzi_project_api.Models
{
    public class LoginModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
