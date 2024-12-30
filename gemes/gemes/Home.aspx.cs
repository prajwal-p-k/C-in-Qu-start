using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gemes
{
    public partial class Home : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void ck1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void ck2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void ck3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void ck4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            List<string> lst = new List<string>();

            // Check which checkboxes are selected and add their text to the list
            if (ck1.Checked)
            {
                lst.Add(ck1.Text);
            }
            if (ck2.Checked)
            {
                lst.Add(ck2.Text);
            }
            if (ck3.Checked)
            {
                lst.Add(ck3.Text);
            }
            if (ck4.Checked)
            {
                lst.Add(ck4.Text);
            }

            
            if (lst.Count == 0)
            {
                lst.Add("no one is checked");
            }

            
            Session["sports"] = lst;

            Response.Redirect("min.aspx");

            
           




        }
    }
}