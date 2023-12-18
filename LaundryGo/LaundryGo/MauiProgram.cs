using Microsoft.Extensions.Logging;
using Acr.UserDialogs;
using LaundryGo.Platforms.Android.Services;
using LaundryGo.Platforms.Android.FldrLogin;
using LaundryGo.Platforms.Android.FldrMain;

namespace LaundryGo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
#if ANDROID
            UserDialogs.Init(()=>Platform.CurrentActivity);
#endif
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiMaps()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
          

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);

#endif
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif
#if ANDROID
            builder.Services.AddSingleton(UserDialogs.Instance);
#endif
            builder.Services.AddTransient<AuthService>();
            builder.Services.AddTransient<PageLogin>();
            builder.Services.AddTransient<PageLoading>();
            builder.Services.AddTransient<PageProfile>();
            return builder.Build();
        }
    }
}