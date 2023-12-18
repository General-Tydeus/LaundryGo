using LaundryGo.Platforms.Android.FldrClass;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace LaundryGo.Platforms.Android.FldrLogin;

public partial class PageSignUp : ContentPage
{
	public PageSignUp()
	{
		InitializeComponent();
	}

    private async void btnSignUp_Clicked(object sender, EventArgs e)
    {
        string fname = fullnameOutline.GetEntryValue();
        string email = emailOutline.GetEntryValue();
        string username = usernameOutline.GetEntryValue();
        string password = passwordOutline.GetEntryValue();
        string cpassword = confirmpasswordOutline.GetEntryValue();

       // await DisplayAlert("Login Information", $"fname: {fname}\n email: {email} \n username: {username}\n Password: {password}\n cpassword: {cpassword}", "OK");

        if (string.IsNullOrEmpty(fname))
        {
            await DisplayAlert("(!)", "Please complete the info", "OK");

        }else if (string.IsNullOrEmpty(email))
        {
            await DisplayAlert("(!)", "Please complete the info", "OK");

        }else if (ValidateEmail(email) != "Ok")
        {
            await DisplayAlert("(!)", "Email Not Allowed", "OK");

        }else if (await new ClsDuplicate().strCheckDuplicate("tblUser", "UserName", username) == "1")
        {
            await DisplayAlert("(!)", "Username Already Exist", "GL");
            
        }
        else if(string.IsNullOrEmpty(username))
        {
            await DisplayAlert("(!)", "Please complete the info", "OK");

        }else if(string.IsNullOrEmpty(password))
        {
            await DisplayAlert("(!)", "Please complete the info", "OK");

        }else if (string.IsNullOrEmpty(cpassword))
        {
            await DisplayAlert("(!)", "Please complete the info", "OK");

        }else if (password != cpassword)
        {
            await DisplayAlert("(!)", "Password does not match", "OK");
        }
        else
        {
            //await Shell.Current.GoToAsync($"//{nameof(PageLogin)}");
            Users Users1 = new Users()
            {
                UserName = username,
                PWord = getMd5Hash(password),
                Email = email,
                CompleteName = fname,
            };
            var json = JsonConvert.SerializeObject(Users1);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync($"{new ClsGetIPAddress().GetIPAddress()}/API/LaundryGoWebApi/Security/InsertUser", content);
            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert("(!)", "User Created", "OK");
                await Shell.Current.GoToAsync($"//{nameof(PageLogin)}");
            }
            else
            {
                await DisplayAlert("(!)", "Failed to Save", "OK");

            }

        }
    }

    static string getMd5Hash(string input)
    {
        MD5 md5Hasher = MD5.Create();

        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

        StringBuilder sBuilder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        return sBuilder.ToString();

    }

    public static string ValidateEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        if (Regex.IsMatch(email, pattern))
        {
            return "Ok";
        }
        else
        {
            return "Invalid email.";
        }
    }
}