using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace SampleApplication
{
    public partial class validate : System.Web.UI.Page
    {
        SqlConnection con;
        string user = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=Banking; User Id = sa; Password = Kodiyala@123");
            
                //con = new SqlConnection();
                //con.ConnectionString = @"Data Source=ES-LAPTOP-611\SQL2017; Initial catalog=Banking; User Id=sa; Password=Sa123456";

                string email = Request.Form["email"].ToString();
                string pwd = Request.Form["pwd"].ToString();
                if (IsUserValid(email, pwd))
                {
                    Response.Redirect("Home.aspx?user=" + user);
                }
                else
                {
                    Response.Redirect("Login.aspx?msg=0");
                }
            }
            bool IsUserValid(string email, string pwd)
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmdLogin = new SqlCommand();
                cmdLogin.CommandText = "Select id, name from Appuser where email='" + email + "' and password='" + pwd + "'";
                cmdLogin.Connection = con;
                SqlDataReader dr = cmdLogin.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    user = dr[1].ToString();
                    con.Close();
                    return true;
                }
                con.Close();
                return false;
            
        }
    }
}