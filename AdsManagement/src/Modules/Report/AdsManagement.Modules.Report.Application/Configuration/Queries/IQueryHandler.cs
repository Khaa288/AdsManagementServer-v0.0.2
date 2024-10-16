using AdsManagement.Modules.Report.Application.Contracts;

using MediatR;

namespace AdsManagement.Modules.Report.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}