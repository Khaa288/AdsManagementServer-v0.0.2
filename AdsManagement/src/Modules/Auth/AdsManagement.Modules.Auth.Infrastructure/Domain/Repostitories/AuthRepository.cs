using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;
using AdsManagement.Modules.Auth.Infrastructure.Database;

using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

internal class AuthRepository : IAuthRepository
{
    private readonly AuthContext _authContext;

    public AuthRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }
    
    public async Task<Otp> GenerateOtpForPasswordResetAsync(Officer officer)
    {
        var otp = new Otp
        {
            OtpId = new Guid(),
            OfficerId = officer.OfficerId,
            Code = new Random().Next(100000, 999999).ToString(),
            ExpiryDate = DateTime.UtcNow.AddMinutes(5)
        };

        await _authContext.Otps.AddAsync(otp);
        return otp;
    }

    public async Task<bool> ValidateOtpAsync(Guid officerId, string otpCode)
    {
        // check officer Id and opt Type 
        var otp = await _authContext.Otps.FirstOrDefaultAsync(o => o.OfficerId == officerId);

        return otp != null && otp.ExpiryDate >= DateTime.UtcNow;
    }
}