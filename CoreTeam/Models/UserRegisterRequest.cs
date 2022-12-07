using System.ComponentModel.DataAnnotations;

namespace CoreTeam.Models
{
    public class UserRegisterRequest
    {
        public int Id { get; set; }
        
        [Required, EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required, EmailAddress]
        public string Surname { get; set; }
        
        [Required, MinLength(6, ErrorMessage = "Lutfen sifrenizi en az 6 haneli yapiniz"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
