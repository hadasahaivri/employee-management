﻿using Clean.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        Task<T> AddAsync( T entity);

        Task<T> UpdateAsync(int id, T entity);
        Task DeleteAsync(T entity);
    }
}
