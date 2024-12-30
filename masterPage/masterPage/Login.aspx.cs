using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace masterPage
{
    
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Session.SessionID);
            Response.Write("<br/>");
            Response.Write(Session.Count);
            Response.Write("<br/>");
            Response.Write(Session.Timeout);
            Response.Write("<br/>");
            //Session.Timeout = 2;
            Response.Write("-----------------------");
            con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=Banking; User Id = sa; Password = Kodiyala@123");
            con.Open();

            if (ViewState["counter"] == null)
            {
                ViewState["counter"] = 0;
                ViewState["mail"] = new List<string>();
            }
            //if (Convert.ToBoolean(Session["isLoggedIn"]))
            //{
            //    Response.Redirect("admin main.aspx");
            //}


        }


        protected void btnsub_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            string pwd = txtpwd.Text;
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.CommandText = "Select id, name from Appuser where email='" + email + "' and password='" + pwd + "'";
            cmdLogin.Connection = con;
            SqlDataReader dr = cmdLogin.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                //HttpCookie ck = new HttpCookie("qu");
                //ck["user"]= dr[1].ToString();
                //ck.Expires = DateTime.Now.AddMinutes(3);
                //Response.Cookies.Add(ck);


                // session

                Session.Add("email",txtemail.Text);
                Session.Add("user", dr[1].ToString()); //we can create both type of cookies
                Session["id"] = dr[0];
                Session["isLoggedIn"]=true;
                Response.Redirect("admin main.aspx?user=" + dr[1].ToString());
                //dr[1].ToString();
                

                con.Close();

            }
            else
            {
                lblmsg.Text = "authentication faild";
                int counter = Convert.ToInt32(ViewState["counter"]);
                counter++;
                ViewState["counter"] = counter;
                List<string> list = (List<string>)ViewState["mail"];
                list.Add(txtemail.Text);
                ViewState["mail"] = list;
                lblmsg.Text = "Login Attempt : " + counter.ToString();
                lblmsg.ForeColor = Color.Red;
                if (counter == 5)
                {
                    btnsub.Enabled = false;
                    foreach (string s in (List<string>)ViewState["mail"])
                    {
                        Response.Write(s + "<br/>");
                    }
                    Response.Write("-------------------------------------------------------");
                }

                txtemail.Text = "".Trim();
                txtpwd.Text = "".Trim();

            }
        }
    }
}