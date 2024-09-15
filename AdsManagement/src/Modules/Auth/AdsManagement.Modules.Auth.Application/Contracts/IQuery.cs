using MediatR;

namespace AdsManagement.Modules.Auth.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
    
}