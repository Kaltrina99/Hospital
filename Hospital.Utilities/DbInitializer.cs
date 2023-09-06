using Hospital.Modals;
using Hospital.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Hospital.Utilities
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }

                var rez = _roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin).Result;

                if (!rez)
                {
                    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Patient)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Doctor)).GetAwaiter().GetResult();

                    var adminUser = new ApplicationUser
                    {
                        UserName = "Admin",
                        Email = "admin@gmail.com",
                        PictureUri = null,
                    };

                    var result = _userManager.CreateAsync(adminUser, "P@ssw0rd").Result;

                    if (result.Succeeded)
                    {
                        var appUser = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "admin@gmail.com");
                        if (appUser != null)
                        {
                            _userManager.AddToRoleAsync(appUser, WebSiteRoles.WebSite_Admin).Wait();
                        }
                    }
                    else
                    {
                        throw new ApplicationException($"User creation failed: {string.Join(", ", result.Errors)}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle initialization error, log the exception, and consider appropriate action.
                // Example: _logger.LogError(ex, "Error during database initialization.");
                throw;
            }
        }
    }
}
