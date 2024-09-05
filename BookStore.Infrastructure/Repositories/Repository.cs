using BookStore.Data.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(_context.Set<T>());
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<IQueryable<T>> FindAllAsync(Expression<Func<T, bool>> criteria)
        {
            return await Task.FromResult(_context.Set<T>().Where(criteria));
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(criteria);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
         
           _context.Set<T>().Remove(entity);
        }
    }
}
