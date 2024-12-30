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
    public partial class Home1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=AssetsManagement; User Id=sa; Password=Kodiyala@123");

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie ck = Request.Cookies["qu"];
            //lblWelcome.InnerHtml = ck != null ? $"Welcome, {ck["user"]}" : "Welcome!";

            if (!IsPostBack)
            {
                DropDownList1.DataSource = Listcategory();
                DropDownList1.DataTextField = "type_name";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();

                DropDownList2.DataSource = Listcategory1(0);
                DropDownList2.DataTextField = "item_name";
                DropDownList2.DataValueField = "id";
                DropDownList2.DataBind();
            }
        }

        private DataTable Listcategory()
        {
            SqlDataAdapter daAccounts = new SqlDataAdapter("SELECT id, type_name FROM AssetType", con);
            DataTable dtActs = new DataTable();
            daAccounts.Fill(dtActs);
            DataRow r = dtActs.NewRow();
            r[0] = 0;
            r[1] = "Your Preferred Asset Type";
            dtActs.Rows.InsertAt(r, 0);
            return dtActs;
        }

        private DataTable Listcategory1(int id)
        {
            SqlDataAdapter daAccounts = new SqlDataAdapter($"SELECT id, item_name FROM AssetItem WHERE asset_type_id={id}", con);
            DataTable dtActs = new DataTable();
            daAccounts.Fill(dtActs);
            DataRow r = dtActs.NewRow();
            r[0] = 0;
            r[1] = "Your Preferred Item";
            dtActs.Rows.InsertAt(r, 0);
            return dtActs;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.DataSource = Listcategory1(Convert.ToInt32(DropDownList1.SelectedValue));
            DropDownList2.DataBind();
        }

        protected void Btnsubmitassetdata_Click(object sender, EventArgs e)
        {
            try
            {
                string uniqueNumber = assetNo.Value;
                string assetName = DropDownList2.SelectedItem.Text;
                string assetType = DropDownList1.SelectedItem.Text;

                if (!DateTime.TryParseExact(assetpdate.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime purchaseDate))
                {
                    throw new Exception("Invalid purchase date format. Use dd/MM/yyyy.");
                }

                DateTime? warrantyDate = null;
                if (!string.IsNullOrWhiteSpace(assetwdate.Value))
                {
                    if (!DateTime.TryParseExact(assetwdate.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tempWarrantyDate))
                    {
                        throw new Exception("Invalid warranty date format. Use dd/MM/yyyy.");
                    }
                    if (tempWarrantyDate <= purchaseDate)
                    {
                        throw new Exception("Warranty date must be greater than purchase date.");
                    }
                    warrantyDate = tempWarrantyDate;
                }

                decimal price = Convert.ToDecimal(assetprice.Value);
                int createdByEmployeeId = Convert.ToInt32(Session["id"]);

                string query = @"INSERT INTO asset (unique_number, asset_name, asset_type, purchase_date, warranty_period, price, created_by_employee_id) 
                        VALUES (@uniqueNumber, @assetName, @assetType, @purchaseDate, @warrantyPeriod, @price, @createdByEmployeeId)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@uniqueNumber", uniqueNumber);
                    cmd.Parameters.AddWithValue("@assetName", assetName);
                    cmd.Parameters.AddWithValue("@assetType", assetType);
                    cmd.Parameters.AddWithValue("@purchaseDate", purchaseDate);
                    cmd.Parameters.AddWithValue("@warrantyPeriod", (object)warrantyDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@createdByEmployeeId", createdByEmployeeId);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    string message = rowsAffected > 0 ? "Inserted successfully" : "Insertion failed";
                    ClientScript.RegisterStartupScript(this.GetType(), "Notification", $"alert('{message}');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", $"alert('Error: {ex.Message}');", true);
            }
        }


        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}
