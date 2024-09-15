using System.Data;

namespace AdsManagement.BuildingBlocks.Application.Data;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();

    IDbConnection CreateNewConnection();

    string GetConnectionString();
}