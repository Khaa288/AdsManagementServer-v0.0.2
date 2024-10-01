using AdsManagement.Modules.Auth.Application.Contracts;

namespace Application;

public class TestQuery : QueryBase<string>
{
    public string Name { get; }
    public TestQuery(string name)
    {
        Name = name;
    }
}