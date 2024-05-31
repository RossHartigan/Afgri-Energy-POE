using System.ComponentModel.DataAnnotations;

namespace AfgriEnergy.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Farmer { get; set; }
        public bool Employee { get; set; }

    }

    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public DateTime ProductionDate { get; set; } 
    }

}
