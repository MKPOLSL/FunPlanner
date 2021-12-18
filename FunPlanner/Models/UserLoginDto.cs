using System.ComponentModel.DataAnnotations;

namespace FunPlanner.Models
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Proszę wpisać imię")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Proszę wpisać nazwisko")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Proszę wpisać hasło")]
        public string Password { get; set; }
    }
}
