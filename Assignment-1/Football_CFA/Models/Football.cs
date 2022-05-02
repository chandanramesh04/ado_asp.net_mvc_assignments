using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Football_CFA.Models
{
    [Table("Football_Table")]
    public class Football
    {
        [Required(ErrorMessage ="MatchID is required")]
        [Key]
        public int MatchID { get; set; }
        [Required(ErrorMessage = "TeamName1 is required")]
        public string  TeamName1 { get; set; }
        [Required(ErrorMessage = "TeamName2 is required")]
        public string  TeamName2 { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string  Status { get; set; }
        public string WinningTeam { get; set; }

        [Required(ErrorMessage = "Points is required")]
        public int Points { get; set; }


    }

    public class FootballContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=chandan\SQLEXPRESS;database=FootballDB;trusted_connection=true;");
        }
        public DbSet<Football> FootballData { get; set; }
    }

}


