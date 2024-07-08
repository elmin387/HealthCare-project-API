using Microsoft.AspNetCore.Identity;

namespace HealthCare.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public virtual DateTime RegistrationDateTime { get; set; }
    }
}
