using Microsoft.EntityFrameworkCore;
using Web_Sharp_T_2.DTO;

namespace Web_Sharp_T_2.DB
{
    public class ContextDB : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        private readonly string _DBSource;
        public ContextDB(string DBSource)
        {
            _DBSource = DBSource;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_DBSource}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
