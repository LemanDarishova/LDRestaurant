using LDRestaurant.Models.BaseModels;

namespace LDRestaurant.Repositories.Interfaces
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Delete(T entity);
        void Recover(T entity);
        int Save();
        Task<int> SaveAsync();
    }
}
