using ArkTech.Domains;

namespace ArkTechWebApp.DTO
{
    public class UserDTO
    {
        public UserDTO() { }
        public UserDTO(User user)
        {
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.Phone = user.Phone;
            this.Adress = user.Adress;
            //this.AuthorisationLevel = user.AuthorisationLevel;
            this.IsActivated = user.IsActivated;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Adress { get; private set; }
        //public int AuthorisationLevel { get; private set; }
        public bool IsActivated { get; private set; }
    }
}
