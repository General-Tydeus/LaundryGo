using LaundryGo.Platforms.Android.FldrClass;
using LaundryGo.Platforms.Android.FldrLogin;
using LaundryGo.Platforms.Android.FldrSetup;
using LaundryGo.Platforms.Android.Services;

namespace LaundryGo.Platforms.Android.FldrMain;

public partial class PageProfile : ContentPage
{
    private readonly AuthService _authService;
    public static PageProfile Instance;
    public List<Users> userDetails = new List<Users>();

    public PageProfile(AuthService authService)
	{
		InitializeComponent();
        _authService = authService;
        Instance = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        GetDetails();
    }
    public async void GetDetails()
    {
        var varUserDetails = await new ClsLogData().GetUserDetailsList(await GetStoredUsername());

        userDetails.Add(new Users()
        {
            CompleteName = varUserDetails.CompleteName,
            Email = varUserDetails.Email,
            CNCode = varUserDetails.CNCode,
            GroupCode = varUserDetails.GroupCode,
            UserName = varUserDetails.UserName,
        });
        lblfname.Text = varUserDetails.CompleteName;
        lblUser.Text = $"@{ varUserDetails.UserName}";
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        _authService.LogOut();
        await Shell.Current.GoToAsync($"//{nameof(PageLogin)}");
    }

    private async void SetupShop(object sender, EventArgs e)
    {
        //await DisplayAlert("alert", await GetStoredUsername(), "ok");
        await Shell.Current.GoToAsync($"{nameof(PageShopSetup)}");

    }
    public async Task<string> GetStoredUsername()
    {
        string storedUsername =  Preferences.Get("Username", string.Empty);

        return storedUsername;
    }

}