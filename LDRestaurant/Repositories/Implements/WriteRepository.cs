using LDRestaurant.Contexts;
using LDRestaurant.Models.BaseModels;
using LDRestaurant.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LDRestaurant.Repositories.Implements
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly LDRestaurantDbContext _dbContext; //LDRestaurant burada tipdir
        public WriteRepository()
        {
            _dbContext = new LDRestaurantDbContext(); //insance
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            entity.isDeleted = true;
        }

        public void Recover(T entity)
        {
            entity.isDeleted = false;
        }

        public void Remove(T entity)
        {
            Table.Remove(entity);
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
            Table.Update(entity);
        }
    }
}
