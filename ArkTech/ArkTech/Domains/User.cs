using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArkTech.SubServices;

namespace ArkTech.Domains
{
    public class User
    {
        private Guid _uid;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private string _adress;
        private int _authorisationLevel;
        private byte[] _salt;
        private byte[] _hashyPassword;
        private bool _isActivated;
        private PasswordHasher hasher = new PasswordHasher();

        public User(string firstName, string? lastName, string email, string? phone, string? adress, int authorisationLevel, string password)
        {
            UID = Guid.NewGuid();
            FirstName = firstName;
            if (!string.IsNullOrEmpty(lastName)) { LastName = lastName; } else { LastName = ""; }
            Email = email;
            if (!string.IsNullOrEmpty(phone)) { Phone = phone; } else { Phone = ""; }
            if (!string.IsNullOrEmpty(adress)) { Adress = adress; } else { Adress = ""; }
            AuthorisationLevel = authorisationLevel;
            Salt = hasher.SaltShaker();
            HashyPassword = hasher.Hash(Salt, password);
            IsActivated = true;
        }
        public User(Guid uid, string firstName, string? lastName, string email, string? phone, string? adress, int authorisationLevel, byte[] salt, byte[] hashyPassword, bool isActivated)
        {
            UID = uid;
            FirstName = firstName;
            if (!string.IsNullOrEmpty(lastName)) { LastName = lastName; } else { LastName = ""; }
            Email = email;
            if (!string.IsNullOrEmpty(phone)) { Phone = phone; } else { Phone = ""; }
            if (!string.IsNullOrEmpty(adress)) { Adress = adress; } else { Adress = ""; }
            AuthorisationLevel = authorisationLevel;
            Salt = salt;
            HashyPassword = hashyPassword;
            IsActivated = isActivated;
            Salt = salt;
            HashyPassword = hashyPassword;
        }
        public Guid UID
        {
            get { return _uid; }
            private set { _uid = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            private set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            private set { _lastName = value; }
        }
        public string Email
        {
            get { return _email; }
            private set { _email = value; }
        }
        public string Phone
        {
            get { return _phone; }
            private set { _phone = value; }
        }
        public string Adress
        {
            get { return _adress; }
            private set { _adress = value; }
        }
        public int AuthorisationLevel
        {
            get { return _authorisationLevel; }
            private set { _authorisationLevel = value; }
        }
        public byte[] Salt
        {
            get { return _salt; }
            private set { _salt = value; }
        }
        public byte[] HashyPassword
        {
            get { return _hashyPassword; }
            private set { _hashyPassword = value; }
        }
        public bool IsActivated
        {
            get { return _isActivated; }
            private set { _isActivated = value; }
        }

        public override string ToString()
        {
            string role;
            if (AuthorisationLevel == 2) { role = "Administrator"; } else if (AuthorisationLevel == 1) { role = "Employee"; } else { role = "Customer"; }
            string active;
            if (IsActivated) { active = "Active"; } else { active = "Inactive"; }

            return string.Format($"{LastName}, {FirstName}, {role}, {active}");
        }
        public void UpdateUser(string nFirstName, string? nLastName, string nEmail, string? nPhone, string? nAdress, int nAuthorisationLevel)
        {
            FirstName = nFirstName;
            if (!string.IsNullOrEmpty(nLastName)) { LastName = nLastName; } else { LastName = ""; }
            Email = nEmail;
            if (!string.IsNullOrEmpty(nPhone)) { Phone = nPhone; } else { Phone = ""; }
            if (!string.IsNullOrEmpty(nAdress)) { Adress = nAdress; } else { Adress = ""; }
            AuthorisationLevel = nAuthorisationLevel;
        }
        public void ChangePassword(byte[] nHashyPassword)
        {
            HashyPassword = nHashyPassword;
        }
        public void DeactivateUser()
        {
            IsActivated = false;    
        }
    }
}