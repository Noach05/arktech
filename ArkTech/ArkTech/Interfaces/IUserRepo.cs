using ArkTech.Domains;
using ArkTech.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.Interfaces
{
    public interface IUserRepo
    {
        Task<Result> CreateUser(User nUser);
        Task<User?> VerifyEmail(string email);
        Task<Result> UpdatePassword(string email, byte[] hashyPassword);
        Task<Result> UpdateUser(string firstName, string lastName, string email, string? phone, string? adress, int isAdmin);
        Task<Result> DeactivateUser(string email);
        Task<List<User>> GetUsers();
        Task<List<User>> SearchForUser(UserSearchByEnum searchType, string searchQuery);
    }
}