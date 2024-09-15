using AdsManagement.Modules.Auth.Application.Contracts;
using MediatR;

namespace AdsManagement.Modules.Auth.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}