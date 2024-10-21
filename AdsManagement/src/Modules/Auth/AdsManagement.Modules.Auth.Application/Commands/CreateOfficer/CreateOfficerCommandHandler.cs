using AdsManagement.BuildingBlocks.Application.Constraints.Constants;
using AdsManagement.Modules.Auth.Application.Configuration.Commands;
using AdsManagement.Modules.Auth.Application.Cryptos;
using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;

namespace AdsManagement.Modules.Auth.Application.Commands;

internal class CreateOfficerCommandHandler : ICommandHandler<CreateOfficerCommand>
{
    private readonly IOfficerRepository _officerRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPrivilegeRepository _privilegeRepository;
    private readonly IWardOfficerRepository _wardOfficerRepository;
    private readonly IDistrictOfficerRepository _districtOfficerRepository;
    private readonly IDeptOfficerRepository _deptOfficerRepository;
    private readonly ICryptoService _cryptoService;

    public CreateOfficerCommandHandler(
        IOfficerRepository officerRepository,
        IRoleRepository roleRepository,
        IPrivilegeRepository privilegeRepository,
        IWardOfficerRepository wardOfficerRepository,
        IDistrictOfficerRepository districtOfficerRepository,
        IDeptOfficerRepository deptOfficerRepository,
        ICryptoService cryptoService)
    {
        _officerRepository = officerRepository;
        _roleRepository = roleRepository;
        _privilegeRepository = privilegeRepository;
        _wardOfficerRepository = wardOfficerRepository;
        _districtOfficerRepository = districtOfficerRepository;
        _deptOfficerRepository = deptOfficerRepository;
        _cryptoService = cryptoService;
    }
    
    public async Task Handle(CreateOfficerCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetRoleByIdAsync(request.RoleId);

        var privileges = new List<Privilege>();
        foreach (var privilege in request.Privileges)
        {
            if (!role.Privileges.Any(p => p.PrivilegeId == privilege))
            {
                privileges.Add(await _privilegeRepository.GetPrivilegeByIdAsync(privilege));
            }
        }
        
        switch (role.RoleName.ToUpper())
        {
            case RoleNames.WardOfficer:
                await _wardOfficerRepository.CreateWardOfficerAsync(new WardOfficer
                {
                    OfficerId = Guid.NewGuid(),
                    Email = request.Email,
                    FullName = request.FullName,
                    DoB = request.DoB,
                    PhoneNumber = request.PhoneNumber,
                    PasswordHash = _cryptoService.HashPasswordWithSha256(request.Password),
                    RoleId = request.RoleId,
                    Role = role,
                    Privileges = privileges,
                    WardId = request.WardId
                });
                break;
            
            case RoleNames.DistrictOfficer:
                await _districtOfficerRepository.CreateDistrictOfficerAsync(new DistrictOfficer
                {
                    OfficerId = Guid.NewGuid(),
                    Email = request.Email,
                    FullName = request.FullName,
                    DoB = request.DoB,
                    PhoneNumber = request.PhoneNumber,
                    PasswordHash = _cryptoService.HashPasswordWithSha256(request.Password),
                    RoleId = request.RoleId,
                    Role = role,
                    Privileges = privileges,
                    DistrictId = request.DistrictId
                });
                break;
        }
    }
}