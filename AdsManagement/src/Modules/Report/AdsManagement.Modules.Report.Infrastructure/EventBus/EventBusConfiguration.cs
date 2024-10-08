namespace AdsManagement.Modules.Report.Infrastructure.EventBus;

public class EventBusConfiguration
{
    public string? HostName { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }

    public EventBusConfiguration(string? hostName, string? userName, string? password)
    {
        HostName = hostName;
        UserName = userName;
        Password = password;
    }
}