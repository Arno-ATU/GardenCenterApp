namespace GardenApp.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }

        public Product()
        {
            Id = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Price = 0.0m;
            Category = string.Empty;
            Subcategory = string.Empty;
        }
    }
}
