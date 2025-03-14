using LDRestaurant.Models.BaseModels;
using System.Linq.Expressions;

namespace LDRestaurant.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Delete(T entity);
        void Recover(T entity);
        int Save();
        Task<int> SaveAsync();

        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool isTracking, params string[] includes);
        IQueryable<T> GetAllWhere(Expression<Func<T, bool>> expression, bool isTracking, params string[] includes);
    }
}
