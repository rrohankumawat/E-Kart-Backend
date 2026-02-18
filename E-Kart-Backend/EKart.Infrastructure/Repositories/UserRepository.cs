using EKart.Core.DTOs;
using EKart.Core.IRepositories;
using EKart.Infrastructure.Password_Hasher;
using Microsoft.EntityFrameworkCore;

namespace EKart.Infrastructure.Repositories;

public class UserRepository(AppDbContext.AppDbContext _context) : IUserRepository
{
    public async Task<string> RegisterUser(LoginDto dto)
    {
        if(string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
        {
             return ("Email and password cannot be empty.");
        }

        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        if (existingUser != null)
        {
            return ("Email is already registered.");
        }

        var user = new Core.Entities.User
        {
            Email = dto.Email,
            PasswordHash = PasswordHasher.HashPassword(dto.Password)
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user.Id.ToString();
    }
}
