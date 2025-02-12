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
            builder.Services.AddTransient<IndoorPlantsPage>();  
            builder.Services.AddTransient<OutdoorPlantsPage>(); 
            builder.Services.AddTransient<SeasonalPlantsPage>();
            builder.Services.AddTransient<HandToolsPage>();
            builder.Services.AddTransient<PowerToolsPage>();
            builder.Services.AddTransient<WateringToolsPage>();
            builder.Services.AddTransient<FertilizersPage>();
            builder.Services.AddTransient<PestControlPage>();
            builder.Services.AddTransient<SoilAndMulchPage>();

            // Register ViewModels
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<PlantsViewModel>();
            builder.Services.AddTransient<ToolsViewModel>();
            builder.Services.AddTransient<GardenCareViewModel>();
            builder.Services.AddTransient<IndoorPlantsViewModel>();  
            builder.Services.AddTransient<OutdoorPlantsViewModel>(); 
            builder.Services.AddTransient<SeasonalPlantsViewModel>();
            builder.Services.AddTransient<HandToolsViewModel>();
            builder.Services.AddTransient<PowerToolsViewModel>();
            builder.Services.AddTransient<WateringToolsViewModel>();
            builder.Services.AddTransient<FertilizersViewModel>();
            builder.Services.AddTransient<PestControlViewModel>();
            builder.Services.AddTransient<SoilAndMulchViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
