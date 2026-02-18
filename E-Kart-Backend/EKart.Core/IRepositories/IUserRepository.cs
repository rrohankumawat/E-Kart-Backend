using EKart.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EKart.Core.IRepositories;

public interface IUserRepository
{
    Task<string> RegisterUser(LoginDto dto);

}
