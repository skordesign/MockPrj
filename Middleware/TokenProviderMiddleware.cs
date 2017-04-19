using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using WheresNext.Shareds.Middleware.DataModels;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Security.Claims;
using Newtonsoft.Json;
using MockPrj.Repositories;
using System.IdentityModel.Tokens.Jwt;

namespace MockPrj.Middleware
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private readonly IAccountRepository _account;
        private readonly IRoleRepository _role;
        public TokenProviderMiddleware( RequestDelegate next, 
            IOptions<TokenProviderOptions> options, 
            IAccountRepository account, IRoleRepository role)
        {
            _next = next;
            _options = options.Value;
            _account = account;
            _role = role;
        }
        public Task Invoke(HttpContext httpContext)
        {
            if(!httpContext.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
            {
                return _next(httpContext);
            }
            if (!httpContext.Request.Method.Equals("POST") || !httpContext.Request.HasFormContentType)
            {
                httpContext.Response.StatusCode = 400;
                return httpContext.Response.WriteAsync("Bad request");
            }
            return GenerationToken(httpContext);
        }
        private async Task GenerationToken(HttpContext httpContext)
        {
            var email = httpContext.Request.Form["email"];
            var password = httpContext.Request.Form["password"];
            var account = _account.Get(email, password);
            if (account == null)
            {
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync("Invalid account");
                return;
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };
            var userRole = _role.Get(account.RoleId);
            claims.Add(new Claim(ClaimTypes.Role, userRole.Name.ToString()));

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                uid = account.Id,
                access_token = encodedJwt,
                expires_in = DateTime.Now.Add(_options.Expiration)
            };
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting =  Formatting.Indented }));
        }
    }
}
