namespace GardenApp
{
    public partial class AppShell:Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Register routes for navigation
            //Routing.RegisterRoute("login", typeof(Views.LoginPage));

            // Plants routes
            Routing.RegisterRoute("plants/indoor-plants", typeof(Views.IndoorPlantsPage));
            //Routing.RegisterRoute("plants/outdoor-plants", typeof(Views.OutdoorPlantsPage));  // You'll need to create this page
            //Routing.RegisterRoute("plants/seasonal-plants", typeof(Views.SeasonalPlantsPage)); // You'll need to create this page

            // Tools routes
            Routing.RegisterRoute("tools/hand-tools", typeof(Views.ToolsPage));
            Routing.RegisterRoute("tools/power-tools", typeof(Views.ToolsPage));
            Routing.RegisterRoute("tools/watering-tools", typeof(Views.ToolsPage));

            // Garden Care routes
            Routing.RegisterRoute("gardencare/fertilizers", typeof(Views.GardenCarePage));
            Routing.RegisterRoute("gardencare/pest-control", typeof(Views.GardenCarePage));
            Routing.RegisterRoute("gardencare/soil-and-mulch", typeof(Views.GardenCarePage));
        }
    }
}
