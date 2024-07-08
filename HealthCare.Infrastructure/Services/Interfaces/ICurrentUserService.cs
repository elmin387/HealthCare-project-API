using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Interfaces
{
    public interface ICurrentUserService
    {
            string? UserId { get; }
            string? Role { get; }
            bool IsSuperAdmin { get; }
            bool IsUser { get; }
    }
}
