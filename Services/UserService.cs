using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {

        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> GetUserById(int id)
        {
            return await userRepository.GetUserById(id);


        }


        public async Task<User> CreataeUser(User user)
        {

            return await userRepository.CreataeUser(user);


        }

        public async Task<User> SignIN(User data)
        {
            return await userRepository.SignIN(data);

        }

        public async Task UpdateUser(int id, User userToUpdate)
        {

            await userRepository.UpdateUser(id, userToUpdate);
        }
    }
}
