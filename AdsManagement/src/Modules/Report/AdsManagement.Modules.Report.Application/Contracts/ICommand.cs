using MediatR;

namespace AdsManagement.Modules.Report.Application.Contracts;

public interface ICommand<out TResult> : IRequest<TResult>
{
}

public interface ICommand : IRequest
{
}