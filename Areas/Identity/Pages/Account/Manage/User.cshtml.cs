using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PriceComparisonWeb.Areas.Identity.Pages.Account.Manage
{
    public class UserModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        
        [BindProperty]
        public List<IdentityUser>  IdentityUsers { get; set; }

        

        public IActionResult OnGet()
        {
            IdentityUsers = _userManager.Users.ToList();
            
            return Page();            
        }
    }

    
}