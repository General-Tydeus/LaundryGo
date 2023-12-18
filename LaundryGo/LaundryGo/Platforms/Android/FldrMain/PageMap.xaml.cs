using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace LaundryGo.Platforms.Android.FldrMain;

public partial class PageMap : ContentPage
{
	public PageMap()
	{
		InitializeComponent();
	}
    protected async override void OnAppearing()
	{
		base.OnAppearing();
        var locationPermissionStatus = await CheckAndRequestLocationPermission();

        if (locationPermissionStatus == PermissionStatus.Granted)
        {
            LoadLocation();
        }
        else
        {
            await Shell.Current.DisplayAlert("Permission Denied", "Location permission not granted", "OK");
        }
    }
    public async Task<PermissionStatus> CheckAndRequestLocationPermission()
    {
        var status = PermissionStatus.Unknown;
        status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        if (status == PermissionStatus.Granted)
            return status;

        if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
        {
            await Shell.Current.DisplayAlert("Needs permissions", "BECAUSE!!!", "OK");
            AppInfo.ShowSettingsUI();
        }
        status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        return status;
    }

    public async void LoadLocation()
    {
        try
        {
            using (Acr.UserDialogs.UserDialogs.Instance.Loading("fetching current location..."))
            {
                var geolocation = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(geolocation);
                if (location != null)
                {
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMeters(100)));
                    map.IsShowingUser = true;

                }
            }    
        }
        catch (FeatureNotEnabledException)
        {
            await Shell.Current.DisplayAlert("Location Services", "Please enable location services on your device", "OK");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}