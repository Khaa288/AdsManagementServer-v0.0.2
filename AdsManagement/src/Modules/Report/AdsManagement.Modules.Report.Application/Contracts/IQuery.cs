﻿using MediatR;

namespace AdsManagement.Modules.Report.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
    
}