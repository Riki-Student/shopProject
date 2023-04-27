using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        ShopWebsiteContext shopWebsiteContext;

        public UserRepository(ShopWebsiteContext shopWebsiteContext)
        {
            this.shopWebsiteContext = shopWebsiteContext;
        }

        public async Task<User> GetUserById(int id)
        {
            User? user = await shopWebsiteContext.Users.FindAsync(id);
            return user;


        }


        public async Task<User> CreataeUser(User user)
        {
            await shopWebsiteContext.AddAsync(user);
            await shopWebsiteContext.SaveChangesAsync();
            return user;

        }

        public async Task<User> SignIN(User data)
        {
            List<User> user = await shopWebsiteContext.Users.Where(user => user.Password == data.Password && user.Email == data.Email).ToListAsync();
            if (user.Count == 0)
                return null;
            return user[0];
        }
        //  PUT api/<LoginController>


        public async Task UpdateUser(int id, User userToUpdate)
        {
            shopWebsiteContext.Update(userToUpdate);
            await shopWebsiteContext.SaveChangesAsync();

        }
    }
}
