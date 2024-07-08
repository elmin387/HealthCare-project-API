using System.ComponentModel.DataAnnotations;

namespace HealthCare.Domain.Contracts.Account
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "EmailInvalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "PasswordLength", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "PasswordConfirmation")]
        public string ConfirmPassword { get; set; }

        public string? ClientConfirmationEmailURI { get; set; }
    }
}
