using AdsManagement.Modules.Auth.Application.Configuration.Queries;
using AdsManagement.Modules.Auth.Application.Contracts;
using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;

namespace AdsManagement.Modules.Auth.Application.Queries;

internal class GetOfficerByEmailQueryHandler : IQueryHandler<GetOfficerByEmailQuery, Officer>
{
    private readonly IOfficerRepository _officerRepository;

    public GetOfficerByEmailQueryHandler(
        IOfficerRepository officerRepository)
    {
        _officerRepository = officerRepository;
    }
    
    public async Task<Officer> Handle(GetOfficerByEmailQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var officer = await _officerRepository.GetOfficerByEmailAsync(request.Email);
            
            if (officer == null)
            {
                throw new Exception($"Officer with email '{request.Email}' not found.");
            }

            return officer;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while getting officer by email: {ex.Message}");
        }
    }
}