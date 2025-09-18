using System;

namespace PRN232.Lab1.CoffeeStore.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<bool> RemoveAsync(T entity);
    }
}
