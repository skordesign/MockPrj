using Microsoft.IdentityModel.Tokens;
using System;

namespace WheresNext.Shareds.Middleware.DataModels
{
    public class TokenProviderOptions
    {
        public string Path { get; set; } = "/accounts/token";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan Expiration { get; set; } = TimeSpan.FromDays(1);
        public SigningCredentials SigningCredentials { get; set; }
    }
}
