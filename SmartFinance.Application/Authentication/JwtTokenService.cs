using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartFinance.Application.Contracts.Authentication;
using SmartFinance.Application.Contracts.Authentication.Dto;
using SmartFinance.Domain.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Authentication
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;
        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AuthResponseDto GenerateToken(User user, List<string> roles)
        {
            var jwt = _configuration.GetSection("Jwt");

            var claims = new[]
            {
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email, user.EmailAddress),
            };

            var roleClaims = roles.Select(n => new Claim(ClaimTypes.Role, n));


            claims = claims.Concat(roleClaims).ToArray();
            var test = jwt["Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(jwt["ExpireMinutes"]));

            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new AuthResponseDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAt = expires
            };
        }
    }
}
