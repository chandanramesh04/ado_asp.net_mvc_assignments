using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Assignment_3_MVC.Models
{
    public class User
    {
        [Key]
        public string ? UserName { get; set; }
        public string ? Password { get; set; }

    }
}
