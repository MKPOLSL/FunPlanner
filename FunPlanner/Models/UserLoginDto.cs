using System.ComponentModel.DataAnnotations;

namespace FunPlanner.Models
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
