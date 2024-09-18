using AdsManagement.BuildingBlocks.Application;
using AdsManagement.Modules.Auth.Application.Configuration.Commands;
using AdsManagement.Modules.Auth.Application.Contracts;
using FluentValidation;

namespace AdsManagement.Modules.Auth.Infrastructure.Configuration.Processing;

// With Result Command
internal class ValidationCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult>
    where T : ICommand<TResult>
{
    private readonly IList<IValidator<T>> _validators;
    private readonly ICommandHandler<T, TResult> _decorated;

    public ValidationCommandHandlerWithResultDecorator(
        IList<IValidator<T>> validators,
        ICommandHandler<T, TResult> decorated)
    {
        this._validators = validators;
        _decorated = decorated;
    }

    public Task<TResult> Handle(T command, CancellationToken cancellationToken)
    {
        var errors = _validators
            .Select(v => v.Validate(command))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();

        if (errors.Any())
        {
            throw new InvalidCommandException(errors.Select(x => x.ErrorMessage).ToList());
        }

        return _decorated.Handle(command, cancellationToken);
    }
}