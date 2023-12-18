using LaundryGoWebApi.FldrClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LGWEBAPI.FldrClass
{
    public class ClsAutoNumber
    {
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader dr;
        public string plsnumber;

        public string UserAutoNum()
        {
            string pristrNumber;
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            myconnection.Open();
            string CheckNoTransact = string.Format("SELECT Count(*) FROM tblUser");
            SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
            int CountData = int.Parse(com.ExecuteScalar().ToString());
            if (CountData > 0)
            {
                mycommand = new SqlCommand("SELECT Top 1 Right([UserCode],4) FROM tblUser ORDER BY Right([UserCode],4) DESC", myconnection);
                dr = mycommand.ExecuteReader();
                dr.Read();
                string no1 = null;
                int no2;
                no1 = dr[0].ToString();
                no2 = (int.Parse(no1)) + 1;
                pristrNumber = "A" + Convert.ToString(no2).PadLeft(4, '0');
                dr.Close();
            }
            else
            {
                pristrNumber = "A0001";
            }
            myconnection.Close();
            return pristrNumber;
        }
    }
}
