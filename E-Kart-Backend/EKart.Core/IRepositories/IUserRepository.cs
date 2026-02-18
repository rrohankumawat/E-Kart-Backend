using EKart.Core.DTOs;
using EKart.Core.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EKart.Core.IRepositories;

public interface IUserRepository
{
    Task<Tuple<int, string>> RegisterUser(LoginDto dto);
    Task<Tuple<int, string>> LoginUser(LoginDto dto);
}
