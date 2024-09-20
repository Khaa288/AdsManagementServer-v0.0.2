using AdsManagement.Modules.Auth.Application.Contracts;
using AdsManagement.Modules.Auth.Infrastructure.Configuration;
using AdsManagement.Modules.Auth.Infrastructure.Configuration.Processing;

using Autofac;
using MediatR;

namespace AdsManagement.Modules.Auth.Infrastructure;

public class AuthModule : IAuthModule
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
}