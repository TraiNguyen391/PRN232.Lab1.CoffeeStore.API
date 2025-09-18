using Microsoft.EntityFrameworkCore;
using PRN232.Lab1.CoffeeStore.Repository.DBContext;
using PRN232.Lab1.CoffeeStore.Repository.Interface;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly CoffeeStoreDBContext _context;

    //public GenericRepository()
    //{
    //    _context ??= new CoffeeStoreDBContext();
    //}

    public GenericRepository(CoffeeStoreDBContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(T entity)
    {
        _context.Add(entity);
        //return await _context.SaveChangesAsync();
        return 1;
    }

    public async Task<int> UpdateAsync(T entity)
    {
        //_context.ChangeTracker.Clear();
        //var tracker = _context.Attach(entity);
        //tracker.State = EntityState.Modified;
        _context.Entry(entity).State = EntityState.Modified;
        //return await _context.SaveChangesAsync();
        return 1;
    }

    public async Task<bool> RemoveAsync(T entity)
    {
        _context.Remove(entity);
        //await _context.SaveChangesAsync();
        return true;
    }

}