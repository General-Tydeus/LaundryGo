using LaundryGo.Platforms.Android.FldrLogin;

namespace LaundryGo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Platforms.Android.FldrLogin.PageLogin = new AppShell();
            MainPage = new AppShell();
        }
    }
}