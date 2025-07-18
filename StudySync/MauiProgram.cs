using CommunityToolkit.Maui;
using Microcharts.Maui;
using Microsoft.Extensions.Logging;
using StudySync.Services;
using StudySync.ViewModels;
using StudySync.Views;

namespace StudySync;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMicrocharts()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Register Services
        builder.Services.AddSingleton<SQLiteService>();

        // Register Pages and ViewModels
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<HomeViewModel>();

        builder.Services.AddTransient<NewTaskPage>();
        builder.Services.AddTransient<NewTaskViewModel>();

        // This is the critical section for the Checklist page
        builder.Services.AddTransient<ChecklistPage>();
        builder.Services.AddTransient<ChecklistViewModel>();

        builder.Services.AddTransient<ProgressPage>();
        builder.Services.AddTransient<ProgressViewModel>();

        builder.Services.AddTransient<GoalsPage>();
        builder.Services.AddTransient<GoalsViewModel>();

        // Register Routes for Navigation
        Routing.RegisterRoute(nameof(NewTaskPage), typeof(NewTaskPage));

        return builder.Build();
    }
}
