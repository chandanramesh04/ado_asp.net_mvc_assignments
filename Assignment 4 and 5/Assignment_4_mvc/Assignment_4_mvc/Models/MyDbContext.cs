using Microsoft.EntityFrameworkCore;

namespace Assignment_4_mvc.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Account> ? AccountTable { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=chandan\SQLEXPRESS;database=SampleDB;trusted_connection=true;");
        }
    }
}
