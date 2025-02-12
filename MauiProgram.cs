using Microsoft.Extensions.Logging;
using GardenApp.Views;
using GardenApp.ViewModels;

namespace GardenApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register Views
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<PlantsPage>();
            builder.Services.AddTransient<ToolsPage>();
            builder.Services.AddTransient<GardenCarePage>();
            builder.Services.AddTransient<IndoorPlantsPage>();  // Add this
            builder.Services.AddTransient<OutdoorPlantsPage>(); // Add this
            //builder.Services.AddTransient<SeasonalPlantsPage>(); // Add this

            // Register ViewModels
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<PlantsViewModel>();
            builder.Services.AddTransient<ToolsViewModel>();
            builder.Services.AddTransient<GardenCareViewModel>();
            builder.Services.AddTransient<IndoorPlantsViewModel>();  // Add this
            builder.Services.AddTransient<OutdoorPlantsViewModel>(); // Add this
            //builder.Services.AddTransient<SeasonalPlantsViewModel>(); // Add this

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
