using AdsManagement.Modules.Report.Domain.BusinessRules;
using FluentValidation;

namespace AdsManagement.Modules.Report.Application.Commands;

public class SendReportCommandValidator : AbstractValidator<SendReportCommand>
{
    public SendReportCommandValidator()
    {
        RuleFor(x => x.Images)
            .Must(images => ReportBusinessRule.EachReportHasTwoImages(images.Count));
    }
}