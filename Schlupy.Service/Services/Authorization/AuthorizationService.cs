using Microsoft.IdentityModel.Tokens;
using Schlupy.Model.Common.Models;
using Schlupy.Model.Models;
using Schlupy.Service.Common.Services.Authorization;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Schlupy.Service.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Methods

        public IToken CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("DrhX3HpOxgAKo94ryrOaQbBVIdrKqJJ8");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = CreateUserClaims(user),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);

            return new Token
            {
                AccessToken = tokenHandler.WriteToken(jwtToken)
            };
        }

        private static ClaimsIdentity CreateUserClaims(User user)
        {
            return new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("userId", user.Id.ToString())
                });
        }

        #endregion Methods
    }
}