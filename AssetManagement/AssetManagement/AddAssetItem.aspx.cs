using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssetManagement
{
    public partial class AddAssetItem : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=AssetsManagement; User Id=sa; Password=Kodiyala@123");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlAccounts.DataSource = Listcategory();
                ddlAccounts.DataTextField = "type_name";
                ddlAccounts.DataValueField = "id";
                ddlAccounts.DataBind();
                BindGrid();
            }
        }

        DataTable Listcategory()
        {
            SqlDataAdapter daAccounts = new SqlDataAdapter("SELECT id, type_name FROM AssetType", con);
            DataTable dtActs = new DataTable();
            daAccounts.Fill(dtActs);

            DataRow r = dtActs.NewRow();
            r[0] = 0;
            r[1] = "Your preferred category";
            dtActs.Rows.InsertAt(r, 0);
            return dtActs;
        }

        DataTable ListAssetItems()
        {
            SqlDataAdapter daItems = new SqlDataAdapter("SELECT id, item_name, asset_type_id FROM AssetItem", con);
            DataTable dtItems = new DataTable();
            daItems.Fill(dtItems);
            return dtItems;
        }

        protected void BindGrid()
        {
            gvAssetItems.DataSource = ListAssetItems();
            gvAssetItems.DataBind();
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            int assetTypeId = int.Parse(ddlAccounts.SelectedValue);
            string itemName = txtItemName.Text.Trim();

            if (assetTypeId > 0 && !string.IsNullOrEmpty(itemName))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO AssetItem (asset_type_id, item_name) VALUES (@assetTypeId, @itemName)", con);
                cmd.Parameters.AddWithValue("@assetTypeId", assetTypeId);
                cmd.Parameters.AddWithValue("@itemName", itemName);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", "showMessage('Asset item added successfully!', true);", true);

                    txtItemName.Text = "";
                    ddlAccounts.SelectedIndex = 0;
                    BindGrid();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", "showMessage('Error: " + ex.Message + "', false);", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ValidationMessage", "showMessage('Please select a valid asset type and enter the item name.', false);", true);
            }
        }

        protected void gvAssetItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvAssetItems.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM AssetItem WHERE id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", "showMessage('Asset item deleted successfully!', true);", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", "showMessage('Error: " + ex.Message + "', false);", true);
            }
        }

        protected void gvAssetItems_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAssetItems.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvAssetItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvAssetItems.DataKeys[e.RowIndex].Value);
            string itemName = (gvAssetItems.Rows[e.RowIndex].FindControl("txtEditItemName") as TextBox).Text;
            int assetTypeId = Convert.ToInt32((gvAssetItems.Rows[e.RowIndex].FindControl("ddlEditAssetType") as DropDownList).SelectedValue);

            SqlCommand cmd = new SqlCommand("UPDATE AssetItem SET item_name = @itemName, asset_type_id = @assetTypeId WHERE id = @id", con);
            cmd.Parameters.AddWithValue("@itemName", itemName);
            cmd.Parameters.AddWithValue("@assetTypeId", assetTypeId);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                gvAssetItems.EditIndex = -1;
                BindGrid();
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", "showMessage('Asset item updated successfully!', true);", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", "showMessage('Error: " + ex.Message + "', false);", true);
            }
        }

        protected void gvAssetItems_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAssetItems.EditIndex = -1;
            BindGrid();
        }

        protected void gvAssetItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlEditAssetType");
                ddl.DataSource = Listcategory();
                ddl.DataTextField = "type_name";
                ddl.DataValueField = "id";
                ddl.DataBind();

                string assetTypeId = DataBinder.Eval(e.Row.DataItem, "asset_type_id").ToString();
                ddl.SelectedValue = assetTypeId;
            }
        }
    }
}
