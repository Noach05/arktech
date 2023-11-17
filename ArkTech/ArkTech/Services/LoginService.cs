using ArkTech.Domains;
using ArkTech.Interfaces;
using ArkTech.SubServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.Services
{
    public class LoginService : ILoginService
    {
        private PasswordHasher hasher = new PasswordHasher();
        private IUserRepo repo;
        public LoginService(IUserRepo repo)
        {
            this.repo = repo;
        }
        public async Task<User?> VerifyUserWebApp(string email, string password)
        {
            User? vUser = await repo.VerifyEmail(email);

            if (vUser is not null)
            {
                if (VerifyPassword(vUser, password))
                {
                    return vUser;
                }
                else { return null; }
            } else { return null; }
            
        }
        public async Task<User?> VerifyUserDesktopApp(string email, string password)
        {
            User? vUser = await repo.VerifyEmail(email);
            if (vUser is not null)
            {
                if (VerifyPassword(vUser, password) && (vUser.AuthorisationLevel == 1 || vUser.AuthorisationLevel == 2) && vUser.IsActivated is true)
                {
                    return vUser;
                }
                else { return null; }
            }
            else { return null; }
        }
        public bool VerifyPassword(User vUser, string password)
        {
            return hasher.Verify(password, vUser.Salt, vUser.HashyPassword);
        }
    }
}