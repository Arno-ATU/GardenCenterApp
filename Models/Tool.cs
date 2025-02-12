namespace GardenApp.Models
{
    public class Tool
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }  // Hand Tools, Power Tools, or Watering Tools
        public decimal Price { get; set; }
    }
}
