using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssetManagement
{
    public partial class Home : System.Web.UI.Page
    {
        // HttpCookie ck;
        //protected string UserName { get; set; }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=AssetsManagement; User Id = sa; Password = Kodiyala@123");
        protected void Page_Load(object sender, EventArgs e)
        {


            // Retrieve the username from the query string
            HttpCookie ck = Request.Cookies["qu"];
            //UserName = Request.QueryString["user"];
                if (ck!=null)
                {
                lblWelcome.InnerHtml = "WelCome, " + ck["user"].ToString();
                }
                else
                {
                lblWelcome.InnerHtml = "Welcome!";
                }
            if (!IsPostBack) // Ensure data binding happens only on the first page load
            {
                DropDownList1.DataSource = Listcategory();
                DropDownList1.DataTextField = "type_name";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();

                // Assuming a default id of 0 for the initial load
                DropDownList2.DataSource = Listcategory1(0);
                DropDownList2.DataTextField = "item_name";
                DropDownList2.DataValueField = "id";
                DropDownList2.DataBind();
            }

         




        }
        DataTable Listcategory()
        {
            SqlDataAdapter daAccounts = new SqlDataAdapter("select id,type_name from AssetType", con);
            DataTable dtActs = new DataTable();
            daAccounts.Fill(dtActs);
            DataRow r = dtActs.NewRow();
            r[0] = 0;
            r[1] = "your prefferd asset Type";
            dtActs.Rows.InsertAt(r, 0);
            return dtActs;
        }

        //DataTable EmployeeName()
        //{
        //    SqlDataAdapter daAccounts = new SqlDataAdapter("select employee_id,name from employee", con);
        //    DataTable dtActs = new DataTable();
        //    daAccounts.Fill(dtActs);
        //    DataRow r = dtActs.NewRow();
        //    r[0] = 0;
        //    r[1] = "your prefferd Name";
        //    dtActs.Rows.InsertAt(r, 0);
        //    return dtActs;
        //}
        DataTable Listcategory1(int id)
        {
            SqlDataAdapter daAccounts = new SqlDataAdapter("select id,item_name from AssetItem where asset_type_id=" + id, con);
            DataTable dtActs = new DataTable();
            daAccounts.Fill(dtActs);
            DataRow r = dtActs.NewRow();
            r[0] = 0;
            r[1] = "your prefferd Item";
            dtActs.Rows.InsertAt(r, 0);
            return dtActs;
        }

        //DataTable UNNU(int id)
        //{
        //    SqlDataAdapter daAccounts = new SqlDataAdapter("select id,unique_number from AssetItem where asset_type_id=" + id, con);
        //    DataTable dtActs = new DataTable();
        //    daAccounts.Fill(dtActs);
        //    DataRow r = dtActs.NewRow();
        //    r[0] = 0;
        //    r[1] = "your prefferd Item";
        //    dtActs.Rows.InsertAt(r, 0);
        //    return dtActs;
        //}
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.DataSource = Listcategory1(Convert.ToInt32(DropDownList1.SelectedValue));
            DropDownList2.DataBind();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);

        }
        protected void Btnsubmitassetdata_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve values from controls
                string uniqueNumber = assetNo.Value;
                string assetName = DropDownList2.SelectedItem.Text;
                string assetType = DropDownList1.SelectedItem.Text;

                // Parse purchase date with the specified format
                DateTime purchaseDate;
                if (!DateTime.TryParseExact(assetpdate.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out purchaseDate))
                {
                    throw new Exception("Invalid purchase date format. Expected format is dd/MM/yyyy.");
                }

                // Parse warranty date if provided
                DateTime? warrantyDate = string.IsNullOrEmpty(assetwdate.Value) ? (DateTime?)null :
                    DateTime.TryParseExact(assetwdate.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tempWarrantyDate) ? (DateTime?)tempWarrantyDate : null;

                decimal price = Convert.ToDecimal(assetprice.Value);
                int createdByEmployeeId = Convert.ToInt32(Session["id"]); // Example ID

                // Define SQL query with parameters
                string query = @"INSERT INTO asset (
        unique_number, asset_name, asset_type, purchase_date, warranty_period, price, created_by_employee_id
    ) VALUES (
        @uniqueNumber, @assetName, @assetType, @purchaseDate, @warrantyPeriod, @price, @createdByEmployeeId
    )";

                // Create SQL command
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters to the command
                    cmd.Parameters.AddWithValue("@uniqueNumber", uniqueNumber);
                    cmd.Parameters.AddWithValue("@assetName", assetName);
                    cmd.Parameters.AddWithValue("@assetType", assetType);
                    cmd.Parameters.AddWithValue("@purchaseDate", purchaseDate);

                    // Handle nullable warranty period
                    if (warrantyDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@warrantyPeriod", warrantyDate.Value.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@warrantyPeriod", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@createdByEmployeeId", createdByEmployeeId);

                    // Open connection
                    con.Open();

                    // Execute query and check result
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Close connection
                    con.Close();

                    // Notify based on rows affected
                    if (rowsAffected > 0)
                    {
                        // Notify success
                        string successMessage = "Inserted successfully";
                        string script = $"alert('{successMessage}');";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    }
                    else
                    {
                        // Notify insertion failure
                        string failureMessage = "Insertion failed";
                        string script = $"alert('{failureMessage}');";
                        ClientScript.RegisterStartupScript(this.GetType(), "FailureMessage", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                // Notify error using a popup
                string errorMessage = $"Error: {ex.Message}";
                string script = $"alert('{errorMessage}');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);
            }


        }

        //{
        //    Response.Redirect("login.aspx");
        //}
        protected void BtnsubmitUserdata_Click(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}