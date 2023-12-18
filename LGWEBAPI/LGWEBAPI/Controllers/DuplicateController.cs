using LaundryGoWebApi.FldrClass;
using LGWEBAPI.FldrClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LGWEBAPI.Controllers
{
    [ApiController]
    public class DuplicateController : ControllerBase
    {
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader dr;


        [Route("API/LaundryGoWebApi/Duplicate/CheckDuplicateDesc")]
        public ActionResult CheckIfDuplicate(DuplicateData DuplicateData1)
        {
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            myconnection.Open();
            string CheckNoTransact = string.Format("SELECT Count(*) FROM {0} WHERE {1}='" + DuplicateData1.FldValueFieldName + "'", DuplicateData1.FldTableName, DuplicateData1.FldFieldName);
            SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
            int CountData = int.Parse(com.ExecuteScalar().ToString());
            myconnection.Close();
            if (CountData > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
