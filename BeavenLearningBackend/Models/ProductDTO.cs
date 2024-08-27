namespace BeavenLearningBackend.Models
{
    public class ProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int? Id { get; set; } = null;
    }
}
