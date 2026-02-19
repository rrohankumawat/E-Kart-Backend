using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EKart.Core.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
