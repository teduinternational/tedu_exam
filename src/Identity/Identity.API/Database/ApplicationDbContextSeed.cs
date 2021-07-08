using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Identity.API.Database
{
    public class ApplicationDbContextSeed
    {
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();

        public async Task SeedAsync(ApplicationDbContext context, IWebHostEnvironment env,
            ILogger<ApplicationDbContextSeed> logger, IOptions<AppSettings> settings, int? retry = 0)
        {
            if (retry != null)
            {
                int retryForAvailability = retry.Value;

                try
                {

                    if (!context.Users.Any())
                    {
                        context.Users.AddRange(GetDefaultUser());

                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    if (retryForAvailability < 10)
                    {
                        retryForAvailability++;

                        logger.LogError(ex, "EXCEPTION ERROR while migrating {DbContextName}", nameof(ApplicationDbContext));

                        await SeedAsync(context, env, logger, settings, retryForAvailability);
                    }
                }
            }
        }
        private IEnumerable<ApplicationUser> GetDefaultUser()
        {
            var user =
            new ApplicationUser()
            {
                Email = "admin@demo.com",
                Id = Guid.NewGuid().ToString(),
                LastName = "Account",
                FirstName = "Demo",
                PhoneNumber = "1234567890",
                UserName = "admin@demo.com",
                NormalizedEmail = "ADMIN@DEMO.COM",
                NormalizedUserName = "ADMIN@DEMO.COM",
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123$");

            return new List<ApplicationUser>()
            {
                user
            };
        }
    }
}