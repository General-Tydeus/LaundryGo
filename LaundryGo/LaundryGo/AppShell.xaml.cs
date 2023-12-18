using LaundryGo.Platforms.Android.FldrLogin;
using LaundryGo.Platforms.Android.FldrMain;
using LaundryGo.Platforms.Android.FldrSetup;

namespace LaundryGo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(PageLoading), typeof(PageLoading));
            Routing.RegisterRoute(nameof(PageLogin), typeof(PageLogin));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(PageMainMenu), typeof(PageMainMenu));
            Routing.RegisterRoute(nameof(PageProfile), typeof(PageProfile));
            Routing.RegisterRoute(nameof(PageChangePassword), typeof(PageChangePassword));
            Routing.RegisterRoute(nameof(PageSignUp), typeof(PageSignUp));
            Routing.RegisterRoute(nameof(PageMap), typeof(PageMap));
            Routing.RegisterRoute(nameof(PageShopSetup), typeof(PageShopSetup));
        }
    }
}