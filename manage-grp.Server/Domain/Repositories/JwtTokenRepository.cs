

using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace manage_grp.Server.Domain.Interfaces
{
    public class JwtTokenRepository : IJwtTokenRepository
    {
        private readonly AppDbContext _context;
        public JwtTokenRepository(AppDbContext context)
        {
            _context = context;
        }        

        public JwtSecurityToken CreateJwtToken(JwtSecurityTokenDto jwtTokenDto)
        {
            return new JwtSecurityToken(
                issuer: jwtTokenDto.Issuer,
                audience: jwtTokenDto.Audience,
                expires: jwtTokenDto.Expiration,
                claims: jwtTokenDto.Claims,
                signingCredentials: jwtTokenDto.SigningCredentials
            );
        }

        public string CreateStringRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public TokenValidationResultDto GetPrincipalFromExpiredToken(TokenValidationParametersDto tokenValidationParametersDto, string accessToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = tokenValidationParametersDto.ValidateIssuer,
                ValidateAudience = tokenValidationParametersDto.ValidateAudience,
                ValidAudience = tokenValidationParametersDto.ValidAudience,
                ValidIssuer = tokenValidationParametersDto.ValidIssuer,
                ValidateLifetime = tokenValidationParametersDto.ValidateLifetime,
                ClockSkew = tokenValidationParametersDto.ClockSkew,
                IssuerSigningKey = tokenValidationParametersDto.IssuerSigningKey
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return new TokenValidationResultDto { 
                    ClaimsPrincipal = null, 
                    IsValid = false 
                };
            }

            return new TokenValidationResultDto
            {
                ClaimsPrincipal = principal,
                IsValid = true
            };
        }

        public async Task<RefreshToken?> GetRefreshTokenByUserIdAsync(string userId)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<RefreshToken?> CreateRefreshToken(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Add(refreshToken);

            await _context.SaveChangesAsync();

            return refreshToken;
        }

        public async Task<bool?> UpdatedRefresToken(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Update(refreshToken);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}