using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace marcatel_api.Services
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly string _key;

        public JwtAuthenticationService(string key)
        {
            _key = key;
        }

        public string Authenticate(string username, string idUsername)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(idUsername))
            {
                return "";
            }

            var token = GenerateJSONWebToken(username, idUsername);

            return token;
        }

        public string GenerateJSONWebToken(string email, string idUsername)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                //new Claim(JwtRegisteredClaimNames.Email, email)
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Sid, idUsername)
            };

            /*var token = new JwtSecurityToken("https://localhost:5001",
                "https://localhost:5001",
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);*/

            var token = new JwtSecurityToken(null,
                null,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); ;
        }
    }

    public interface IJwtAuthenticationService
    {
        string Authenticate(string username, string idUsername);
        string GenerateJSONWebToken(string email, string idUsername);
    }
}
