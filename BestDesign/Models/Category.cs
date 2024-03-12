namespace BestDesign.Models
{
    public class Category
    {
        public int Id { set; get; }
        public string? Name { set; get; }
        public string? Description { set; get; }

        public List<Product> ? product { get; set; }
    }
}
