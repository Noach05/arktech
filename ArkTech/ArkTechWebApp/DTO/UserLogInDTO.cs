using ArkTech.Domains;
using System.ComponentModel.DataAnnotations;

namespace ArkTechWebApp.DTO
{
    public class UserLogInDTO
    {
        public UserLogInDTO() { }
        public UserLogInDTO(User user)
        {
            this.Email = user.Email;
        }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
