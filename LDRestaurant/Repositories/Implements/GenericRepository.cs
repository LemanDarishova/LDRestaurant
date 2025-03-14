using LDRestaurant.Contexts;
using LDRestaurant.Models.BaseModels;
using LDRestaurant.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LDRestaurant.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        LDRestaurantDbContext _dbContext; //LDRestaurant burada tipdir
        DbSet<T> _dbSet;
        public GenericRepository()
        {
            _dbContext = new LDRestaurantDbContext(); //insance
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            entity.isDeleted = true;
        }

        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>> expression, bool isTracking, params string[] includes)
        {
            var query = _dbSet.Where(expression);
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
            var query = _dbSet.AsQueryable();
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

        public void Recover(T entity)
        {
            entity.isDeleted = false;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
