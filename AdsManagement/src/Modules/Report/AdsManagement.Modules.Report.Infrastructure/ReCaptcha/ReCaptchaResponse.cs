namespace AdsManagement.Modules.Report.Infrastructure.ReCaptcha;

public class ReCaptchaResponse
{
    public bool Success { get; set; }
    public string[] ErrorCodes { get; set; }
}