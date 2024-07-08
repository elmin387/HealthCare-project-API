using HealthCare.Domain.Common;
using HealthCare.Domain.Contracts.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Interfaces
{
    public interface IEmailService
    {
        Task<BaseResponse> SendEmailAsync(SendEmailRequest request);
        string CreateEmailBodyFromTemplate(SimpleTemplateRequest request, string emailTemplateDir);
    }
}
