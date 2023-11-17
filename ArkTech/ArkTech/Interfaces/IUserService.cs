using ArkTech.Domains;
using ArkTech.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.Interfaces
{
    public interface IUserService
    {
        Task<Result> CreateUser(User nUser);
        Task<Result> UpdateUser(User uUser, string firstName, string lastName, string email, string? phone, string? adress, int isAdmin);
        Task<Result> UpdatePassword(User sUser, string oldPassword, string newPassword);
        Task<Result> DeactivateUser(User dUser, string confirm);
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserByEmail(string email);
        Task<List<User>> SearchUser(UserSearchByEnum searchType, string search);
        Task<Result> CheckEmailUniqueness(string email);
    }
}
