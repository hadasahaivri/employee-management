using Clean.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        Task<User> GetByUserNameAsync(string userName);
    }
}
