using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NET2MDversion8
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
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            builder.Configuration.AddConfiguration(config);
            builder.Services.AddSingleton<IConfiguration>(config);
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CreateData>();
            builder.Services.AddTransient<CreateAssignment>();
            builder.Services.AddTransient<CreateSubmission>();
            builder.Services.AddTransient<EditSubmission>();
            builder.Services.AddTransient<EditAssignment>();
            builder.Services.AddTransient<ViewData>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
