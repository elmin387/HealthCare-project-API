using HealthCare.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Interfaces
{
    public interface IJwtService
    {
        string GetToken(ApplicationUser user, IList<string> roles);
    }
}
