using AdsManagement.Modules.Auth.Application.Configuration.Queries;

namespace Application;

public class TestQueryHandler : IQueryHandler<TestQuery, string>
{
    public async Task<string> Handle(TestQuery request, CancellationToken cancellationToken)
    {
        return request.Name;
    }
}