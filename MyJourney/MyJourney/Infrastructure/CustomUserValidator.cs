using Microsoft.AspNetCore.Identity;

namespace MyJourney.Infrastructure
{
    public class CustomUserValidator : IUserValidator<IdentityUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager,
            IdentityUser user)
        {
            if (!string.IsNullOrEmpty(user.Email) && user.Email.ToLower().EndsWith("@thembe.com"))
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "EmailDomainError",
                    Description = "Only thembe.com email addresses are allowed"
                }));
            }
        }
    }
}
