using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace nexgen.Shared.JwtHelper
{
    public class JwtTokensUtility
    {
        private readonly string _signingKey;
        private readonly string _expiryTime;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _validateAudience;
        private readonly IConfiguration _configuration;

        public JwtTokensUtility(IConfiguration configuration)
        {
            _configuration = configuration;
            _signingKey = configuration["AuthConfig:signingKey"];
            _expiryTime = configuration["AuthConfig:expiryTime"];
            _issuer = configuration["AuthConfig:issuer"];
            _audience = configuration["AuthConfig:audience"];
            _validateAudience = configuration["AuthConfig:validateAudience"];
        }
        public string GenerateToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var secToken = new JwtSecurityToken(
                signingCredentials: credentials,
                issuer: "Sample",
                audience: "Sample",
                claims: new[]{
                    new Claim(JwtRegisteredClaimNames.Sub, username)
                },
                expires: DateTime.UtcNow.AddHours(int.Parse(_expiryTime)));

            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(secToken);
        }

        public bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters()
            {
                ValidateAudience = bool.Parse(_validateAudience), // Because there is no audiance in the generated token
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey)) // The same key as the one that generate the token
            };

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            return true;
        }
    }
}
