using Clean.Core.Entities;
using Clean.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Repositories
{
    public interface IRepositoryManager
    {
        IRepository<User> Users { get; }
        IRepository<WorkingHours> WorkingHours { get; }
        IRepository<Vacations> Vacations { get; }
        IUserRepository UserRepository { get; }

        Task SaveAsync();
    }
}
