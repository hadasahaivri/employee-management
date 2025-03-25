using Clean.Core.Repositories;
using Clean.Core.Services;
using Clean.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Service
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _manager;

        public UserService(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _manager.Users .GetAllAsync();
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _manager.Users .GetByIdAsync(id);
        }
        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _manager.UserRepository.GetByUserNameAsync(userName);
        }
        public async Task<User> AddAsync(User user)
        {
            var userAsync= await _manager.Users.AddAsync(user);
            await _manager.SaveAsync();
            return userAsync;
        }
        public async Task<User> UpdateAsync(int id, User user)
        {
            var dbUser=await GetByIdAsync(id);
            if (dbUser == null) 
            { 
                return null;
            }
            dbUser.Name = user.Name;
            dbUser.Email = user.Email;
         
            var userAsync= await _manager.Users.UpdateAsync(dbUser);
            await _manager.SaveAsync();
            return userAsync;
        }
        public async Task DeleteAsync(User user)
        {
            await _manager.Users.DeleteAsync(user);
            await _manager.SaveAsync();
        }
    }
}
