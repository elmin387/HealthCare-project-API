using System.ComponentModel.DataAnnotations;

namespace HealthCare.Domain.Contracts.Account
{
    public class ForgotPasswordRequest
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "EmailInvalid")]
        public string Email { get; set; }

        public string? ClientResetPassURI { get; set; }
    }
}
