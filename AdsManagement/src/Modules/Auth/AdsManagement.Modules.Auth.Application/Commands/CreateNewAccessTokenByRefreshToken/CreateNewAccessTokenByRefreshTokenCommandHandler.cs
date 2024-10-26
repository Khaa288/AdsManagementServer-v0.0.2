using AdsManagement.BuildingBlocks.Application.Constraints.Constants;
using AdsManagement.Modules.Auth.Application.Configuration.Commands;
using AdsManagement.Modules.Auth.Application.Tokens;
using AdsManagement.Modules.Auth.Domain.Repositories;

namespace AdsManagement.Modules.Auth.Application.Commands;

internal class CreateNewAccessTokenByRefreshTokenCommandHandler : ICommandHandler<CreateNewAccessTokenByRefreshTokenCommand, CreateNewAccessTokenByRefreshTokenResponse>
{
    private readonly ITokenService _tokenService;
    private readonly IOfficerRepository _officerRepository;

    public CreateNewAccessTokenByRefreshTokenCommandHandler(
        ITokenService tokenService,
        IOfficerRepository officerRepository)
    {
        _tokenService = tokenService;
        _officerRepository = officerRepository;
    }

    public async Task<CreateNewAccessTokenByRefreshTokenResponse> Handle(CreateNewAccessTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var officerId = _tokenService.DecodeToken(request.Token);
        var officer = await _officerRepository.GetOfficerByIdAsync(officerId);
        var accessToken = _tokenService.CreateAccessToken(officer!, TokenTypeNames.Access);
    
        return new CreateNewAccessTokenByRefreshTokenResponse(accessToken);
    }
}