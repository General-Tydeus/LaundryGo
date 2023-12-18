using LaundryGo.Platforms.Android.FldrMain;
using LaundryGo.Platforms.Android.Services;

namespace LaundryGo.Platforms.Android.FldrLogin;

public partial class PageLoading : ContentPage
{
    private readonly AuthService _authService;

    public PageLoading(AuthService authService)
	{
		InitializeComponent();
        _authService = authService;
    }
    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (await _authService.IsAuthenticatedAsync())
        {
            await Shell.Current.GoToAsync($"//{nameof(PageMainMenu)}");

        }
        else
        {
            await Shell.Current.GoToAsync($"//{nameof(PageLogin)}");
        }
    }
}