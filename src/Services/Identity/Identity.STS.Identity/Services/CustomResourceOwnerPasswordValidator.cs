using Identity.Admin.EntityFramework.Shared.Entities.Identity;
using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.STS.Identity.Services
{
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly ILogger<CustomResourceOwnerPasswordValidator> _logger;

        public CustomResourceOwnerPasswordValidator(
            SignInManager<UserIdentity> signInManager,
            UserManager<UserIdentity> userManager,
           ILogger<CustomResourceOwnerPasswordValidator> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(context.UserName, context.Password, false, false);
            if (signInResult.Succeeded)
            {
                _logger.LogError("Login from Resource Owner Password is success");

                var user = await _userManager.FindByNameAsync(context.UserName);
                context.Result = new GrantValidationResult(user.Id, OidcConstants.AuthenticationMethods.Password);
            }
            _logger.LogError("Login from Resource Owner Password is failed");
        }
    }
}