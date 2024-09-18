using AdsManagement.BuildingBlocks.Infrastructure;
using AdsManagement.Modules.Auth.Application.Configuration.Commands;
using AdsManagement.Modules.Auth.Application.Contracts;

namespace AdsManagement.Modules.Auth.Infrastructure.Configuration.Processing;

// Without Result Command
internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T>
    where T : ICommand
{
    private readonly ICommandHandler<T> _command;

    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerDecorator(
        ICommandHandler<T> command,
        IUnitOfWork unitOfWork)
    {
        _command = command;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(T command, CancellationToken cancellationToken)
    {
        await this._command.Handle(command, cancellationToken);
        await this._unitOfWork.CommitAsync(cancellationToken);
    }
}