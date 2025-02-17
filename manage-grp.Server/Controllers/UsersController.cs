using FluentValidation;
using FluentValidation.Results;
using manage_grp.Server.DTOs;
using manage_grp.Server.Helpers;
using manage_grp.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace repro_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly JwtTokenService _jwtTokenService;
        private readonly IValidator<UserDto> _validator;
        private readonly IValidator<UserLoginDto> _loginValidator;
        private readonly IValidator<RefreshTokenDto> _refreshTokenValidator;

        public UsersController(UserService userService, JwtTokenService jwtTokenService, IValidator<UserDto> validator, IValidator<UserLoginDto> loginValidator, IValidator<RefreshTokenDto> refreshTokenValidator)
        {
            _userService = userService;
            _jwtTokenService = jwtTokenService;
            _validator = validator;
            _loginValidator = loginValidator;
            _refreshTokenValidator = refreshTokenValidator;
        }

        // POST: api/Users/Register
        [HttpPost("Register")]
        public async Task<IActionResult> CreateAsync([FromBody] UserDto userDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(userDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }
                
                var user = await _userService.GetByEmailAsync(userDto.Email);

                if (user != null)
                {
                    validationResult.Errors.Add(new ValidationFailure("Email", "The email is already registered."));

                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                var addedUser = await _userService.CreateAsync(userDto);

                if (addedUser.Errors != null)
                {
                    addedUser.Errors.ToList().ForEach(e => validationResult.Errors.Add(new ValidationFailure(e.Code, e.Description)));

                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Usuario registrado con exitoso", addedUser?.User);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en PostUser: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/Users/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto userLoginDto)
        {
            try
            {
                ValidationResult validationResult = await _loginValidator.ValidateAsync(userLoginDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos" ,validationResult.Errors,400);
                }

                var login = await _userService.LoginAsync(userLoginDto);

                if (login.Succeeded)
                {
                    var user = await _userService.GetForLoginAsync(userLoginDto);

                    return ApiResponse.SendSuccess("Usuario con inicio de sesion exitoso", new
                    {
                        user = user,
                        jwtTokens = await _jwtTokenService.CreateJwtToken(user, new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                        }),
                    });
                }
                else
                {
                    return ApiResponse.SendError("Usuario con inicio de sesion fallido", false,401);
                }
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en LoginAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/Users/token/refresh
        [HttpPost("token/refresh")]
        public async Task<IActionResult> RegenerateRefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            try
            {
                ValidationResult validationResult = await _refreshTokenValidator.ValidateAsync(refreshTokenDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Toquen refrescado exitosamente", new
                {
                    jwtTokens = await _jwtTokenService.RegenerateRefreshToken(refreshTokenDto),
                });
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en RegenerateRefreshToken: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}