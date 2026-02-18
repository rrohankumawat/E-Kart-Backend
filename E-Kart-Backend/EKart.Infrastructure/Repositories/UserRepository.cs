using EKart.Core.DTOs;
using EKart.Core.Entities;
using EKart.Core.Generics;
using EKart.Core.IRepositories;
using EKart.Core.JwtConfig;
using EKart.Infrastructure.Password_Hasher;
using Microsoft.EntityFrameworkCore;

namespace EKart.Infrastructure.Repositories;

public class UserRepository(AppDbContext.AppDbContext _context, IJwtTokenGenerator jwtTokenGenerator) : IUserRepository
{
    public async Task<Tuple<int, string>> RegisterUser(LoginDto dto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
            {
                return new Tuple<int, string>(1, "Email and password cannot be empty.");
            }

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (existingUser != null)
            {
                return new Tuple<int, string>(2, "Email is already registered.");
            }

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = PasswordHasher.HashPassword(dto.Password)
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new Tuple<int, string>(3, "User Created Successfully!");
        }
        catch (Exception ex)
        {
            return new Tuple<int, string>(0, "Something went wrong");
        }
        
    }


    public async Task<Tuple<int, string>> LoginUser(LoginDto dto)
    {
        try
        {
            if(string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
            {
                return new Tuple<int, string>(1,"Email and password cannot be empty.");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || !PasswordHasher.VerifyPassword(user.PasswordHash, dto.Password))
            {
                return new Tuple<int, string>(1, "Invalid email or password.");
            }

            string token = jwtTokenGenerator.GenerateToken(user.Id, user.Email);

            return new Tuple<int, string>(2, token);
        }
        catch (Exception ex)
        {
            return new Tuple<int, string>(0, "Something went wrong");
        }

    }
}
