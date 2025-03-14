using LDRestaurant.Contexts;
using LDRestaurant.Models.BaseModels;
using LDRestaurant.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LDRestaurant.Repositories.Implements
{
    public class ReadRepository<T>:IReadRepository<T> where T : BaseEntity
    {
        LDRestaurantDbContext _dbContext; //LDRestaurant burada tipdir
        public ReadRepository()
        {
            _dbContext = new LDRestaurantDbContext(); //insance
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>> expression, bool isTracking, params string[] includes)
        {
            var query = Table.Where(expression);
            if (isTracking == false)
            {
                query = query.AsNoTracking();
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool isTracking, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (isTracking == false)
            {
                query = query.AsNoTracking();
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            T? entity = await query.FirstOrDefaultAsync(expression);
            return entity;
        }
    }
}
