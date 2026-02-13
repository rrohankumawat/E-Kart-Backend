using EKart.Core.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace EKart.Infrastructure.JwtConfig
{
    public class JwtBearerOptionsSetup : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JwtConfigOptions _jwt;

        public JwtBearerOptionsSetup(IOptions<JwtConfigOptions> jwtOptions)
        {
            _jwt = jwtOptions.Value;
        }

        public void Configure(JwtBearerOptions options)
        {
            Configure(Options.DefaultName, options);
        }

        public void Configure(string? name, JwtBearerOptions options)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = _jwt.Issuer,
                ValidAudience = _jwt.Audience,
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey))
            };
        }
    }
}
