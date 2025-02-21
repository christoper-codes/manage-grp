using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using System.IdentityModel.Tokens.Jwt;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface IJwtTokenRepository
    {
        JwtSecurityToken CreateJwtToken(JwtSecurityTokenDto jwtTokenDto);

        String CreateStringRefreshToken();

        TokenValidationResultDto GetPrincipalFromExpiredToken(TokenValidationParametersDto TokenValidationParametersDto, string accessToken);

        Task<RefreshToken?> GetRefreshTokenByUserIdAsync(string userId);

        Task<RefreshToken?> CreateRefreshToken(RefreshToken refreshToken);

        Task<bool?> UpdatedRefresToken(RefreshToken refreshToken);
    }
}