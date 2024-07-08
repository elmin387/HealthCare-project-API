using HealthCare.Domain.Common;
using HealthCare.Domain.Contracts.Email;
using HealthCare.Infrastructure.Services.Interfaces;
using System.Net.Mail;
using System.Net;
using System.Text;
using HealthCare.Infrastructure.Common;

namespace HealthCare.Infrastructure.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;
        private string _wwwRootPath;
        private string emailTemplateDir;

        public EmailService(string host, int port, bool enableSSL, string userName, string password, string wwwRootPath)
        {
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
            this.userName = userName;
            this.password = password;
            _wwwRootPath = wwwRootPath;
        }
        public async Task<BaseResponse> SendEmailAsync(SendEmailRequest request)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                SmtpClient client = new SmtpClient(host, port)
                {
                    EnableSsl = enableSSL,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(userName, password)
                };

                MailAddress from = new MailAddress(userName, "HealthCare");
                MailAddress to = new MailAddress(request.To);

                MailMessage email = new MailMessage(from, to)
                {
                    IsBodyHtml = request.IsBodyHtml,
                    Subject = request.Subject,
                    Body = request.Body
                };

                if (request.File != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        request.File.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        Attachment att = new Attachment(new MemoryStream(fileBytes), request.File.FileName);
                        email.Attachments.Add(att);
                    }
                }

                await client.SendMailAsync(email);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleExceptionResponse(ex, response);
            }

            return response;
        }

        public string CreateEmailBodyFromTemplate(SimpleTemplateRequest request, string emailTemplateDir)
        {
            string email_body = "<p>First Name: " + request.FirstName + "</p>" +
                                "<p>Last Name: " + request.LastName + "</p>" +
                                "<p>Email: " + request.Email + "</p>" +
                                "<p>Phone Number: " + request.PhoneNumber + "</p>";

            Dictionary<string, string> mappings = new Dictionary<string, string>()
                {
                    { "|emailBody|", email_body }
                };

            string body = File.ReadAllText(Path.Combine(_wwwRootPath, emailTemplateDir));

            StringBuilder sb = new StringBuilder(body);

            foreach (KeyValuePair<string, string> item in mappings)
            {
                sb.Replace(item.Key, item.Value);
            }

            return sb.ToString();
        }
    }
}
