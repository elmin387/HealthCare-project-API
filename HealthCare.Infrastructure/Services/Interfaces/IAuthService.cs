using HealthCare.Domain.Contracts.Account;
using HealthCare.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        //Task<AuthResponse> ExternalLoginAsync(ExternalAuthRequest request);
    }
}
