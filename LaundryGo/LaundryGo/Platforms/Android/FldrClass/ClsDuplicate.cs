using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryGo.Platforms.Android.FldrClass
{
    public class ClsDuplicate
    {
        public async Task<string> strCheckDuplicate(string strTableName, string strFieldName, string strValueFieldName)
        {
            DuplicateData DuplicateData1 = new DuplicateData()
            {
                FldTableName = strTableName,
                FldFieldName = strFieldName,
                FldValueFieldName = strValueFieldName,
            };
            var jsonDuplicate = JsonConvert.SerializeObject(DuplicateData1);
            var contentDuplicate = new StringContent(jsonDuplicate, Encoding.UTF8, "application/json");
            HttpClient clientDuplicate = new HttpClient();
            var resultDuplicate = await clientDuplicate.PostAsync($"{new ClsGetIPAddress().GetIPAddress()}/API/LaundryGoWebApi/Duplicate/CheckDuplicateDesc", contentDuplicate);

            if (resultDuplicate.IsSuccessStatusCode)
            {
                return "1"; //Duplicate
            }
            else
            {
                return "2"; //No Duplicate
            }
        }
    }
}
