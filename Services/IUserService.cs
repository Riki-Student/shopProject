using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<User> CreataeUser(User user);
        Task<User> GetUserById(int id);
        Task<User> SignIN(User data);
        Task UpdateUser(int id, User userToUpdate);
    }
}