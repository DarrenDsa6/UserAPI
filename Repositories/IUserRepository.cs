using System.Collections.Generic;
using System.Threading.Tasks;
using UserAPI.Models.Domain;

namespace UserAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        Task<User> ValidateUserLoginAsync(string email, string password);
    }
}
