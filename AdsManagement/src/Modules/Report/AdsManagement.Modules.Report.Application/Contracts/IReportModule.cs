namespace AdsManagement.Modules.Report.Application.Contracts;

public interface  IReportModule
{
    Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

    Task ExecuteCommandAsync(ICommand command);

    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    
    Task ExecuteCommandWithNotificationAsync(ICommandWithNotification notification);
}