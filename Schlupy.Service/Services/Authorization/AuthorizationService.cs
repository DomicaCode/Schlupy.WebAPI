using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Schlupy.Model;
using Schlupy.Model.Common;
using Schlupy.Service.Common.Services.Authorization;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Schlupy.Service.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Constructors

        public AuthorizationService(IMapper mapper)
        {
            Mapper = mapper;
        }

        #endregion Constructors

        #region Properties

        public IMapper Mapper { get; }

        #endregion Properties

        #region Methods

        public IToken CreateToken(string userName, string password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("DrhX3HpOxgAKo94ryrOaQbBVIdrKqJJ8");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = CreateUserClaims(userName, password),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);

            return new Token
            {
                AccessToken = tokenHandler.WriteToken(jwtToken)
            };
        }

        private ClaimsIdentity CreateUserClaims(string username, string password)
        {
            return new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, username),
                    new Claim("id", "nekiid")
                });
        }

        #endregion Methods
    }
}