using HealthCare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Implementations
{
    
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        public string? Role => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
        public bool IsSuperAdmin => !string.IsNullOrEmpty(UserId) && Role == Domain.ValueObjects.Role.SuperAdministrator;
        public bool IsUser => !string.IsNullOrEmpty(UserId) && Role == Domain.ValueObjects.Role.User;

    }
}
