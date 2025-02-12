namespace GardenApp.Models
{
    public class Plant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }  // Indoor, Outdoor, or Seasonal
        public decimal Price { get; set; }
    }
}
