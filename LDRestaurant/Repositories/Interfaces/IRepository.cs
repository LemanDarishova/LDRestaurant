using LDRestaurant.Models.BaseModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LDRestaurant.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table { get; }        
    }
}
