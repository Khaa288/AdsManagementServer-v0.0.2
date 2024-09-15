using AdsManagement.API.Common.Enum;
using AdsManagement.Modules.Auth.Application.Configuration.Commands;
using AdsManagement.Modules.Auth.Application.Tokens;
using AdsManagement.Modules.Auth.Domain;
using AdsManagement.Modules.Auth.Domain.Entities;

namespace Application.Commands.Login;

public class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{
    private readonly ITokenService _tokenService;
    private readonly IAuthRepository _authRepository;
    
    public LoginCommandHandler(ITokenService tokenService, IAuthRepository authRepository)
    {
        _tokenService = tokenService;
        _authRepository = authRepository;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var officer = await _authRepository.GetOfficerWithRolesPrivilegesByIdAsync(request.Id);

        var tokenType = TokenTypeNames.Access;
        
        var token = _tokenService.CreateToken(officer!, tokenType);

        return token;
    }
}