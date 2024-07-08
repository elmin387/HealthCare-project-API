using HealthCare.Domain.Contracts.Account;
using HealthCare.Infrastructure.Common;
using HealthCare.Infrastructure.Identity;
using HealthCare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HealthCare.Infrastructure.Services.Implementations
{
    public class AuthService:IAuthService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(IJwtService jwtService,UserManager<ApplicationUser> userManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            AuthResponse response = new AuthResponse();
            ApplicationUser user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                PasswordVerificationResult result = _userManager.PasswordHasher
                    .VerifyHashedPassword(user, user.PasswordHash, request.Password);

                if (result != PasswordVerificationResult.Success)
                {
                    ExceptionHandler.HandleFailedMessage(response, "Username or password is incorrect.");
                    return response;
                }

                return await Authenticate(user);
            }
            ExceptionHandler.HandleFailedMessage(response, "User does not exist.");
            return response;
        }


        private async Task<AuthResponse> Authenticate(ApplicationUser user)
        {
            AuthResponse response = new AuthResponse();

            try
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token = _jwtService.GetToken(user, roles);

                response.Token = token;
                response.Email = user.Email;
                response.Role = roles?.FirstOrDefault() != null ? roles.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleExceptionResponse(ex, response);
            }

            return response;
        }
    }
}
