using Microsoft.AspNetCore.Http;

namespace HealthCare.Domain.Contracts.Email
{
    public class SendEmailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public IFormFile File { get; set; }
    }
}
