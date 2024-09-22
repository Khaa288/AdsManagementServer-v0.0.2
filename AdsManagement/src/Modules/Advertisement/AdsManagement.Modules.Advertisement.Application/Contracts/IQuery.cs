using MediatR;

namespace AdsManagement.Modules.Advertisement.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
    
}