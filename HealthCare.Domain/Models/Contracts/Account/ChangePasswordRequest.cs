using System.ComponentModel.DataAnnotations;

namespace HealthCare.Domain.Contracts.Account
{
    public class ChangePasswordRequest
    {
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "PasswordLength", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "PasswordConfirmation")]
        public string ConfirmPassword { get; set; }
    }
}
