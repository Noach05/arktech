using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTechDAL.Queries
{
    public class UserQuery
    {
        public const string CreateUserQuery = "USE dbi511127_arktech " +
            "INSERT INTO USERS (UID, FirstName, LastName, Email, Phone, Adress, AuthorisationLevel, Salt, HashedPassword, IsActivated) " +
            "values (@uid, @firstName, @lastName, @email, @phone, @adress, @authorisationLevel, @salt, @hashedPassword, @isActivated);";
        public const string GetUserByIdQuery = "SELECT * FROM USERS WHERE UID = @uid;";
        public const string VerifyUsernameQuery = "SELECT * FROM USERS WHERE Email = @email;";
        public const string UpdatePasswordQuery = "UPDATE USERS " +
            "SET HashedPassword = @hashedPassword" +
            "WHERE UID = @uid;";
        public const string UpdateUserQuery = "UPDATE USERS " +
            "SET FirstName = @firstName, LastName = @lastName, Email = @email, Phone = @phone, Adress = @adress, AuthorisationLevel = @authorisationLevel " +
            "WHERE Email = @email;"; 
        public const string DeactivateUserQuery = "UPDATE USERS " +
            "SET IsActivated = @isActivated WHERE Email = @email;";
        public const string GetAllUsersQuery = "SELECT * FROM USERS ORDER BY IsActivated DESC;";
        public const string SearchUserQuery = "SELECT * " +
            "FROM USERS WHERE search = @value ORDER BY IsActivated DESC;";
    }
}