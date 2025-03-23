using LDRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace LDRestaurant.Contexts
{
    public class LDRestaurantDbContext : DbContext //base
    {
        private static readonly string connectionString = "Server=.;Database=LDRestaurantDb;Integrated Security = true; TrustserverCertificate=true;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealCategory> MealCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder); //konfiqurasiyalar burada bildirilir.
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        //override base olan bir metodun icinin deyisilmesidir.
        //overloading bir metodunun parametrlerinin deyisilmesidir. Constructorlarla edirsen.
    }
}
