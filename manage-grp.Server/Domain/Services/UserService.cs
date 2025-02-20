using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
namespace manage_grp.Server.Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserCreationResult?> CreateAsync(UserDto userDto)
        {
            try
            {
                return await _userRepository.CreateAsync(new User(), userDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SignInResult?> LoginAsync(UserLoginDto userLoginDto)
        {
            try
            {
                return await _userRepository.LoginAsync(await GetForLoginAsync(userLoginDto), userLoginDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            try
            {
                return await _userRepository.GetByEmailAsync(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User?> GetForLoginAsync(UserLoginDto userLoginDto)
        {
            try
            {
                if (userLoginDto.UserNameOrEmail == null)
                {
                    return null;
                }

                return userLoginDto.UserNameOrEmail.Contains("@")
                ? await _userRepository.GetByEmailAsync(userLoginDto.UserNameOrEmail)
                : await _userRepository.GetByUserNameAsync(userLoginDto.UserNameOrEmail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User?> GetByIdAsync(string userId)
        {
            try
            {
                return await _userRepository.GetByIdAsync(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
