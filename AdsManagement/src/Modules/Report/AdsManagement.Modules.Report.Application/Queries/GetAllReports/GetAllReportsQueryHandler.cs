using AdsManagement.BuildingBlocks.Application.Data;
using AdsManagement.Modules.Report.Application.Configuration.Queries;

using Dapper;

namespace AdsManagement.Modules.Report.Application.Queries;

public class GetAllReportsQueryHandler : IQueryHandler<GetAllReportsQuery, IEnumerable<GetAllReportsResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAllReportsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<IEnumerable<GetAllReportsResponse>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        const string query = $"""
                              SELECT 
                                [RP].[ReportId], [RP].[ReportType], [RP].[Content], [RP].[Solution], [RP].[Status], [RP].[CreatedTime],[RP].[UpdatedTime], 
                                [RPT].[Name], [RPT].[Email], [RPT].[PhoneNumber], 
                                [RPO].[ObjectType], [RPO].[Address], [RPO].[DistrictName], [RPO].[WardName]
                              FROM Report [RP] 
                              	LEFT JOIN Reporter [RPT] ON [RP].[ReporterId] = [RPT].[ReporterId]
                              	LEFT JOIN ReportObject [RPO] ON [RP].ReportObjectId = [RPO].[SurrogateKey]
                              Where 
                              	[RPT].[Name] LIKE @Name AND
                              	[RPT].[Email] LIKE @Email AND
                              	[RPT].[PhoneNumber] LIKE @PhoneNumber
                              ORDER BY [RP].[CreatedTime] DESC
                              """;
        
        var queryParams = new
        {
            Name = $"%{request.Name}%",
            Email = $"%{request.Email}%",
            PhoneNumber = $"%{request.PhoneNumber}%",
        };
        
        return await connection.QueryAsync<GetAllReportsResponse>(query, queryParams);
    }
}