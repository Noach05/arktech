using ArkTech.Enums;
using ArkTech.Interfaces;
using ArkTech.SubServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArkTech.Domains;

namespace ArkTech.Services
{
    public class UserService : IUserService
    {
        private IUserRepo repo;
        private LoginService login;
        private PasswordHasher passwordHasher = new PasswordHasher();
        public UserService(IUserRepo repo)
        {
            this.repo = repo;
            login = new LoginService(repo);
        }
        public async Task<Result> CreateUser(User nUser)
        {
            if (nUser == null) { return new Result(false, "User is null"); }
            else { return await repo.CreateUser(nUser); }
        }

        public async Task<Result> UpdatePassword(User sUser, string oPassword, string nPassword)
        {
            if (login.VerifyPassword(sUser, oPassword))
            {
                byte[] hashyPassword = passwordHasher.Hash(sUser.Salt, nPassword);

                var result = await repo.UpdatePassword(sUser.Email, hashyPassword);
                if (result.Success)
                {
                    sUser.ChangePassword(hashyPassword);
                    return result;
                }
                else { return result; }
            }
            else { return new Result(false, "Incorrect Password or Email"); }
        }

        public async Task<Result> UpdateUser(User uUser, string nFirstName, string nLastName, string nEmail, string nPhone, string nAdress, int nAuthorisationLevel)
        {
            if(String.IsNullOrWhiteSpace(nFirstName) || String.IsNullOrWhiteSpace(nLastName) || String.IsNullOrWhiteSpace(nEmail) 
                || String.IsNullOrWhiteSpace(nPhone) || String.IsNullOrWhiteSpace(nAdress) || nAuthorisationLevel > 2 || nAuthorisationLevel < 0)
            { return new Result(false, "Invalid input data"); }
            var result = await repo.UpdateUser(nFirstName, nLastName, nEmail, nPhone, nAdress, nAuthorisationLevel);
            if (result.Success)
            {
                uUser.UpdateUser(nFirstName, nLastName, nEmail, nPhone, nAdress, nAuthorisationLevel);
                return result;
            }
            else { return result; }
        }
        public async Task<Result> DeactivateUser(User dUser, string confirm)
        {
            if (confirm == "confirm")
            {
                var result = await repo.DeactivateUser(dUser.Email);
                if (result.Success)
                {
                    dUser.DeactivateUser();
                    return result;
                }
                else { return result; }
            }
            else { return new Result(false, "Incorrect confirmation phrase"); }
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await repo.GetUsers();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email)) { return null; }
            else { return await repo.VerifyEmail(email); }
        }

        public async Task<List<User>> SearchUser(UserSearchByEnum searchType, string search)
        {
            return await repo.SearchForUser(searchType, search);
        }

        public async Task<Result> CheckEmailUniqueness(string email)
        {
            if (String.IsNullOrWhiteSpace(email)) { return new Result(false, "Invalid email"); }
            else
            {
                User? vUser = await repo.VerifyEmail(email);
                if (vUser is null) { return new Result(true, "Email alreadye exists"); }
                else { return new Result(false, "Email does not yet exist"); }
            }
        }
    }
}