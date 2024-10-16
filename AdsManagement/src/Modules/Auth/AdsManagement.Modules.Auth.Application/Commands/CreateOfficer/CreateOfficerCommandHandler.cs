using AdsManagement.BuildingBlocks.Application.EventBus;
using AdsManagement.Modules.Auth.Application.Configuration.Commands;
using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;
using MediatR;

namespace AdsManagement.Modules.Auth.Application.Commands;

internal class CreateOfficerCommandHandler : ICommandHandler<CreateOfficerCommand>
{
    private readonly IOfficerRepository _officerRepository;
    private readonly IEventBus _eventBus;

    public CreateOfficerCommandHandler(IOfficerRepository officerRepository, IEventBus eventBus)
    {
        _officerRepository = officerRepository;
        _eventBus = eventBus;
    }
    
    public async Task Handle(CreateOfficerCommand request, CancellationToken cancellationToken)
    {
        // var officer = await _officerRepository.CreateOrUpdateOfficerAsync(new Officer()
        // {
        //     OfficerId = Guid.NewGuid(),
        //     FullName = request.Email,
        //     Email = request.Email,
        //     PasswordHash = request.Password,
        // });
        return;
    }
}