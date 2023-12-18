using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LaundryGo.Platforms.Android.FldrClass
{
    public class ClsGetIPAddress
    {
        string strServerIPAddress;
        public string GetIPAddress()
        {
            //return "http://192.168.180.61:120";
            return "http://192.168.254.102:111";
            //return $"http://{GetServerIP()}:111";
        }
        private string GetServerIP()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry("DESKTOP-7TUO7EH");
            IPAddress[] addresses = hostEntry.AddressList;
            foreach (IPAddress address in addresses)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    strServerIPAddress = address.ToString();
                }
            }
            return strServerIPAddress;
        }
    }
}
