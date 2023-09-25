﻿using Microsoft.AspNetCore.Identity;

namespace MyJourney.Infrastructure
{
    public class CustomPasswordValidator : IPasswordValidator<IdentityUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager,
            IdentityUser user, string password)
        {
            List<IdentityError> errors = new();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsUserName",
                    Description = "Password cannot contain username"
                });
            }

            if (password.Contains("12345"))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsSequence",
                    Description = "Password cannot contain numeric sequence"
                });
            }

            return Task.FromResult(errors.Count == 0 ?
              IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
