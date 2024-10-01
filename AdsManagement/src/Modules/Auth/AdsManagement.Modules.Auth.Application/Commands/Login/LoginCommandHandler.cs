using AdsManagement.BuildingBlocks.Application.Constraints.Constants;
using AdsManagement.BuildingBlocks.Application.EventBus;
using AdsManagement.Modules.Auth.Application.Configuration.Commands;
using AdsManagement.Modules.Auth.Application.Tokens;
using AdsManagement.Modules.Auth.Domain.Repositories;

namespace AdsManagement.Modules.Auth.Application.Commands;

internal class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
{
    private readonly ITokenService _tokenService;
    private readonly IAuthRepository _authRepository;
    private readonly IEventBus _eventBus;
    
    public LoginCommandHandler(ITokenService tokenService, IAuthRepository authRepository, IEventBus eventBus)
    {
        _tokenService = tokenService;
        _authRepository = authRepository;
        _eventBus = eventBus;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var officer = await _authRepository.GetOfficerWithRolesPrivilegesByEmailAsync(request.Email);
        
        var tokenType = TokenTypeNames.Access;
        
        var token = _tokenService.CreateToken(officer!, tokenType);
         
        await _eventBus.Publish(new LoginResponse(token), cancellationToken);

        return new LoginResponse(token);
    }
}