using Microsoft.IdentityModel.Tokens;
using System;

namespace WheresNext.Shareds.Middleware.DataModels
{
    public class TokenProviderOptions
    {
        public string Path { get; set; } = "/api/accounts/token";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan Expiration { get; set; } = TimeSpan.FromHours(2);
        public SigningCredentials SigningCredentials { get; set; }
    }
}
