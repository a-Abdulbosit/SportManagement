using Microsoft.EntityFrameworkCore;
using SportManagement.Data.DbContexts;
using SportManagement.Data.IRepositories;
using SportManagement.Domain.Common;

namespace SportManagement.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var entry = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public IQueryable<TEntity> SelectAll()
            => _dbSet;

        public async Task<TEntity> SelectByIdAsync(long id)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = _context.Update(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
