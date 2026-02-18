using EKart.Core.DTOs;
using EKart.Core.IRepositories;
using MediatR;

namespace EKart.Application.Commands.UserCommands;

public record UserRegistrationCommand(LoginDto dto) : IRequest<Tuple<int, string>>;
public record UserLoginCommand(LoginDto dto) : IRequest<Tuple<int, string>>;

public class UserRegistrationCommandHandler(IUserRepository _userRepository) : IRequestHandler<UserRegistrationCommand, Tuple<int, string>>
{    
    public async Task<Tuple<int, string>> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.RegisterUser(request.dto);
        return result;
    }
}

public class UserLoginCommandHandler(IUserRepository _userRepository) : IRequestHandler<UserLoginCommand, Tuple<int, string>>
{
    public async Task<Tuple<int, string>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.LoginUser(request.dto);
        return result;
    }
}