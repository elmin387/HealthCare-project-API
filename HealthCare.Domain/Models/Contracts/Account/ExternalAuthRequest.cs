using HealthCare.Domain.ValueObjects;

namespace HealthCare.Domain.Contracts.Account
{
    public class ExternalAuthRequest
    {
        public string Provider { get; set; }
        public string Token { get; set; } //Facebook: accessToken; Google: tokenId
        public string RoleName { get; set; } = Role.User;
    }
}
