using ArkTech.Domains;
using ArkTech.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTechUnitTesting.MockRepos
{
    public class MockUserRepo : IUserRepo
    {
        private List<User> _users;
        private List<User> _searchUsers;
        public MockUserRepo()
        {
            _users = new List<User>();
            _searchUsers = new List<User>();
        }

        public async Task<Result> CreateUser(User nUser)
        {
            if (nUser == null) { return new Result(false, "User is null"); }
            this._users.Add(nUser);
            return new Result(true, "Successfully added user");
        }

        public async Task<Result> DeactivateUser(string email)
        {
            if (String.IsNullOrWhiteSpace(email)) { return new Result(false, "Invalid email"); }
            var u = this._users.FirstOrDefault(x => x.Email == email);
            if (u == null) { return new Result(false, "User not found"); }
            else
            {
                u.DeactivateUser();
                if (u.IsActivated.Equals(true)) { return new Result(false, "User unsuccessfully updated"); }
                else { return new Result(false, "User successfully updated"); }
            }
        }

        public async Task<List<User>> GetUsers()
        {
            return this._users;
        }

        public async Task<List<User>> SearchForUser(UserSearchByEnum searchType, string searchQuery)
        {
            _searchUsers.Clear();
            if (searchType.Equals(UserSearchByEnum.FirstName))
            {
                foreach (var u in _users)
                {
                    if (u.FirstName.Equals(searchQuery)) { _searchUsers.Add(u); }
                }
            }
            if (searchType.Equals(UserSearchByEnum.LastName))
            {
                foreach (var u in _users)
                {
                    if (u.LastName.Equals(searchQuery)) { _searchUsers.Add(u); }
                }
            }
            if (searchType.Equals(UserSearchByEnum.Email))
            {
                foreach (var u in _users)
                {
                    if (u.Email.Equals(searchQuery)) { _searchUsers.Add(u); }
                }
            }
            if (searchType.Equals(UserSearchByEnum.Phone))
            {
                foreach (var u in _users)
                {
                    if (u.Phone.Equals(searchQuery)) { _searchUsers.Add(u); }
                }
            }
            if (searchType.Equals(UserSearchByEnum.Adress))
            {
                foreach (var u in _users)
                {
                    if (u.Adress.Equals(searchQuery)) { _searchUsers.Add(u); }
                }
            }
            if (searchType.Equals(UserSearchByEnum.AuthorisationLevel))
            {
                foreach (var u in _users)
                {
                    if (u.AuthorisationLevel.Equals(searchQuery)) { _searchUsers.Add(u); }
                }
            }
            if (searchType.Equals(UserSearchByEnum.IsActivated))
            {
                foreach (var u in _users)
                {
                    if (u.IsActivated.Equals(searchQuery)) { _searchUsers.Add(u); }
                }
            }
            return _searchUsers;
        }

        public async Task<Result> UpdatePassword(string email, byte[] hashyPassword)
        {
            if (String.IsNullOrWhiteSpace(email)) { return new Result(false, "Invalid email"); }
            var u = this._users.FirstOrDefault(x => x.Email == email);
            if (u == null) { return new Result(false, "User not found"); }
            else
            {
                u.ChangePassword(hashyPassword);
                if (u.HashyPassword.Equals(hashyPassword)) { return new Result(true, "Successfully updated user"); }
                else { return new Result(false, "User unsuccessfully updated"); }
            }
        }

        public async Task<Result> UpdateUser(string firstName, string lastName, string email, string? phone, string? adress, int isAdmin)
        {
            var u = this._users.FirstOrDefault(x => x.Email == email);
            if (u == null) { return new Result(false, "User not found"); }
            else
            {
                u.UpdateUser(firstName, lastName, email, phone, adress, isAdmin);
                return new Result(true, "User updated successfully");
            }
        }

        public async Task<User?> VerifyEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email)) { return null; }
            var u = this._users.FirstOrDefault(x => x.Email == email);
            return u;
        }
    }
}
