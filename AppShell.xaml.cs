using GardenApp.Views;

namespace GardenApp
{
    public partial class AppShell:Shell
    {
        public AppShell(AppShellViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

            // Register routes for navigation
            Routing.RegisterRoute("login", typeof(LoginPage));

            // Plants routes
            Routing.RegisterRoute("plants/indoor-plants", typeof(IndoorPlantsPage));
            Routing.RegisterRoute("plants/outdoor-plants", typeof(OutdoorPlantsPage));
            Routing.RegisterRoute("plants/seasonal-plants", typeof(SeasonalPlantsPage));

            // Tools routes
            Routing.RegisterRoute("tools/hand-tools", typeof(HandToolsPage));
            Routing.RegisterRoute("tools/power-tools", typeof(PowerToolsPage));
            Routing.RegisterRoute("tools/watering-tools", typeof(WateringToolsPage));

            // Garden Care routes
            Routing.RegisterRoute("gardencare/fertilizers", typeof(FertilizersPage));
            Routing.RegisterRoute("gardencare/pest-control", typeof(PestControlPage));
            Routing.RegisterRoute("gardencare/soil-and-mulch", typeof(SoilAndMulchPage));

            // Cart route
            Routing.RegisterRoute("cart", typeof(CartPage));
        }
    }
}
