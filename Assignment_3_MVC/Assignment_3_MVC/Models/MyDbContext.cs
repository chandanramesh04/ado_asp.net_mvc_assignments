using Microsoft.EntityFrameworkCore;

namespace Assignment_3_MVC.Models
{
    public class MyDbContext :DbContext
    {
        DbSet<User> ? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=chandan\SQLEXPRESS;database=SampleDB;trusted_connection=true;");
        }
    }
}
