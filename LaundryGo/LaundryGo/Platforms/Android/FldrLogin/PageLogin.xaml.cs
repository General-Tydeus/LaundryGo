using LaundryGo.Platforms.Android.FldrClass;
using LaundryGo.Platforms.Android.FldrMain;
using LaundryGo.Platforms.Android.Services;

namespace LaundryGo.Platforms.Android.FldrLogin;

public partial class PageLogin : ContentPage
{
    private readonly AuthService _authService;

    NetworkAccess current;
    public PageLogin(AuthService authService)
	{
		InitializeComponent();
        _authService = authService;

    }
    public void CheckConnection()
    {
        current = Connectivity.NetworkAccess;
    }
    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        using (Acr.UserDialogs.UserDialogs.Instance.Loading("Logging in..."))
        {
        string username = usernameOutline.GetEntryValue();
        string password = passwordOutline.GetEntryValue();

            CheckConnection();
            if (current != NetworkAccess.Internet)
            {
                await DisplayAlert("Alert!", "Error Internet Connection", "OK");
                return;
            }
            if (string.IsNullOrEmpty(username))
            {
                await DisplayAlert("Alert!", "Please complete entry", "OK");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Alert!", "Please complete entry", "OK");
                return;
            }
            else
            {
                try
                {
                    string res = await new ClsLogData().CheckUserPWord(username, password);

                    if (res == "2")
                    {
                        await DisplayAlert("Information", "Invalid Login Information", "OK");
                        return;
                    }
                    else
                    {
                        _authService.Login();
                        SaveLogin(username);
                        await Shell.Current.GoToAsync($"//{nameof(PageMainMenu)}");


                    }
                    //await DisplayAlert("Login Information", $"Username: {username}\nPassword: {password}", "OK");
                }
                catch (Exception ex)
                {

                }
            }

        }

    }
    public void SaveLogin(string username)
    {
        Preferences.Set("Username", username);
    }


    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
       await Shell.Current.GoToAsync($"{nameof(PageChangePassword)}");
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(PageSignUp)}");

    }
}