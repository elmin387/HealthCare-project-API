using HealthCare.Domain.Contracts.Account;
using HealthCare.Domain.Contracts.Email;
using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace HealthCare.API.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;
        private readonly IPatientService _patientService;

        public AccountController(IUserService userService, IAuthService authService, IEmailService emailService,IPatientService patientService)
        {
            _userService = userService;
            _authService = authService;
            _emailService = emailService;
            _patientService = patientService;
        }


        [AllowAnonymous]
        [HttpPost("Token")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            var response = await _authService.LoginAsync(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Registration")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            var result = await _userService.CreateUserAsync(model);
            if (result.Result.Succeeded)
            {
                var roleAssigned = await _userService.AddToRoleAsync(result.UserId);
                

                if (roleAssigned.Result.Succeeded && !string.IsNullOrEmpty(model.ClientConfirmationEmailURI))
                {
                    //await _patientService.GetPatientsAsync();
                    string code = await _userService.GenerateEmailConfirmationTokenAsync(roleAssigned.User);

                    var param = new Dictionary<string, string>
                    {
                        {"userId", result.UserId },
                        {"code", code }
                    };

                    var callback = QueryHelpers.AddQueryString(model.ClientConfirmationEmailURI, param);

                    var response = await _emailService.SendEmailAsync(
                        new SendEmailRequest
                        {
                            To = model.Email,
                            Subject = "Email confirmation",
                            Body = String.Format("Confirm your email on this <a href='{0}'>link</a>", callback),
                            IsBodyHtml = true
                        });

                    if (!response.Success)
                        return BadRequest(response);
                }

                return Ok();
            }
            return BadRequest(new { message = "User is not registered." });
        }

        [AllowAnonymous]
        [HttpGet("EmailConfirmation")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return BadRequest("Invalid Email Confirmation Request");

            var result = await _userService.ConfirmEmailAsync(userId, code);
            if (!result.Succeeded)
                return BadRequest("Invalid Email Confirmation Request");

            return Ok();
        }
    }
}
