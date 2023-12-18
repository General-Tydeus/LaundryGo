using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryGo.Platforms.Android.FldrClass
{
    public class ClsLogData
    {
        public async Task<string> CheckUserPWord(string servstrLogInName, string servstrPWordLog)
        {
            var clientGet = new HttpClient();
            clientGet.BaseAddress = new Uri($"{new ClsGetIPAddress().GetIPAddress()}/API/LaundryGoWebApi/LoginUser/CheckUserPWord?strURILogInName={servstrLogInName}&strURIPWordLog={servstrPWordLog}");
            HttpResponseMessage response = await clientGet.GetAsync("");
            string strresult = await response.Content.ReadAsStringAsync();
            string strresultFinal = strresult.Trim('"');
            return strresultFinal;
            //1 = OK
            //2 = Not OK


            //var clientGet = new HttpClient();
            //var response = await clientGet.GetAsync($"http://172.24.144.1:111/API/LaundryGoWebApi/LoginUser/CheckUserPWord?strURILogInName={servstrLogInName}&strURIPWordLog={servstrPWordLog}");
            //string data = await response.Content.ReadAsStringAsync();

            //return data;

        }

        public async Task<Users> GetUserDetailsList(string strUserName)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"{new ClsGetIPAddress().GetIPAddress()}/API/LaundryGoWebApi/ListOthers/UserDetails?strURIUserName={strUserName}");
            var data = JsonConvert.DeserializeObject<Users>(response);
            return data;
        }
        //public async Task<string> CheckUserPWord(string servstrLogInName, string servstrPWordLog)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        try
        //        {
        //            var encodedLogInName = Uri.EscapeDataString(servstrLogInName);
        //            var encodedPWordLog = Uri.EscapeDataString(servstrPWordLog);

        //            var url = $"https://172.24.144.1:120/API/DINEPLUSWEBAPI/LoginUser/CheckUserPWord?strURILogInName={encodedLogInName}&strURIPWordLog={encodedPWordLog}";

        //            HttpResponseMessage response = await client.GetAsync(url);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                return await response.Content.ReadAsStringAsync();
        //            }
        //            else
        //            {
        //                return $"Error: {response.ReasonPhrase}";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return $"Exception: {ex.Message}";
        //        }
        //    }
        //}

    }
}
