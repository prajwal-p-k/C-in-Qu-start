using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace masterPage
{
    public partial class admin : System.Web.UI.MasterPage
    {
        //HttpCookie ck;
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblmsg.Text = Request.QueryString["user"].ToString(); //it does not redirect to multipal page because it only work for single page
            // ck= Request.Cookies["qu"];
            //if (ck != null)
            //{
            //    lblmsg.Text = ck["user"].ToString();
            //}
            //else
            //{
            //    lblmsg.Text = "prajwal P K";
            //}
            lblmsg.Text =Session["user"].ToString();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void lblout_Click(object sender, EventArgs e)
        {
            //HttpCookie ck = Request.Cookies["qu"];
            //if (ck != null)
            //{
            //    ck.Expires = DateTime.Now.AddHours(-1);
            //    Response.Cookies.Add(ck);
            //    Response.Redirect("admin main.aspx");
            //}
            //else
            //{
            //    Response.Redirect("Login.aspx");
            //}
            Response.Redirect("Login.aspx");
        }

        protected void adser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}