using System.ComponentModel.DataAnnotations;

namespace CoreTeam.Models
{
    public class ChangePasswordRequest
    {
        [Required, DataType(DataType.EmailAddress), Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required, DataType(DataType.Password), Display(Name = "Su Anki Sifre")]
        public string CurrentPassword { get; set; }
        
        [Required, DataType(DataType.Password), Display(Name = "Yeni Sifre")]
        [MinLength(6, ErrorMessage = "Lutfen sifrenizi en az 6 haneli yapiniz")]
        public string NewPassword { get; set; }
        
        [Required, DataType(DataType.Password), Display(Name = "Yeni Sifre Tekrar")]
        [Compare("NewPassword",ErrorMessage = "Yeni sifre ile uyusmuyor") ]
        public string ConfirmNewPassword { get; set; }
    }
}
