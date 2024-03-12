using System.ComponentModel.DataAnnotations.Schema;

namespace BestDesign.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? UserId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
