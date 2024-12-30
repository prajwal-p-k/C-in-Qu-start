using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssetManagement
{
    public partial class ViewAssetHistry : System.Web.UI.Page
    {
        int PageSize = 5;
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=AssetsManagement; User Id=sa; Password=Kodiyala@123");

        protected void Page_Load(object sender, EventArgs e)

        {

            if (!IsPostBack)
            {

                ddlAccounts.DataSource = ListCategories();
               
                ddlAccounts.DataTextField = "unique_number";
                ddlAccounts.DataValueField = "asset_id";
                ddlAccounts.DataBind();

                ViewState["currentPage"] = 0;
                ViewState["totalRecords"] = 0;

                BindProducts(); // Bind GridView initially
            }
        }

        private List<Category> ListCategories()
        {
            List<Category> categories = new List<Category>();

            string query = @"
        SELECT DISTINCT a.asset_id, a.unique_number 
        FROM asset a
        INNER JOIN asset_allocation aa ON a.unique_number = aa.unique_number";

            SqlDataAdapter daAccounts = new SqlDataAdapter(query, con);
            DataTable dtActs = new DataTable();
            daAccounts.Fill(dtActs);

            // Add a default 'Preferred Category' option
            categories.Add(new Category { asset_id = 0, unique_number = "Preferred Category" });

            foreach (DataRow r in dtActs.Rows)
            {
                categories.Add(new Category
                {
                    asset_id = Convert.ToInt32(r["asset_id"]),
                    unique_number = r["unique_number"].ToString()
                });
            }

            return categories;
        }


        private List<Product> ListProducts(int assetId)
        {
            List<Product> products = new List<Product>();

            string query = @"
        SELECT 
            c.allocation_id, 
            e.name AS employee_name, 
            c.allocation_date, 
            c.return_date, 
            c.status, 
            c.note 
        FROM asset_allocation c
        INNER JOIN asset a ON c.unique_number = a.unique_number
        INNER JOIN employee e ON c.employee_id = e.employee_id
        WHERE a.asset_id = @AssetId";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@AssetId", assetId);
                SqlDataAdapter daProduct = new SqlDataAdapter(cmd);
                DataTable dtProducts = new DataTable();
                daProduct.Fill(dtProducts);

                ViewState["totalRecords"] = dtProducts.Rows.Count;

                foreach (DataRow r in dtProducts.Rows)
                {
                    products.Add(new Product
                    {
                        allocation_id = Convert.ToInt32(r["allocation_id"]),
                        employee_name = r["employee_name"].ToString(), // Fetch the name
                        allocation_date = Convert.ToDateTime(r["allocation_date"]),
                        return_date = r["return_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["return_date"]),
                        status = r["status"].ToString(),
                        note = r["note"].ToString(),
                    });
                }
            }

            int currentPage = Convert.ToInt32(ViewState["currentPage"]);
            return products.Skip(currentPage * PageSize).Take(PageSize).ToList();
        }


        private void BindProducts()
        {
            if (ddlAccounts.SelectedValue == null || string.IsNullOrEmpty(ddlAccounts.SelectedValue) || ddlAccounts.SelectedValue == "0")
            {
                gvProducts.DataSource = null;
                gvProducts.DataBind();
                return;
            }

            int assetId = Convert.ToInt32(ddlAccounts.SelectedValue);
            var products = ListProducts(assetId);

            if (products.Count == 0) // Check if no records are found
            {
                // Inject JavaScript alert if no records found
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Asset is not allocated yet!');", true);
            }

            gvProducts.DataSource = products;
            gvProducts.DataBind();
        }




        protected void ddlAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["currentPage"] = 0; // Reset to first page
            BindProducts();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        //protected void Button1_Click(object sender, EventArgs e) // Next Page
        //{
        //    int currentPage = Convert.ToInt32(ViewState["currentPage"]);
        //    int totalRecords = Convert.ToInt32(ViewState["totalRecords"]);

        //    if ((currentPage + 1) * PageSize < totalRecords)
        //    {
        //        ViewState["currentPage"] = ++currentPage;
        //        BindProducts();
        //    }
        //}

        //protected void Button2_Click(object sender, EventArgs e) // Previous Page
        //{
        //    int currentPage = Convert.ToInt32(ViewState["currentPage"]);

        //    if (currentPage > 0)
        //    {
        //        ViewState["currentPage"] = --currentPage;
        //        BindProducts();
        //    }
        //}
    }

   
}
