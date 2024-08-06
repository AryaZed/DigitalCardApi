using CleanArc.Application.Models.Jwt;
using CleanArc.Domain.Entities.User;
using System.Security.Claims;

namespace CleanArc.Application.Contracts
{
    public interface IJwtService
    {
        Task<AccessToken> GenerateAsync(User user);
        Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
        Task<AccessToken> GenerateByPhoneNumberAsync(string phoneNumber);
        Task<AccessToken> RefreshToken(Guid refreshTokenId);
    }
}