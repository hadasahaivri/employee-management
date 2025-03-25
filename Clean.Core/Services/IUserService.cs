using Clean.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Services
{
    public interface IUserService:IService<User>
    {
        Task<User> GetByUserNameAsync(string userName);
    }
}
