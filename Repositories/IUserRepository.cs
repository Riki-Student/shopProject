using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> CreataeUser(User user);
        Task<User> GetUserById(int id);
        Task<User> SignIN(User data);
        Task UpdateUser(int id, User userToUpdate);
    }
}