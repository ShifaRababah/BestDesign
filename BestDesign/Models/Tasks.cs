using System.ComponentModel.DataAnnotations.Schema;

namespace BestDesign.Models
{
    public class Tasks
    {
        public int Id { set; get; }
        public string? Name { set; get; }
        public DateTime Date { set; get; }
        public string? Description { set; get; }
        public string? UserId { get; set; }
    }
}
