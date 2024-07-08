using HealthCare.Domain.Common;
using HealthCare.Domain.Contracts.Account;
using HealthCare.Domain.ValueObjects;
using HealthCare.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<ApplicationUser> GetUserAsync(string email);
        Task<(Result Result, string UserId)> CreateUserAsync(RegisterRequest request);
        Task<(Result Result, ApplicationUser User)> AddToRoleAsync(string userId, string role = Role.User);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<Result> ConfirmEmailAsync(string userId, string code);

        Task<Result> DeleteUserAsync(string userId);
        Task<(Result Result, ApplicationUser User)> ChangePasswordAsync(ChangePasswordRequest model);
        Task<(Result Result, ApplicationUser? User)> ResetPasswordAsync(ResetPasswordRequest model);
        Task<bool> IsEmailConfirmedAsync(string email);
        Task<string> GeneratePasswordResetTokenAsync(string email);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
    }
}
