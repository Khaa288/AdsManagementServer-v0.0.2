using MediatR;

namespace AdsManagement.Modules.Advertisement.Application.Contracts;

public interface ICommand<out TResult> : IRequest<TResult>
{
}

public interface ICommand : IRequest
{
}