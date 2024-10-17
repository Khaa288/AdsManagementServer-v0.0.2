using AdsManagement.Modules.Report.Application.ReCaptcha;

using System.Net.Http.Json;

namespace AdsManagement.Modules.Report.Infrastructure.ReCaptcha;

public class ReCaptchaService : IReCaptchaService
{
    private readonly HttpClient _httpClient;
    private readonly ReCaptchaConfiguration _configuration;

    public ReCaptchaService(HttpClient httpClient, ReCaptchaConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<bool> VerifyReCaptcha(string responseToken)
    {
        if (string.IsNullOrEmpty(responseToken))
        {
            return false;
        }

        var content = new FormUrlEncodedContent(new Dictionary<string, string>()
        {
            { "secret", _configuration.ReCaptchaSecretKey },
            { "response", responseToken }
        });
        var response = await _httpClient.PostAsync(_configuration.ReCaptChaVerifySite, content);
        var result = await response.Content.ReadFromJsonAsync<ReCaptchaResponse>();

        if (!response.IsSuccessStatusCode)
        {
            var exceptions = result.ErrorCodes;
            // Do some logging code here
        }

        return result.Success;
    }
}