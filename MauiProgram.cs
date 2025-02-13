using Microsoft.Extensions.Logging;
using GardenApp.Views;
using GardenApp.ViewModels;
using GardenApp.Services;

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

            // Register services
            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<CartService>();
            

            // Register Views
            builder.Services.AddTransient<LoginPage>();
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
            builder.Services.AddTransient<CartPage>();
            builder.Services.AddTransient<CheckoutPage>();

            // Register ViewModels

            builder.Services.AddTransient<AppShellViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
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
            builder.Services.AddTransient<CartViewModel>();
            builder.Services.AddTransient<CheckoutViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
