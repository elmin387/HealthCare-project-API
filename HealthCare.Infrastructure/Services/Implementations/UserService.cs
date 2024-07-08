using HealthCare.Domain.Common;
using HealthCare.Domain.Contracts.Account;
using HealthCare.Domain.ValueObjects;
using HealthCare.Infrastructure.Identity;
using HealthCare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Infrastructure.Services.Implementations
{
    public class UserService:IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;
        private readonly ICurrentUserService _currentUserService;

        public UserService(UserManager<ApplicationUser> userManager,
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory, 
            IAuthorizationService authorizationService, ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
            _currentUserService  = currentUserService;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u=>u.Id == userId);
            return user.UserName;
        }

        public async Task<ApplicationUser> GetUserAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(RegisterRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                RegistrationDateTime = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<(Result Result, ApplicationUser User)> AddToRoleAsync(string userId, string role = Role.User)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            var result = await _userManager.AddToRolesAsync(user, new[] { role });

            return (result.ToApplicationResult(), user);
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return user != null && await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return false;
            }

            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

            var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }

        public async Task<Result> ConfirmEmailAsync(string userId, string code)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            var result = await _userManager.ConfirmEmailAsync(user, code);

            return result.ToApplicationResult();
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return user != null ? await DeleteUserAsync(user) : Result.Success();
        }

        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public async Task<(Result Result, ApplicationUser User)> ChangePasswordAsync(ChangePasswordRequest model)
        {
            var currentUserId = _currentUserService.UserId;

            var user = await _userManager.Users.FirstAsync(u => u.Id == currentUserId);

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            return (result.ToApplicationResult(), user);
        }

        public async Task<(Result Result, ApplicationUser? User)> ResetPasswordAsync(ResetPasswordRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return (Result.Failure(errors: new List<string>()), user);
            }

            IdentityResult result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

            return (result.ToApplicationResult(), user);
        }

        public async Task<bool> IsEmailConfirmedAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }
    }
}
