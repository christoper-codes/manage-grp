using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace manage_grp.Server.Domain.Services
{
    public class JwtTokenService
    {
        private readonly IJwtTokenRepository _jwtTokenRepository;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public JwtTokenService(IJwtTokenRepository jwtTokenRepository, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _jwtTokenRepository = jwtTokenRepository;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        public async Task<object?>  CreateJwtToken(User user, List<Claim> claims)
        {
            try
            {
                var jwtTokenDto = new JwtSecurityTokenDto
                {
                    Issuer = _configuration["JWT:Issuer"],
                    Audience = _configuration["JWT:Audience"],
                    Expiration = DateTime.Now.AddHours(3),
                    Claims = claims,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:IssuerSigningKey"])), SecurityAlgorithms.HmacSha256),
                };

                var token = _jwtTokenRepository.CreateJwtToken(jwtTokenDto);

                var refreshToken = await CreateRefreshToken(user);

                return new
                {
                    accessToken = new {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiresAt = token.ValidTo
                    },
                    refreshToken = new {
                        token = refreshToken.Token,
                        expiresAt = refreshToken.Expiration
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RefreshToken> CreateRefreshToken(User user)
        {
            try
            {
                var newToken = _jwtTokenRepository.CreateStringRefreshToken();
                var refreshToken = await GetRefreshTokenByUserIdAsync(user.Id);

                if (refreshToken == null)
                {
                    refreshToken = new RefreshToken
                    {
                        Token = newToken,
                        UserId = user.Id,
                        Expiration = DateTime.UtcNow.AddDays(2),
                        IsRevoked = false
                    };

                    await CreateRefreshToken(refreshToken);
                }
                else
                {
                    refreshToken.Token = newToken;
                    refreshToken.Expiration = DateTime.UtcNow.AddDays(2);

                    await UpdateRefreshTokenAsync(refreshToken);
                }

                return refreshToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TokenValidationResultDto> GetPrincipalFromExpiredToken(string accessToken)
        {
            try
            {
                bool validateIssuer;
                bool validateAudience;
                bool validateLifetime;

                var tokenValidationParametersDto = new TokenValidationParametersDto
                {
                    ValidateIssuer = bool.TryParse(_configuration["JWT:ValidateIssuer"], out validateIssuer),
                    ValidateAudience = bool.TryParse(_configuration["JWT:ValidateAudience"], out validateAudience),
                    ValidAudience = _configuration["JWT:Audience"],
                    ValidIssuer = _configuration["JWT:Issuer"],
                    ValidateLifetime = bool.TryParse(_configuration["JWT:ValidateLifetime"], out validateLifetime),
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:IssuerSigningKey"]))
                };


                return  _jwtTokenRepository.GetPrincipalFromExpiredToken(tokenValidationParametersDto, accessToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RefreshToken?> GetRefreshTokenByUserIdAsync(string id)
        {
            try
            {
                return await _jwtTokenRepository.GetRefreshTokenByUserIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RefreshToken?> CreateRefreshToken(RefreshToken refreshToken)
        {
            try
            {
                return await _jwtTokenRepository.CreateRefreshToken(refreshToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateRefreshTokenAsync(RefreshToken refreshToken)
        {
            try
            {
                return await _jwtTokenRepository.UpdatedRefresToken(refreshToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object?> RegenerateRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            try
            {
                var principal = await GetPrincipalFromExpiredToken(refreshTokenDto.AccessToken);

                if (!principal.IsValid)
                {
                    throw new ArgumentException("Invalid token: user ID not found.");
                }

                var userId = principal.ClaimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    throw new ArgumentException("Invalid token: user ID not found.");
                }

                var refreshToken = await GetRefreshTokenByUserIdAsync(userId);

                if (refreshToken == null || refreshToken.Token != refreshTokenDto.RefreshToken || refreshToken.Expiration <= DateTime.UtcNow)
                {
                    throw new UnauthorizedAccessException("Invalid refresh token. Please login again.");
                }

                var user = await _serviceProvider.GetRequiredService<UserService>().GetByIdAsync(userId);

                return await CreateJwtToken(user, new List<Claim>{
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
