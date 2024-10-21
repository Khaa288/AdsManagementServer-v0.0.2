using AdsManagement.Modules.Auth.Application.Configuration.Commands;
using AdsManagement.Modules.Auth.Application.Tokens;
using AdsManagement.Modules.Auth.Domain.Repositories;

namespace AdsManagement.Modules.Auth.Application.Commands;

internal class LogoutCommandHandler : ICommandHandler<LogoutCommand>
{
    private readonly ITokenService _tokenService;
    private readonly ITokenRepository _tokenRepository;
    
    
    public LogoutCommandHandler(
        ITokenService tokenService,
        ITokenRepository tokenRepository)
    {
        _tokenService = tokenService;
        _tokenRepository = tokenRepository;
    }

    public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var officerId = _tokenService.DecodeToken(request.AccessToken);

        var refreshToken = await _tokenRepository.GetRefreshTokenByOfficerIdAsync(officerId);
        await _tokenRepository.RemoveRefreshTokenAsync(refreshToken);
    }
}
