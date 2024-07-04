using Ananas.Core.Interfaces;
using Ananas.Core.Models;
using Ananas.Infrastructure.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace Ananas.Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        public TokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task Add(string entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string entity)
        {
            throw new NotImplementedException();
        }

        public string GenerateAccessToken(User user)
        {

            //var userRoles = await _userManager.GetRolesAsync(user);


            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            //foreach (var role in userRoles)
            //{
            //    authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            //}

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( _configuration["JWT:Secret"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                authClaims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return accessToken;
        }

        public Task<IEnumerable<string>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> RefreshToken(string accessToken)
        {
            throw new NotImplementedException();
        }

        public void Update(string entity)
        {
            throw new NotImplementedException();
        }
    }
}
