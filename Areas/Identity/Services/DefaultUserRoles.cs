using Microsoft.AspNetCore.Identity;

namespace PriceComparisonWeb.Areas.Identity.Services
{
    public class DefaultUserRole
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;      

        public DefaultUserRole(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;           
        }

        public async void CreateUserRoles()
        {              
            var roleCheck = await _roleManager.RoleExistsAsync("Administrator");

            if (!roleCheck)
            {                
                await _roleManager.CreateAsync(new IdentityRole("Administrator"));
            }
            
            var user = await _userManager.FindByEmailAsync("admin@dordam.com");

            if (user == null)
            {
                user = new IdentityUser
                {
                    Email = "admin@dordam.com",
                    UserName = "admin@dordam.com"
                };
                await _userManager.CreateAsync(user, "Dordam2019!");              
            }

            await _userManager.AddToRoleAsync(user, "Administrator");
        }
    }
}
