using BookStore.Core.Interfaces;
using BookStore.EF.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context) => _context = context;

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public T Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if(entity is not null)
                _context.Set<T>().Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take, Expression<Func<T, bool>>? orderBy = null, string direction = "ASC")
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if(take.HasValue)
                query = query.Take(take.Value);

            if(skip.HasValue)
                query = query.Skip(skip.Value);

            if(orderBy != null)
            {
                if(direction == "ASC")
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(criteria);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
