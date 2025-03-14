using LDRestaurant.Models.BaseModels;
using System.Linq.Expressions;

namespace LDRestaurant.Repositories.Interfaces
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool isTracking, params string[] includes);
        IQueryable<T> GetAllWhere(Expression<Func<T, bool>> expression, bool isTracking, params string[] includes);
    }
}
