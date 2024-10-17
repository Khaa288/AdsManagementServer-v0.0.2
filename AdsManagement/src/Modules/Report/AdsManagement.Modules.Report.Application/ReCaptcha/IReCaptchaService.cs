namespace AdsManagement.Modules.Report.Application.ReCaptcha;

public interface IReCaptchaService
{
    Task<bool> VerifyReCaptcha(string responseToken);
}