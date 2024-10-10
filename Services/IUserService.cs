using System.Collections.Generic;
using System.Threading.Tasks;
using UserAPI.DTOs;
using UserAPI.Models.DTO;

namespace UserAPI.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> AddUserAsync(UserDto userDto);
        Task<UserDto> UpdateUserAsync(UserDto userDto);
        Task<bool> DeleteUserAsync(int userId);
        Task<UserDto> LoginAsync(LoginDto loginDto);
    }
}
