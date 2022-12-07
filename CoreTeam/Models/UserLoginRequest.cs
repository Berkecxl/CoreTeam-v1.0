using System.ComponentModel.DataAnnotations;

namespace CoreTeam.Models
{
    public class UserLoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } 
        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; } 
    }
}
