

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;
        public BaseRepository()
        {
            _context = new AppDbContext();
            _dbset = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
