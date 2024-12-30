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
    public partial class RetunAsset : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=AssetsManagement; User Id = sa; Password = Kodiyala@123");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Ensure data binding happens only on the first page load
            {
                DropDownList1.DataSource = ListUsersWithAllocatedAssets();
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "employee_id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("Select User", "0"));

                DropDownList2.Items.Insert(0, new ListItem("Select Asset", "0"));
            }
        }

        DataTable ListUsersWithAllocatedAssets()
        {
            SqlDataAdapter daUsers = new SqlDataAdapter(@"
                SELECT DISTINCT e.employee_id, e.name
                FROM employee e
                JOIN asset_allocation aa ON e.employee_id = aa.employee_id
                WHERE aa.status = 'Allocated'", con);
            DataTable dtUsers = new DataTable();
            daUsers.Fill(dtUsers);
            return dtUsers;
        }

        DataTable ListAllocatedAssetsForUser(int employeeId)
        {
            SqlDataAdapter daAssets = new SqlDataAdapter(@"
                SELECT a.asset_id, CONCAT(a.unique_number, ' - ', a.asset_name) AS unique_asset
                FROM asset a
                JOIN asset_allocation aa ON a.unique_number = aa.unique_number
                WHERE aa.employee_id = @employeeId AND aa.status = 'Allocated'", con);

            daAssets.SelectCommand.Parameters.AddWithValue("@employeeId", employeeId);
            DataTable dtAssets = new DataTable();
            daAssets.Fill(dtAssets);
            return dtAssets;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int employeeId = int.Parse(DropDownList1.SelectedValue);

            if (employeeId > 0)
            {
                DropDownList2.DataSource = ListAllocatedAssetsForUser(employeeId);
                DropDownList2.DataTextField = "unique_asset"; // Show concatenated value
                DropDownList2.DataValueField = "asset_id";    // Bind the ID as value
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("Select Asset", "0"));
            }
            else
            {
                DropDownList2.Items.Clear();
                DropDownList2.Items.Insert(0, new ListItem("Select Asset", "0"));
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if (DropDownList1.SelectedValue == "0" || DropDownList2.SelectedValue == "0")
        //    {
        //        lbl.InnerHtml = "Please select a valid user and asset.";
        //        return;
        //    }

        //    try
        //    {
        //        string uniqueNumber = DropDownList2.SelectedItem.Text.Split('-')[0].Trim(); // Extract unique_number
        //        //DateTime returnDate = DateTime.Parse(assetpdate.Value);
        //        string inputDate = assetpdate.Value;
        //        DateTime returnDate = DateTime.ParseExact(inputDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

        //        string note = note1.Value;
        //        int deallottedByEmployeeId = int.Parse(Session["id"].ToString());

        //        // Update the asset status to 'Available'
        //        string updateAssetStatusQuery = @"
        //            UPDATE asset
        //            SET status = 'Available'
        //            WHERE unique_number = @uniqueNumber";

        //        // Update the asset_allocation table's status to 'Returned' and set the return date
        //        string updateAssetAllocationQuery = @"
        //            UPDATE asset_allocation
        //            SET status = 'Returned', return_date = @returnDate, dealloted_by_employee_id = @deallottedByEmployeeId
        //            WHERE unique_number = @uniqueNumber AND status = 'Allocated'";

        //        con.Open();
        //        using (SqlTransaction transaction = con.BeginTransaction())
        //        {
        //            try
        //            {
        //                // Update the asset status in the asset table
        //                using (SqlCommand cmd = new SqlCommand(updateAssetStatusQuery, con, transaction))
        //                {
        //                    cmd.Parameters.AddWithValue("@uniqueNumber", uniqueNumber);
        //                    cmd.ExecuteNonQuery();
        //                }

        //                // Update the asset allocation status to 'Returned' in the asset_allocation table
        //                using (SqlCommand cmd = new SqlCommand(updateAssetAllocationQuery, con, transaction))
        //                {
        //                    cmd.Parameters.AddWithValue("@uniqueNumber", uniqueNumber);
        //                    cmd.Parameters.AddWithValue("@returnDate", returnDate);
        //                    cmd.Parameters.AddWithValue("@deallottedByEmployeeId", deallottedByEmployeeId);
        //                    cmd.ExecuteNonQuery();
        //                }

        //               // transaction.Commit();
        //                transaction.Commit();
        //                lbl.InnerHtml = "<span class='text-success'>Asset Returned successfully.</span>";

        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                lbl.InnerHtml = "Error during asset return: " + ex.Message;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lbl.InnerHtml = "Error: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //    }
        //}
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "0" || DropDownList2.SelectedValue == "0")
            {
                lbl.InnerHtml = "Please select a valid user and asset.";
                return;
            }

            try
            {
                string uniqueNumber = DropDownList2.SelectedItem.Text.Split('-')[0].Trim(); // Extract unique_number
                string inputDate = assetpdate.Value;
                DateTime returnDate = DateTime.ParseExact(inputDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                string note = note1.Value;
                int deallottedByEmployeeId = int.Parse(Session["id"].ToString());

                // Fetch the allocation date
                string fetchAllocationDateQuery = @"
            SELECT allocation_date 
            FROM asset_allocation 
            WHERE unique_number = @uniqueNumber AND status = 'Allocated'";

                DateTime allocationDate;

                con.Open();
                using (SqlCommand cmd = new SqlCommand(fetchAllocationDateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@uniqueNumber", uniqueNumber);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        allocationDate = Convert.ToDateTime(result);
                    }
                    else
                    {
                        lbl.InnerHtml = "Allocation data not found for the selected asset.";
                        return;
                    }
                }

                // Validate return date
                if (returnDate < allocationDate)
                {
                    lbl.InnerHtml = "Return date must be greater than or equal to the allocation date.";
                    return;
                }

                // Update the asset status to 'Available'
                string updateAssetStatusQuery = @"
            UPDATE asset
            SET status = 'Available'
            WHERE unique_number = @uniqueNumber";

                // Update the asset_allocation table's status to 'Returned' and set the return date
                string updateAssetAllocationQuery = @"
            UPDATE asset_allocation
            SET status = 'Returned', return_date = @returnDate, dealloted_by_employee_id = @deallottedByEmployeeId
            WHERE unique_number = @uniqueNumber AND status = 'Allocated'";

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Update the asset status in the asset table
                        using (SqlCommand cmd = new SqlCommand(updateAssetStatusQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@uniqueNumber", uniqueNumber);
                            cmd.ExecuteNonQuery();
                        }

                        // Update the asset allocation status to 'Returned' in the asset_allocation table
                        using (SqlCommand cmd = new SqlCommand(updateAssetAllocationQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@uniqueNumber", uniqueNumber);
                            cmd.Parameters.AddWithValue("@returnDate", returnDate);
                            cmd.Parameters.AddWithValue("@deallottedByEmployeeId", deallottedByEmployeeId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        lbl.InnerHtml = "<span class='text-success'>Asset Returned successfully.</span>";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        lbl.InnerHtml = "Error during asset return: " + ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                lbl.InnerHtml = "Error: " + ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        // Add the Button2_Click event handler for the "Close" button
        protected void Button2_Click(object sender, EventArgs e)
        {
            // You can either redirect to another page or use JavaScript to close the window
            // For now, I'll use a JavaScript redirect for closing the form
            //ClientScript.RegisterStartupScript(this.GetType(), "closeWindow", "window.close();", true); 
            Response.Redirect("Home.aspx");
        }
    }
}
