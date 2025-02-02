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
            try
            { 
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory) //in the words of chat gpt:
                                                            //"this makes sure appsettings.json is looked for inside the running directory" (???)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
                builder.Configuration.AddConfiguration(config);
                builder.Services.AddSingleton<IConfiguration>(config);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error connecting to the database: {e.Message}");
                throw;
            }
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
