using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Design;

namespace dropdwon
{
    public partial class Home : System.Web.UI.Page
    {
        int PageSize = 5;
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=AssetsManagement; User Id = sa; Password = Kodiyala@123");
        protected void Page_Load(object sender, EventArgs e)
        {
            //ddlAccounts.DataSource = Listcategory();
            //ddlAccounts.DataTextField = "Category";
            //ddlAccounts.DataValueField = "catid";
            //ddlAccounts.DataBind();

            //ddlAccounts.DataSource = ListCategories();
            //ddlAccounts.DataTextField = "CategoryName";
            //ddlAccounts.DataValueField = "catid";
            //ddlAccounts.DataBind();

            if (!IsPostBack)
            {
                ddlAccounts.DataSource = ListCategories();
                ddlAccounts.DataTextField = "CategoryName";
                ddlAccounts.DataValueField = "catid";
                ddlAccounts.DataBind();

                ViewState["currentPage"] = 0;
                ViewState["totalRecords"] = 0;
            }



        }
        DataTable Listcategory()
        {
            SqlDataAdapter daAccounts = new SqlDataAdapter("select catid,category from categorylist",con);
            DataTable dtActs = new DataTable();
            daAccounts.Fill(dtActs);
            DataRow r=dtActs.NewRow();
            r[0] = 0;
            r[1] = "your prefferd category";
            dtActs.Rows.InsertAt(r,0);
            return dtActs;
        }

        List<Category> ListCategories()
        {
            List<Category> categories = new List<Category>();
            SqlDataAdapter daAccounts = new SqlDataAdapter("select catid,category from categorylist", con);
            DataTable dtActs = new DataTable();
            daAccounts.Fill(dtActs);
            categories.Add(new Category { CatId = 0, CategoryName = "Preffer catagery" });
            foreach (DataRow r in dtActs.Rows)
            {
                categories.Add(new Category { CatId = Convert.ToInt32(r[0]), CategoryName = r[1].ToString() });
            }
            return categories;
        }

        protected void ddlAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvProducts.DataSource = ListProducts(Convert.ToInt32(ddlAccounts.SelectedValue));
            gvProducts.DataBind();
        }
        List<Product> ListProducts(int Catid) {
            SqlDataAdapter daProduct = new SqlDataAdapter("Select Pid, Product, c.Category, v.Vendor, Price, Quantity from ProductMaster p inner join Vendors v on v.vendorid=p.vendorid inner join categoryList c on c.catid = p.catid where c.catid=" + Catid, con);
            DataTable dtProducts = new DataTable();
            daProduct.Fill(dtProducts);
            List<Product> products = new List<Product>();
            foreach (DataRow r in dtProducts.Rows)
            {
                products.Add(new Product
                {
                    Id = Convert.ToInt32(r[0]),
                    ProductName = r[1].ToString(),
                    category = r[2].ToString(),
                    vendor = r[3].ToString(),
                    Quantity = Convert.ToInt32(r[4]),
                    price = Convert.ToDecimal(r[5]),
                });
             }
            ViewState["totalRecords"]=dtProducts.Rows.Count;
            return products.Skip((Convert.ToInt32(ViewState["currentPage"])*PageSize)).Take(PageSize).ToList();
        }

        protected void Btnnext_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(ViewState["currentPage"]) + 1;
            int Y = Convert.ToInt32(ViewState["totalRecords"]);
            if ((x * PageSize) < Y)
            {
                int currentPage = Convert.ToInt32(ViewState["currentPage"]);
                currentPage++;
                ViewState["currentPage"] = currentPage;
                gvProducts.DataSource = ListProducts(Convert.ToInt32(ddlAccounts.SelectedValue));
                gvProducts.DataBind();
            }
        }

        protected void Btnprev_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ViewState["currentPage"]) > 0)
            {
                int currentPage = Convert.ToInt32(ViewState["currentPage"]);
                currentPage--;
                ViewState["currentPage"] = currentPage;
                
                
            }
            gvProducts.DataSource = ListProducts(Convert.ToInt32(ddlAccounts.SelectedValue));
            gvProducts.DataBind();
        }
    }
}