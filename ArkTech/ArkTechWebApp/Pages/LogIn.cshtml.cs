using ArkTech.Interfaces;
using ArkTech.Domains;
using ArkTechWebApp.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ArkTechWebApp.Pages
{
    public class LogInModel : PageModel
    {
        private ILoginService login;

        [BindProperty]
        public UserLogInDTO UserLogInDTO { get; set; }

        public LogInModel(ILoginService login)
        {
            this.login = login;
            UserLogInDTO = new UserLogInDTO();
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                User? user = await login.VerifyUserWebApp(UserLogInDTO.Email, UserLogInDTO.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("key", UserLogInDTO.Email);

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, UserLogInDTO.Email));

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties { IsPersistent = true };

                    HttpContext?.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToPage("/Profile");
                }
                else
                {
                    TempData["ErrorMessageLogin"] = "Incorrect Username or Password!";
                    return RedirectToPage("/Login");
                }
            }
            else
            {
                TempData["ErrorMessageLogin"] = "Incorrect ModelState!";
                return RedirectToPage("/Login");
            }   
        }
    }
}
