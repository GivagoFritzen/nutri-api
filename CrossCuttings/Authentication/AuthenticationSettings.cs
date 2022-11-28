using Microsoft.IdentityModel.Tokens;
using System;

namespace CrossCutting.Authentication
{
    public static class AuthenticationSettings
    {
        public static string Secret = "feçaf7d8863b48e197b9287d492b708e";
        public static TimeSpan ExpireTime = TimeSpan.FromHours(2);
        public static string Algorithm = SecurityAlgorithms.HmacSha256Signature;
    }
}
