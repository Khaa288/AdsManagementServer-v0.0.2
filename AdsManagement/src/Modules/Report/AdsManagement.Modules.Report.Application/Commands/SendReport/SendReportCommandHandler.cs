using AdsManagement.Modules.Report.Application.Configuration.Commands;

namespace AdsManagement.Modules.Report.Application.Commands;

public class SendReportCommandHandler : ICommandHandler<SendReportCommand, SendReportResponse>
{
    public async Task<SendReportResponse> Handle(SendReportCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}