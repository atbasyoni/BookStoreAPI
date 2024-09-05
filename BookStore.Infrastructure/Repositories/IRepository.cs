using BookStore.Data.Models.Helpers;
using System.Linq.Expressions;

namespace BookStore.Infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<int> CountAsync();
        Task<IQueryable<T>> FindAllAsync(Expression<Func<T, bool>> criteria);
        Task<T> FindAsync(Expression<Func<T, bool>> criteria);
        void Update(T entity);
        void Delete(int id);
    }
}
