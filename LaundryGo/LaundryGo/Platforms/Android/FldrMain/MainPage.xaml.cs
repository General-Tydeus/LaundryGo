using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;

namespace LaundryGo
{
    public partial class MainPage : ContentPage
    {

   
        public MainPage()
        {
            InitializeComponent();
            //OnAppearing();
        }
      
        protected async override void OnAppearing()
        {
            //await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            base.OnAppearing();
            await DisplayAlert("alert", "here", "ok");

            //var status = CheckAndRequestLocationPermission();
            //await DisplayAlert("alert", status.ToString(), "ok");
            //if (status == PermissionStatus.Granted)
            //{
            //    var geolocation = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
            //    var location = await Geolocation.GetLocationAsync(geolocation);

            //    map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMeters(100)));

            //    //if (location != null)
            //    //{
            //    //    var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
            //    //    if (placemarks != null && placemarks.Any())
            //    //    {
            //    //        var placemark = placemarks.FirstOrDefault();

            //    //        var street = placemark.Thoroughfare; // Street name
            //    //        var city = placemark.Locality; // City
            //    //        var state = placemark.AdminArea; // State
            //    //        var country = placemark.CountryName; // Country
            //    //        var postalCode = placemark.PostalCode; // Postal code

            //    //        var fullAddress = $"{street}, {city}, {state}, {postalCode}, {country}";
            //    //        var pin = new Pin
            //    //        {
            //    //            Address = fullAddress.ToString(),
            //    //            Location = location,
            //    //            Type = PinType.Place,
            //    //            Label = "Current"
            //    //        };

            //    //        map.Pins.Add(pin);
            //    //    }
            //    //}
            //}
            //else
            //{
            //    await DisplayAlert("Info", "Turn on Location", "Ok");
            //}

           
        }
        public async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status == PermissionStatus.Granted)
                return status;
            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }
            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            {
                // Prompt the user with additional information as to why the permission is needed
                await Shell.Current.DisplayAlert("Needs permissions", "BECAUSE!!!", "OK");
            }
            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return status;
        }

    }
}