namespace LaundryGo.Platforms.Android.FldrMain;

public partial class PageMainMenu : ContentPage
{
	public PageMainMenu()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //PageProfile.Instance.GetDetails();
    }
}