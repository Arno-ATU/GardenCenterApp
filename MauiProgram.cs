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

            // Register ViewModels
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<PlantsViewModel>();
            builder.Services.AddTransient<ToolsViewModel>();
            builder.Services.AddTransient<GardenCareViewModel>();
            builder.Services.AddTransient<IndoorPlantsViewModel>();  
            builder.Services.AddTransient<OutdoorPlantsViewModel>(); 
            builder.Services.AddTransient<SeasonalPlantsViewModel>(); 

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
