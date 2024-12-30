using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace masterPage
{
    public partial class Asset : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {

        }

        protected void btnabout_Click(object sender, EventArgs e)
        {
            Response.Redirect("about.aspx");
        }

        protected void btnlogin_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}