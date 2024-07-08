using HealthCare.Domain.Common;

namespace HealthCare.Domain.Contracts.Account
{
    public class AuthResponse: BaseResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string? Role { get; set; }
    }
}
