using LaundryGoWebApi.FldrClass;
using LGWEBAPI.FldrClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;

namespace LaundryGoWebApi.Controllers
{
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader dr;

        [HttpGet]
        [Route("API/LaundryGoWebApi/LoginUser/CheckUserPWord")]
        public string GetPWordResult(string strURILogInName, string strURIPWordLog)
        {

            try
            {
                myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
                myconnection.Open();
                string CheckNoTransact = string.Format($"SELECT Count(*) FROM tblUser WHERE UserName = '{strURILogInName}'");
                SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
                int CountData = int.Parse(com.ExecuteScalar().ToString());
                if (CountData > 0)
                {
                    string strDBPassword = string.Format($"SELECT PWord FROM tblUser WHERE UserName = '{strURILogInName}'");
                    SqlCommand comPWord = new SqlCommand(strDBPassword, myconnection);
                    string GetPWord = comPWord.ExecuteScalar().ToString();
                    if (new ClsHash().verifyMd5Hash(strURIPWordLog, GetPWord))
                    {
                        myconnection.Close();
                        return "1";//OK
                    }
                    else
                    {
                        myconnection.Close();
                        return "2";//Not ok
                    }
                }
                else
                {
                    myconnection.Close();
                    return "2";//user doesnt exist
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        [HttpPost]
        [Route("API/LaundryGoWebApi/Security/InsertUser")]
        public HttpResponseMessage PostUser(Users Users1)
        {
            string SqlStatement = "INSERT INTO tblUser (UserCode, PWord, Email, FullName, GroupCode, UserName, CNCode, Active) Values (@_UserCode, @_PWord, @_Email, @_FullName, @_GroupCode, @_UserName, @_CNCode, @_Active) ";
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            myconnection.Open();
            mycommand = new SqlCommand(SqlStatement, myconnection);
            mycommand.Parameters.Add("_UserCode", SqlDbType.VarChar).Value = new ClsAutoNumber().UserAutoNum();
            mycommand.Parameters.Add("_UserName", SqlDbType.VarChar).Value = Users1.UserName;
            mycommand.Parameters.Add("_PWord", SqlDbType.VarChar).Value = Users1.PWord;
            mycommand.Parameters.Add("_Email", SqlDbType.VarChar).Value = Users1.Email;
            mycommand.Parameters.Add("_FullName", SqlDbType.VarChar).Value = Users1.CompleteName;
            mycommand.Parameters.Add("_GroupCode", SqlDbType.VarChar).Value = "02";
            mycommand.Parameters.Add("_CNCode", SqlDbType.VarChar).Value = "01";
            mycommand.Parameters.Add("_Active", SqlDbType.Bit).Value = 1;
            mycommand.ExecuteNonQuery();
            myconnection.Close();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("API/LaundryGoWebApi/ListOthers/UserDetails")]
        public Users GetPendingPODetails(string strURIUserName)
        {
            Users user = null; // Initialize the user outside the loop

            string sqlStatement = $"SELECT * FROM tblUser WHERE UserName='{strURIUserName}' AND Active = 1";
            using (myconnection = new SqlConnection(new ClsGetConnection().PlsConnect()))
            {
                myconnection.Open();
                using (mycommand = new SqlCommand(sqlStatement, myconnection))
                using (dr = mycommand.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        user = new Users
                        {
                            UserCode = dr["UserCode"].ToString(),
                            UserName = dr["UserName"].ToString(),
                            GroupCode = dr["GroupCode"].ToString(),
                            CNCode = dr["CNCode"].ToString(),
                            Email = dr["Email"].ToString(),
                            CompleteName = dr["FullName"].ToString(),
                        };
                    }
                }
            }

            return user;
        }

    }
}
