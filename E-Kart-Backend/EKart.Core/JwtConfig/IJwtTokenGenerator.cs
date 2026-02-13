using System;
using System.Collections.Generic;
using System.Text;

namespace EKart.Core.JwtConfig
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string email, string role);
    }
}
