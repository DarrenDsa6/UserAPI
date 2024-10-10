using System.Collections.Generic;
using System.Threading.Tasks;
using UserAPI.Models.DTO;
using UserAPI.Models.Domain;
using UserAPI.Repositories;
using UserAPI.DTOs;

namespace UserAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user == null ? null : MapToDto(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                userDtos.Add(MapToDto(user));
            }
            return userDtos;
        }

        public async Task<UserDto> AddUserAsync(UserDto userDto)
        {
            var user = MapToDomain(userDto);
            return MapToDto(await _userRepository.AddUserAsync(user));
        }

        public async Task<UserDto> UpdateUserAsync(UserDto userDto)
        {
            var user = MapToDomain(userDto);
            return MapToDto(await _userRepository.UpdateUserAsync(user));
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.ValidateUserLoginAsync(loginDto.UserName, loginDto.Password);
            return user == null ? null : MapToDto(user);
        }

        private UserDto MapToDto(User user)
        {
            return new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                UserName = user.UserName,
                EmailAddress = user.EmailAddress,
                Password = user.Password,
                ContactNumber = user.ContactNumber,
                Address = user.Address,
                Pincode = user.Pincode,
                AadhaarCard = user.AadhaarCard,
                BrokerId = user.BrokerId
            };
        }

        private User MapToDomain(UserDto userDto)
        {
            return new User
            {
                UserId = userDto.UserId,
                Name = userDto.Name,
                UserName = userDto.UserName,
                EmailAddress = userDto.EmailAddress,
                Password = userDto.Password,
                ContactNumber = userDto.ContactNumber,
                Address = userDto.Address,
                Pincode = userDto.Pincode,
                AadhaarCard = userDto.AadhaarCard,
                BrokerId = userDto.BrokerId
            };
        }
    }
}
