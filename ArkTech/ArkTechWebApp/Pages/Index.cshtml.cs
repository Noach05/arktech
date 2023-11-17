using ArkTech.Interfaces;
using ArkTechWebApp.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArkTechWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IUserService userService;

        public IndexModel(ILogger<IndexModel> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        public UserDTO userDTO { get; set; }

        public async Task OnGet()
        {
            if(User.Identity.IsAuthenticated)
            {
                var email = User.Identity.Name;
                userDTO = new UserDTO(await userService.GetUserByEmail(email));
            }
            
        }
        
    }
}