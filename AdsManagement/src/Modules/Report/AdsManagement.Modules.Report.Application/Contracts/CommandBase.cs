namespace AdsManagement.Modules.Report.Application.Contracts;

public abstract class CommandBase : ICommand
{
}

public abstract class CommandBase<TResult> : ICommand<TResult>
{
}