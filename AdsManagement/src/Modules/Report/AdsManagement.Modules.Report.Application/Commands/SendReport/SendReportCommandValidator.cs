using AdsManagement.Modules.Report.Application.ReCaptcha;
using AdsManagement.Modules.Report.Domain.BusinessRules;
using AdsManagement.Modules.Report.Domain.Repositories;
using Application.Constraints.Constants;

using FluentValidation;

namespace AdsManagement.Modules.Report.Application.Commands;

public class SendReportCommandValidator : AbstractValidator<SendReportCommand>
{
    public SendReportCommandValidator(IReportObjectRepository reportObjectRepository, IReCaptchaService reCaptchaService)
    {
        RuleFor(x => x.ReporterEmail)
            .EmailAddress()
            .WithMessage("Should be email address!");
        
        RuleFor(x => x.ReportObjectId)
            .MustAsync(async (request, reportObjectId, cancellation) =>
            {
                var reportObject =  await reportObjectRepository
                    .GetReportObjectAsync(request.ReportObjectId, request.ReportObjectType);

                return reportObject is not null;
            })
            .WithMessage("Report object does not exists!");
        
        RuleFor(x => x.ReportObjectType)
            .Must(type => new List<string>()
            {
                ReportObjectType.POINT,
                ReportObjectType.BOARD
            }.Contains(type))
            .WithMessage("Invalid report object type!");
        
        RuleFor(x => x.ReportType)
            .Must(type => new List<string>()
            {
                ReportType.REPORT_VIOLATIONS,
                ReportType.ANSWER_INQUIRIES,
                ReportType.REGISTER_CONTENT,
                ReportType.CONTRIBUTE_FEEDBACK
            }.Contains(type))
            .WithMessage("Invalid report type!");
        
        RuleFor(x => x.Images)
            .Must(images => ReportBusinessRule.EachReportHasTwoImages(images.Count))
            .WithMessage("Maximum images of a report is 2");

        RuleFor(x => x.ReCaptchaResponseToken)
            .MustAsync(async (responseToken, cancellationToken) => await reCaptchaService.VerifyReCaptcha(responseToken))
            .WithMessage("Invalid reCAPTCHA credential!");
    }
}