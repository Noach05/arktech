using ArkTech.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.Interfaces
{
    public interface ILoginService
    {
        Task<User?> VerifyUserWebApp(string email, string password);
        Task<User?> VerifyUserDesktopApp(string email, string password);
        bool VerifyPassword(User vUser, string password);
    }
}
