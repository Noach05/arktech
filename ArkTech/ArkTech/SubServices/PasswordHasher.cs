using ArkTech.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.SubServices
{
    public class PasswordHasher : Pepper
    {
        public PasswordHasher() { }

        public byte[] Hash(byte[] salt, string password)
        {
            byte[] spPassword = new byte[salt.Length + password.Length + PepperStr.Length];
            Buffer.BlockCopy(salt, 0, spPassword, 0, salt.Length);
            Buffer.BlockCopy(password.ToCharArray(), 0, spPassword, salt.Length, password.Length);
            Buffer.BlockCopy(Encoding.UTF8.GetBytes(PepperStr), 0, spPassword, salt.Length + password.Length, PepperStr.Length);

            byte[] hashyPassword;
            using (var sha256 = new SHA256Managed())
            {
                hashyPassword = sha256.ComputeHash(spPassword);
            }

            return hashyPassword;
        }

        public bool Verify(string password, byte[] salt, byte[] hashyPassword)
        {
            byte[] hashyInputPassword = Hash(salt, password);
            return hashyPassword.SequenceEqual(hashyInputPassword);
        }

        public byte[] SaltShaker()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}