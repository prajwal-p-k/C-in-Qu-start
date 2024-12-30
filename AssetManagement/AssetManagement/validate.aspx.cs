using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssetManagement
{
    public partial class validate : System.Web.UI.Page
    {
        SqlConnection con;
        string user = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=AssetsManagement; User Id = sa; Password = Kodiyala@123");

            //con = new SqlConnection();
            //con.ConnectionString = @"Data Source=ES-LAPTOP-611\SQL2017; Initial catalog=Banking; User Id=sa; Password=Sa123456";

            string email = Request.Form["email"].ToString();
            string pwd = Request.Form["pwd"].ToString();
            if (IsUserValid(email, pwd))
            {
                //Response.Redirect("Home.aspx?user=" + user);
                Response.Redirect("Home.aspx");

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
            cmdLogin.CommandText = "Select employee_id, name from employee where phone='" + email.Trim() + "' and password='" + pwd.Trim() + "' and role='Manager' ";
            //cmdLogin.CommandText = "Select id, name from Appuser where email='" + email + "' and password='" + pwd + "'";
            cmdLogin.Connection = con;
            
            SqlDataReader dr = cmdLogin.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                HttpCookie ck = new HttpCookie("qu");
                ck["user"] = dr[1].ToString();
                ck["id"]=dr[0].ToString();
                Session["id"] = dr[0];
                //ck.Expires = DateTime.Now.AddMinutes(3);
                Response.Cookies.Add(ck);
                user = dr[1].ToString();
                con.Close();
                return true;
            }
            con.Close();
            return false;

        

    }
    }
}