using AdsManagement.BuildingBlocks.Application.Constraints.Constants;
using AdsManagement.Modules.Auth.Application.Configuration.Commands;
using AdsManagement.Modules.Auth.Application.Tokens;
using AdsManagement.Modules.Auth.Domain;

namespace AdsManagement.Modules.Auth.Application.Commands;

internal class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
{
    private readonly ITokenService _tokenService;
    private readonly IAuthRepository _authRepository;
    
    public LoginCommandHandler(ITokenService tokenService, IAuthRepository authRepository)
    {
        _tokenService = tokenService;
        _authRepository = authRepository;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var officer = await _authRepository.GetOfficerWithRolesPrivilegesByEmailAsync(request.Email);
        
        var tokenType = TokenTypeNames.Access;
        
        var token = _tokenService.CreateToken(officer!, tokenType);

        return new LoginResponse(token);
    }
}