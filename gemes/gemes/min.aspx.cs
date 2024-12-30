using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gemes
{
    public partial class min : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["sports"] != null)
            {
                //List<string> retrievedList = (List<string>)Session["sports"];
                foreach (string s in (List<string>)Session["sports"])
                {
                    Response.Write(s + "<br>"); // Display each item with line breaks
                }
            }
        }
    }
}