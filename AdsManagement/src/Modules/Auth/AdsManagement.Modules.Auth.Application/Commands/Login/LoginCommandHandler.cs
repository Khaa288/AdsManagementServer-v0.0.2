using AdsManagement.BuildingBlocks.Application.Constraints.Constants;
using AdsManagement.BuildingBlocks.Application.Constraints.Enums;
using AdsManagement.Modules.Auth.Application.Configuration.Commands;
using AdsManagement.Modules.Auth.Application.Tokens;
using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;

namespace AdsManagement.Modules.Auth.Application.Commands;

internal class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
{
    private readonly ITokenService _tokenService;
    private readonly ITokenRepository _tokenRepository;
    private readonly IOfficerRepository _officerRepository;
    
    public LoginCommandHandler(
        ITokenService tokenService,
        ITokenRepository tokenRepository,
        IOfficerRepository officerRepository)
    {
        _tokenService = tokenService;
        _tokenRepository = tokenRepository;
        _officerRepository = officerRepository;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var officer = await _officerRepository.GetOfficerWithRolesPrivilegesByEmailAsync(request.Email);

        var access = _tokenService.CreateAccessToken(officer!, TokenTypeNames.Access);

        if (await _tokenRepository.IsRefreshTokenExistsByOfficerIdAsync(officer!.OfficerId))
        {
            var previousRefresh = await _tokenRepository.GetRefreshTokenByOfficerIdAsync(officer!.OfficerId);
            return new LoginResponse(access, previousRefresh!.Secret);
        }
        else
        {
            DateTime createdAt = DateTime.UtcNow; 
            var refresh = _tokenService.CreateRefreshToken(officer!, createdAt, TokenTypeNames.Refresh);
                
            await  _tokenRepository.AddRefreshTokenAsync(new RefreshToken
            {
                TokenId = Guid.NewGuid(),
                Secret = refresh,
                IsUsed = false,
                ExpiryDate = createdAt.AddMinutes((int)TokenLifeTimeDurations.RefreshLifeTimeDuration),
                OfficerId = officer.OfficerId
            });
            return new LoginResponse(access, refresh);
        }
    }
}
