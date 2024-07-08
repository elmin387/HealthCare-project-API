using System.ComponentModel.DataAnnotations;

namespace HealthCare.Domain.Contracts.Account
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "EmailInvalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
