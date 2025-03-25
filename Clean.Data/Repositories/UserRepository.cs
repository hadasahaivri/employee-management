using Clean.Core.Repositories;
using Clean.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Data.Repositories
{

    public class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(DataContext context):base(context) { }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _dbSet.Where(u => u.Name == userName).FirstOrDefaultAsync();
        }
    }
}
