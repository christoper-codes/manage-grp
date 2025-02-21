

using manage_grp.Server.Domain.Services;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace manage_grp.Server.Domain.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtTokenService _jwtTokenService;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<UserCreationResult?> CreateAsync(User user, UserDto userDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, user, userDto);

            var  result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                return new UserCreationResult
                {
                    User = user,
                    Errors = null
                };
            }

            return new UserCreationResult
            {
                User = null,
                Errors = result.Errors
            };
        }

        public async Task<SignInResult?> LoginAsync(User user, UserLoginDto userLoginDto)
        {
            return await _signInManager.PasswordSignInAsync(user.UserName, userLoginDto.Password!, userLoginDto.RememberMe, false);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<User?> GetByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }        
    }
}