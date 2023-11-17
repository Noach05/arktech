using ArkTech.Interfaces;
using ArkTechWebApp.DTO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace ArkTechWebApp.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private IUserService userService;
        public UserDTO userDTO { get; set; }

        public ProfileModel(IUserService userService)
        {
            this.userService = userService;
        }

        public async void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                var email = User.Identity.Name;
                var user = await userService.GetUserByEmail(email);
                if (user != null)
                {
                    userDTO = new UserDTO(user);
                }
            }
        }

        public IActionResult OnPostLogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
