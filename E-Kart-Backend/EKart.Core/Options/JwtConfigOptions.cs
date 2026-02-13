using System;
using System.Collections.Generic;
using System.Text;

namespace EKart.Core.Options
{
    public class JwtConfigOptions
    {
        public const string SectionName = "JwtConfig";
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public int ExpiryMinutes { get; set; }
    }
}
