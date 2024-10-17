namespace AdsManagement.Modules.Report.Infrastructure.ReCaptcha;

public class ReCaptchaConfiguration
{
    public string ReCaptchaSecretKey { get; }
    public string ReCaptChaVerifySite { get; }

    public ReCaptchaConfiguration(string reCaptchaSecretKey, string reCaptChaVerifySite)
    {
        ReCaptchaSecretKey = reCaptchaSecretKey;
        ReCaptChaVerifySite = reCaptChaVerifySite;
    }
}