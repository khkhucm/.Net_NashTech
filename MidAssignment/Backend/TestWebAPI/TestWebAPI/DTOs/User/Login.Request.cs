using System.ComponentModel.DataAnnotations;

namespace TestWebAPI.DTOs.User
{
    public class LoginRequest
    {
        [Required] 
        public string Username { get; set; }

        [Required] 
        public string Password { get; set; }
    }
}
