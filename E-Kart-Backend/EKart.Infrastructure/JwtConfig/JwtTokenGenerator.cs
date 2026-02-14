using EKart.Core.JwtConfig;
using EKart.Core.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EKart.Infrastructure.JwtConfig
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtConfigOptions _options;

        public JwtTokenGenerator(IOptions<JwtConfigOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateToken(Guid userId, string email, string role)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_options.ExpiryMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
