using AdsManagement.Modules.Report.Application.Contracts;
using AdsManagement.Modules.Report.Infrastructure.Configuration;
using AdsManagement.Modules.Report.Infrastructure.Configuration.Processing;

using Autofac;
using MediatR;

namespace AdsManagement.Modules.Report.Infrastructure;

public class ReportModule : IReportModule
{
    public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
    {
        return await CommandsExecutor.Execute(command);
    }

    public async Task ExecuteCommandAsync(ICommand command)
    {
        await CommandsExecutor.Execute(command);
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        using (var scope = CompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();

            return await mediator.Send(query);
        }
    }

    public async Task ExecuteCommandWithNotificationAsync(ICommandWithNotification notification)
    {
        using (var scope = CompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();

            await mediator.Publish(notification);
        }
    }
}