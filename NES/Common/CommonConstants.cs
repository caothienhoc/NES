using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NES.Common
{
    public static class CommonConstants
    {
        public static  string USER_SESSION = "USER_SESSION";
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CartSession = "CartSession";
        public static int YearOfWork = 2022;
        public static string CurrentCulture { set; get; }

        public static DateTime GetNgayLV()
        {
            string conn = ConfigurationManager.ConnectionStrings["NESDbContext"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(conn);
            string sqlQuery = "SELECT GETDATE()";
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn);
            sqlCmd.CommandType = CommandType.Text;
            sqlConn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            DataTable dtToReturn = new DataTable("DATETIME");
            sda.Fill(dtToReturn);
            sqlCmd.Dispose();
            sqlConn.Close();

            return (DateTime)dtToReturn.Rows[0][0];
        }
    }
}