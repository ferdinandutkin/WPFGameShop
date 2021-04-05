using Microsoft.EntityFrameworkCore;

namespace WPFGameShop
{
    public class ShopContext : DbContext
    {
        public DbSet<GameModel> Games { get; set; }
        public DbSet<GenreModel> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source =.\SQLEXPRESS; Trusted_Connection = Yes; DataBase = Shop;");
        }
    }
}
