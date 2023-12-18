using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryGo.Platforms.Android.Services
{
    public class AuthService
    {
        private const string AuthStateKey = "AuthState";
        public const string user = "Username";

        public async Task<bool> IsAuthenticatedAsync()
        {
            await Task.Delay(1000);
            
            var authState = Preferences.Default.Get<bool>(AuthStateKey, false);

            return authState;
        }

        public void Login()
        {
            Preferences.Default.Set<bool>(AuthStateKey, true);
        }
        public void LogOut()
        {
            Preferences.Default.Remove(AuthStateKey);

        }

        //public async Task<string> SaveLogin(string usrnm)
        //{
        //    await Task.Delay(1000);

        //    var authState = Preferences.Default.Get<string>(user, string);

        //    return authState;
        //}

    }
}
