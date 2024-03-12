using System.ComponentModel.DataAnnotations.Schema;

namespace BestDesign.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? UserId { get; set; }


    }
}
