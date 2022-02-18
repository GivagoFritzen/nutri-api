﻿using Core.Interfaces.Services;
using System;

namespace Services
{
    public class SecurityService : ISecurityService
    {
        public bool ComparePassword(string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                return false;

            return password.Trim().Equals(confirmPassword.Trim());
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, passwordHash);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new FormatException();

            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
