using PRN232.Lab1.CoffeeStore.Repository.DBContext;
using PRN232.Lab1.CoffeeStore.Repository.Implementation;
using PRN232.Lab1.CoffeeStore.Repository.Interface;

namespace PRN232.Lab1.CoffeeStore.Repository.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        IMenuRepository MenuRepository { get; }
        ProductRepository ProductRepository { get; }
        ProductInMenuRepository ProductInMenuRepository { get; }
        int SaveChange();
        Task<int> SaveChangeAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoffeeStoreDBContext _context;
        private IMenuRepository _menuRepository;
        private ProductRepository _productRepository;
        private ProductInMenuRepository _productInMenuRepository;

        public UnitOfWork(CoffeeStoreDBContext context)
        {
            _context = context;
        }

        public IMenuRepository MenuRepository
        {
            get
            {
                return _menuRepository ??= new MenuRepository(_context);
            }
        }
        public ProductRepository ProductRepository
        {
            get
            {
                return _productRepository ??= new ProductRepository(_context);
            }
        }
        public ProductInMenuRepository ProductInMenuRepository
        {
            get
            {
                return _productInMenuRepository ??= new ProductInMenuRepository(_context);
            }
        }
        public int SaveChange()
        {
            int result = -1;

            using (var dbContext = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContext.Commit();
                }
                catch (Exception)
                {
                    result = -1;
                    dbContext.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangeAsync()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                int result = await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                return -1;
            }
        }

        public void Dispose() => _context.Dispose();
    }
}
