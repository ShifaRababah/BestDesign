using System.ComponentModel.DataAnnotations.Schema;

namespace BestDesign.Models
{
    public class TimeSheet
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? UserId { get; set; }


    }
}
