using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssetManagement
{
    public partial class ViewallAsset : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial Catalog=AssetsManagement; User Id=sa; Password=Kodiyala@123");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            try
            {
                string query = "SELECT asset_id, unique_number, asset_name, asset_type, purchase_date, warranty_period, price, status FROM asset";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    try
        //    {
        //        int assetId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        //        GridViewRow row = GridView1.Rows[e.RowIndex];

        //        // Get the updated values from the GridView
        //        string assetName = ((TextBox)row.FindControl("txtAssetName")).Text;
        //        string purchaseDateText = ((TextBox)row.FindControl("txtPurchaseDate")).Text;
        //        string warrantyPeriodText = ((TextBox)row.FindControl("txtWarrantyPeriod")).Text;
        //        string price = ((TextBox)row.FindControl("txtPrice")).Text;

        //        // Parse the purchase date to ensure it's in the correct format
        //        DateTime purchaseDate;
        //        if (!DateTime.TryParseExact(purchaseDateText, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out purchaseDate))
        //        {
        //            Response.Write("<script>alert('Invalid purchase date format. Please use dd/MM/yyyy.');</script>");
        //            return;
        //        }

        //        // Parse the warranty period date to ensure it's in the correct format
        //        DateTime warrantyPeriod;
        //        if (!DateTime.TryParseExact(warrantyPeriodText, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out warrantyPeriod))
        //        {
        //            Response.Write("<script>alert('Invalid warranty period format. Please use dd/MM/yyyy.');</script>");
        //            return;
        //        }

        //        // SQL update query
        //        string updateQuery = @"
        //    UPDATE asset 
        //    SET asset_name = @AssetName, 
        //        purchase_date = @PurchaseDate, 
        //        warranty_period = @WarrantyPeriod, 
        //        price = @Price
        //    WHERE asset_id = @AssetId";

        //        using (SqlCommand cmd = new SqlCommand(updateQuery, con))
        //        {
        //            cmd.Parameters.AddWithValue("@AssetName", assetName);
        //            cmd.Parameters.AddWithValue("@PurchaseDate", purchaseDate.ToString("yyyy-MM-dd"));  // Stored as yyyy-MM-dd in DB
        //            cmd.Parameters.AddWithValue("@WarrantyPeriod", warrantyPeriod.ToString("yyyy-MM-dd")); // Stored as yyyy-MM-dd in DB
        //            cmd.Parameters.AddWithValue("@Price", price);
        //            cmd.Parameters.AddWithValue("@AssetId", assetId);

        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }

        //        // Exit edit mode and rebind GridView
        //        GridView1.EditIndex = -1;
        //        BindGridView();
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert('Error: " + ex.Message.Replace("'", "\\'") + "');</script>");
        //    }
        //}\

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int assetId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                GridViewRow row = GridView1.Rows[e.RowIndex];

                // Get the updated values from the GridView
                string assetName = ((TextBox)row.FindControl("txtAssetName")).Text;
                string purchaseDateText = ((TextBox)row.FindControl("txtPurchaseDate")).Text;
                string warrantyPeriodText = ((TextBox)row.FindControl("txtWarrantyPeriod")).Text;
                string price = ((TextBox)row.FindControl("txtPrice")).Text;

                // Parse the purchase date to ensure it's in the correct format
                DateTime purchaseDate;
                if (!DateTime.TryParseExact(purchaseDateText, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out purchaseDate))
                {
                    Response.Write("<script>alert('Invalid purchase date format. Please use dd/MM/yyyy.');</script>");
                    return;
                }

                // Parse the warranty period date to ensure it's in the correct format
                DateTime warrantyPeriod;
                if (!DateTime.TryParseExact(warrantyPeriodText, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out warrantyPeriod))
                {
                    Response.Write("<script>alert('Invalid purchase date format. Please use dd/MM/yyyy.');</script>");
                    return;
                }

                // Save the date in 'yyyy-MM-dd' format to the database
                //cmd.Parameters.AddWithValue("@WarrantyPeriod", warrantyPeriod.ToString("yyyy-MM-dd"));


                // SQL update query
                string updateQuery = @"
            UPDATE asset 
            SET asset_name = @AssetName, 
                purchase_date = @PurchaseDate, 
                warranty_period = @WarrantyPeriod, 
                price = @Price
            WHERE asset_id = @AssetId";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@AssetName", assetName);
                    cmd.Parameters.AddWithValue("@PurchaseDate", purchaseDate.ToString("yyyy-MM-dd"));  // Stored as yyyy-MM-dd in DB
                    cmd.Parameters.AddWithValue("@WarrantyPeriod", warrantyPeriod.ToString("yyyy-MM-dd")); // Stored as yyyy-MM-dd in DB
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@AssetId", assetId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                // Exit edit mode and rebind GridView
                GridView1.EditIndex = -1;
                BindGridView();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message.Replace("'", "\\'") + "');</script>");
            }
        }






        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    try
        //    {
        //        int assetId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

        //        // Check if the asset is allocated
        //        string checkQuery = "SELECT COUNT(*) FROM asset_allocation WHERE unique_number = (SELECT unique_number FROM asset WHERE asset_id = @AssetId AND status = 'Allocated')";
        //        SqlCommand checkCmd = new SqlCommand(checkQuery, con);
        //        checkCmd.Parameters.AddWithValue("@AssetId", assetId);

        //        con.Open();
        //        int allocationCount = (int)checkCmd.ExecuteScalar();
        //        con.Close();

        //        if (allocationCount > 0)
        //        {
        //            Response.Write("<script>alert('Cannot delete: Asset is currently allocated.');</script>");
        //            return;
        //        }
        //        else
        //        {


        //            // Delete asset
        //            string deleteQuery = "DELETE FROM asset WHERE asset_id = @AssetId";
        //            SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);
        //            deleteCmd.Parameters.AddWithValue("@AssetId", assetId);

        //            con.Open();
        //            int count = deleteCmd.ExecuteNonQuery();
        //            if (count > 0)
        //            {
        //                con.Close();
        //            }
        //            else
        //            {
        //                // Corrected UPDATE statement
        //                string updateQuery = "UPDATE asset SET status = 'Deleted' WHERE asset_id = @AssetId";
        //                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
        //                updateCmd.Parameters.AddWithValue("@AssetId", assetId);

        //                con.Open();
        //                updateCmd.ExecuteNonQuery();
        //                Response.Write("<script>alert('Data is set to deleted');</script>");
        //                con.Close();
        //            }


        //            BindGridView();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
        //    }
        //}

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int assetId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

                // Check if the asset is allocated
                string checkQuery = @"
            SELECT COUNT(*)
            FROM asset_allocation
            WHERE unique_number = (
                SELECT unique_number 
                FROM asset 
                WHERE asset_id = @AssetId and status='Allocated'
            )";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@AssetId", assetId);

                    con.Open();
                    int allocationCount = (int)checkCmd.ExecuteScalar();
                    con.Close();

                    if (allocationCount > 0)
                    {
                        // Asset is allocated, cannot delete
                        Response.Write("<script>alert('Cannot delete: Asset is currently allocated.');</script>");
                        return;
                    }
                }

                // Retrieve the unique_number for the asset
                string uniqueNumberQuery = "SELECT unique_number FROM asset WHERE asset_id = @AssetId";
                string uniqueNumber = null;

                using (SqlCommand uniqueNumberCmd = new SqlCommand(uniqueNumberQuery, con))
                {
                    uniqueNumberCmd.Parameters.AddWithValue("@AssetId", assetId);

                    con.Open();
                    uniqueNumber = uniqueNumberCmd.ExecuteScalar()?.ToString();
                    con.Close();
                }

                if (string.IsNullOrEmpty(uniqueNumber))
                {
                    Response.Write("<script>alert('Asset not found.');</script>");
                    return;
                }

                // Attempt to delete the asset
                string deleteQuery = "DELETE FROM asset WHERE asset_id = @AssetId";
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con))
                {
                    deleteCmd.Parameters.AddWithValue("@AssetId", assetId);

                    con.Open();
                    try
                    {
                        deleteCmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Asset deleted successfully.');</script>");
                    }
                    catch (SqlException ex)
                    {
                        con.Close();

                        // If deletion fails due to foreign key constraints, update the status to 'Deleted'
                        if (ex.Number == 547) // Foreign key violation error code in SQL Server
                        {
                            string updateQuery = "UPDATE asset SET status = 'Deleted' WHERE asset_id = @AssetId";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                            {
                                updateCmd.Parameters.AddWithValue("@AssetId", assetId);

                                con.Open();
                                updateCmd.ExecuteNonQuery();
                                con.Close();

                                Response.Write("<script>alert('Asset is linked to other records. Status updated to Deleted.');</script>");
                            }
                        }
                        else
                        {
                            throw; // Rethrow if it's not a foreign key violation
                        }
                    }
                }

                // Rebind the GridView to refresh data
                BindGridView();
            }
            catch (Exception ex)
            {
                con.Close(); // Ensure the connection is closed in case of an exception
                Response.Write("<script>alert('Error: " + ex.Message.Replace("'", "\\'") + "');</script>");
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
       

    }
}