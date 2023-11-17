using ArkTech.Domains;
using ArkTech.Enums;
using ArkTech.Interfaces;
using ArkTechDAL.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArkTechDAL.Repositories
{
    public class UserRepository : UserQuery, IUserRepo
    {
        private SqlConnection _con;
        private BaseConnection _baseCon = new BaseConnection();
        private List<User> _users = new List<User>();
        private readonly Mappers _mappers = new Mappers();

        public UserRepository()
        {
            _con = _baseCon.GetSqlConnection();
        }

        public async Task<Result> CreateUser(User nUser)
        {
            if (String.IsNullOrWhiteSpace(nUser.FirstName) || String.IsNullOrWhiteSpace(nUser.LastName) || String.IsNullOrWhiteSpace(nUser.Email) ||
                String.IsNullOrWhiteSpace(nUser.Phone) || String.IsNullOrWhiteSpace(nUser.Adress) || nUser.AuthorisationLevel > 2 || 
                nUser.AuthorisationLevel < 0 || nUser.HashyPassword is null) { return new Result(false, "Unacceptable values in updating user"); }
            try
            {
                await _con.OpenAsync();
                SqlCommand cmd = new SqlCommand(CreateUserQuery, _con);

                if (nUser is null) { return new Result(false, "User object was invalid"); }

                int activated;
                if (nUser.IsActivated == true) { activated = 1; } else { activated = 0; }

                cmd.Parameters.AddWithValue("@uid", nUser.UID);
                cmd.Parameters.AddWithValue("@firstName", nUser.FirstName);
                cmd.Parameters.AddWithValue("@lastName", nUser.LastName);
                cmd.Parameters.AddWithValue("@email", nUser.Email);
                cmd.Parameters.AddWithValue("@phone", nUser.Phone);
                cmd.Parameters.AddWithValue("Adress", nUser.Adress);
                cmd.Parameters.AddWithValue("@authorisationLevel", nUser.AuthorisationLevel );
                cmd.Parameters.AddWithValue("@salt", nUser.Salt);
                cmd.Parameters.AddWithValue("@hashedPassword", nUser.HashyPassword);
                cmd.Parameters.AddWithValue("@isActivated", activated);
                await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                return new Result(true, "Successfully created user");
            }
            catch (SqlException ex) { throw new InvalidOperationException($"Something went wrong while creating user data: {ex.Message}"); }
            finally { _con.Close(); }
        }
        public async Task<User?> VerifyEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email)) { return null; }
            try
            {
                await _con.OpenAsync();
                SqlCommand cmd = new SqlCommand(VerifyUsernameQuery, _con);
                cmd.Parameters.AddWithValue("@email", email);

                SqlDataReader reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
                await reader.ReadAsync().ConfigureAwait(false);

                if (!reader.HasRows)
                {
                    return null;
                }
                else
                {
                    return _mappers.MapUserFromDB(reader);
                }
            }
            catch (SqlException ex) { throw new InvalidOperationException($"Something went wrong while reading user data by Email: {ex.Message}"); }
            finally { _con.Close(); }
        }
        public async Task<Result> UpdatePassword(string email, byte[] hashyPassword)
        {
            if (String.IsNullOrWhiteSpace(email) || hashyPassword is null) { return new Result(false, "Unacceptable values on updating password"); }
            try
            {
                await _con.OpenAsync();
                SqlCommand cmd = new SqlCommand(UpdatePasswordQuery, _con);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@hashedPassword", hashyPassword);
                await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                return new Result(true, "Successfully updated password");
            } catch (SqlException ex) { throw new InvalidOperationException($"Something went wrong while updating user password: {ex.Message}"); }
            finally { _con.Close(); }
        }
        public async Task<Result> UpdateUser(string firstName, string lastName, string email, string phone, string adress, int isAdmin)
        {
            if (String.IsNullOrWhiteSpace(firstName) || String.IsNullOrWhiteSpace(lastName) || String.IsNullOrWhiteSpace(email) || 
                String.IsNullOrWhiteSpace(phone) || String.IsNullOrWhiteSpace(adress) || isAdmin > 2 || isAdmin < 0) { return new Result(false, "Unacceptable values in updating user"); }
            try
            {
                await _con.OpenAsync();
                SqlCommand cmd = new SqlCommand(UpdateUserQuery, _con);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@adress", adress);
                cmd.Parameters.AddWithValue("@authorisationLevel", isAdmin);
                await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                return new Result(true, "Successfully updated user");
            } catch (SqlException ex) { throw new InvalidOperationException($"Something went wrong while updating user data: {ex.Message}"); }
            finally { _con.Close(); }
        }

        public async Task<Result> DeactivateUser(string email)
        {
            if (String.IsNullOrWhiteSpace(email)) { return new Result(false, "Unacceptable values deactivating user"); }
            try
            {
                await _con.OpenAsync();
                SqlCommand cmd = new SqlCommand(DeactivateUserQuery, _con);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@IsActivated", 0);
                await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                return new Result(true, "Successfully deactivated user");
            } catch (SqlException ex) { throw new InvalidOperationException($"Something went wrong while deactivating user: {ex.Message}"); }
            finally { _con.Close(); }
        }

        public async Task<List<User>> GetUsers()
        {
            _users.Clear();
            try
            {

                this._users.Clear();
                await _con.OpenAsync();
                SqlCommand cmd = new SqlCommand(GetAllUsersQuery, _con);
                SqlDataReader reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);

                while (await reader.ReadAsync().ConfigureAwait(false))
                {
                    if (!reader.HasRows)
                    {
                        return new List<User>();
                    }
                    else
                    {
                        _users.Add(_mappers.MapUserFromDB(reader));
                    }
                }
                return _users;
                
            } catch(SqlException ex) { throw new InvalidOperationException($"Something went wrong while reading all user data: {ex.Message}"); }
            finally { _con.Close(); }
        }

        public async Task<List<User>> SearchForUser(UserSearchByEnum searchType, string searchQuery)
        {
            try
            {
                this._users.Clear();
                await _con.OpenAsync();

                string replace = @"\bsearch\b";
                string endQuery = Regex.Replace(SearchUserQuery, replace, searchType.ToString());

                SqlCommand cmd = new SqlCommand(endQuery, _con);
                cmd.Parameters.AddWithValue("@value", searchQuery);

                SqlDataReader reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
                while (await reader.ReadAsync().ConfigureAwait(false))
                {
                    if (!reader.HasRows)
                    {
                        return new List<User>();
                    }
                    else
                    {
                        _users.Add(_mappers.MapUserFromDB(reader));
                    }
                }
                return _users;
                
            }
            catch (SqlException ex) { throw new InvalidOperationException($"Something went wrong while searching for user data by paramaters: {ex.Message}"); }
            finally { _con.Close(); }
        }
    }
}