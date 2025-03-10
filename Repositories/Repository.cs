using Microsoft.EntityFrameworkCore;
using RepoUoWdemo.Data;

namespace RepoUoWdemo.Repositories
{
    // "where T : class" säkerställer att endast referenstyper (databasmodeller) används.
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly ApplicationDbContext _context;

        // DbSet<T> är en samling som representerar en databas-tabell i Entity Framework Core.
        // _dbSet är ett fält som lagrar den aktuella databastabellen för en given entitet (T).
        // Set = samling
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;

            // Om T är Product, returnerar context.Set<Product>() en referens till Products-tabellen i databasen.
            // Set<T>() används för att dynamiskt komma åt en databas-tabell utan att hårdkoda den.
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);

                await _context.SaveChangesAsync();
            }
        }
    }
}
