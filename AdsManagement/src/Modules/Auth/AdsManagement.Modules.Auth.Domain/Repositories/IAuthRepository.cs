using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface IAuthRepository
{
    Task<Otp> GenerateOtpForPasswordResetAsync(Officer officer);
    Task<bool> ValidateOtpAsync(Guid officerId, string otpCode);
    // Add more here
}