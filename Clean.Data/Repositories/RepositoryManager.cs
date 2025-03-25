

using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Data.Entities;
using System;

namespace Clean.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        public IRepository<User> Users { get; }
        public IRepository<WorkingHours> WorkingHours { get; }
        public IRepository<Vacations> Vacations { get; }
        public IUserRepository UserRepository { get; }

        public RepositoryManager(DataContext context, IRepository<User> user,
        IRepository<WorkingHours> workingHours, IRepository<Vacations> vacations, IUserRepository userRepository)
        {
            _context = context;
            Users = userRepository;
            WorkingHours = workingHours;
           Vacations = vacations;
            UserRepository = userRepository;
        }

        public async Task SaveAsync()
        {
          await _context.SaveChangesAsync();
        }
    }
}