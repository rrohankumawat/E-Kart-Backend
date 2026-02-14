using System;
using System.Collections.Generic;
using System.Text;

namespace EKart.Core.Options
{
    public class ConnectionStringOptions
    {
        public const string SectionName = "ConnectionStrings";
        public string DefaultConnection { get; set; } = string.Empty;
    }
}
