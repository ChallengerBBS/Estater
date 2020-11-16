namespace WebAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using WebAPI.Models;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
    }
}
