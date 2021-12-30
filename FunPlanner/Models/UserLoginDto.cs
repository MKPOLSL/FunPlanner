using System.ComponentModel.DataAnnotations;

namespace FunPlanner.Models
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Proszę wpisać e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Proszę wpisać hasło")]
        public string Password { get; set; }
    }
}
