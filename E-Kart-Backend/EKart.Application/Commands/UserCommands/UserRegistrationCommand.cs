using EKart.Core.DTOs;
using EKart.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EKart.Application.Commands.UserCommands;

public record UserRegistrationCommand(LoginDto dto) : IRequest<string>;

public class UserRegistrationCommandHandler(IUserRepository _userRepository) : IRequestHandler<UserRegistrationCommand, string>
{    
    public async Task<string> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.RegisterUser(request.dto);
        return result;
    }
}
