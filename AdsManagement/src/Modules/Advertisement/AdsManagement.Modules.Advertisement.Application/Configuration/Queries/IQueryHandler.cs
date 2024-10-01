using AdsManagement.Modules.Advertisement.Application.Contracts;

using MediatR;

namespace AdsManagement.Modules.Advertisement.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}