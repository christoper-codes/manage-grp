
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserCreationResult> CreateAsync(User user, UserDto userDto);

        Task<SignInResult?> LoginAsync(User user, UserLoginDto userLoginDto);

        Task<User?> GetByEmailAsync(string email);

        Task<User?> GetByUserNameAsync(string userName);

        Task<User?> GetByIdAsync(string userId);
    }
}