using Clean.Core.Entities;
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
    public class WorkingHoursService:IService<WorkingHours>
    {
        private readonly IRepositoryManager _manager;

        public WorkingHoursService(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public async Task< IEnumerable<WorkingHours>> GetAllAsync()
        {
            return await _manager.WorkingHours.GetAllAsync();
        }
        public async Task< WorkingHours?> GetByIdAsync(int id)
        {
            return await _manager.WorkingHours.GetByIdAsync(id);
        }
        public async Task<WorkingHours> AddAsync(WorkingHours workingHours)
        {
            var workingHoursAsync = await _manager.WorkingHours.AddAsync(workingHours);
            await _manager.SaveAsync();
            return workingHoursAsync;
        }
        public async Task<WorkingHours> UpdateAsync(int id,WorkingHours workingHours)
        {
            var dbWorkingHours = await GetByIdAsync(id);
            if (dbWorkingHours == null)
            {
                return null;
            }
            dbWorkingHours.Date = workingHours.Date;
            dbWorkingHours.Entry = workingHours.Entry;
            dbWorkingHours.Exit = workingHours.Exit;

            var workingHoursAsync = await _manager.WorkingHours.UpdateAsync(dbWorkingHours);
            await _manager.SaveAsync();
            return workingHoursAsync;
        }
        public async Task DeleteAsync(WorkingHours workingHours)
        {
            await _manager.WorkingHours.DeleteAsync(workingHours);
            await _manager.SaveAsync();
        }
    }
}
