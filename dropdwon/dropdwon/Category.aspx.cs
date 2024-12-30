using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dropdwon
{
    public partial class Category1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=Myshop; User Id = sa; Password = Kodiyala@123");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        void BindData()
        {
            SqlDataAdapter daAccounts = new SqlDataAdapter("select catid,category,'~/Images/'+category+'.jpg' as [ImageUrl] from categorylist", con);
            DataTable dataTable = new DataTable();
            daAccounts.Fill(dataTable);
            List<Category> categories = new List<Category>();
            foreach (DataRow r in dataTable.Rows)
            {
                categories.Add(new Category { CatId = Convert.ToInt32(r[0]), CategoryName = r[1].ToString(), CategoryImage = r[2].ToString() });
            }
            DataList1.DataSource = categories;
            DataList1.DataBind();
        }
    }
}