namespace PROG.Models
{
public class Farmer
    {
        public int FarmerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Add this line
        public ICollection<Product> Products { get; set; }
    }
}