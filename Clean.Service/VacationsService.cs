using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Core.Services;
using Clean.Data.Entities;

namespace Clean.Service
{
    public class VacationsService : IService<Vacations>
    {
        private readonly IRepositoryManager _manager;

        public VacationsService( IRepositoryManager manager)
        {
            _manager = manager;
        }
        public async Task<IEnumerable<Vacations>> GetAllAsync()
        {
            return await _manager.Vacations.GetAllAsync();
        }
        public async Task<Vacations?> GetByIdAsync(int id)
        {
            return await _manager.Vacations.GetByIdAsync(id);
        }
        public async Task<Vacations> AddAsync(Vacations vacations)
        {
            var vacationAsync = await _manager.Vacations.AddAsync(vacations);
            await _manager.SaveAsync();
            return vacationAsync;
        }
        public async Task<Vacations> UpdateAsync(int id,Vacations vacations)
        {
            var dbVacations = await GetByIdAsync(id);
            if (dbVacations == null)
            {
                return null;
            }
            dbVacations.StartDate = vacations.StartDate;
            dbVacations.EndDate = vacations.EndDate;

            var vacationsAsync = await _manager.Vacations.UpdateAsync(dbVacations);
            await _manager.SaveAsync();
            return vacationsAsync;
        }
        public async Task DeleteAsync(Vacations vacations)
        {
            await _manager.Vacations.DeleteAsync(vacations);
            await _manager.SaveAsync();
        }
    }
}
