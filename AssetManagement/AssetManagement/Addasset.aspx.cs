using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssetManagement
{
    public partial class Addasset : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=AssetsManagement; User Id = sa; Password = Kodiyala@123");
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Ensure data binding happens only on the first page load
            {
                DropDownList1.DataSource = Listcategory();
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "employee_id";
                DropDownList1.DataBind();

                DropDownList2.DataSource = Listcategory1();
                DropDownList2.DataTextField = "unique_number_name";
                DropDownList2.DataValueField = "asset_id";
                DropDownList2.DataBind();
            }
        }

        DataTable Listcategory()
        {
            SqlDataAdapter daAccounts = new SqlDataAdapter("SELECT employee_id, name FROM employee", con);
            DataTable dtActs = new DataTable();
            daAccounts.Fill(dtActs);
            DataRow r = dtActs.NewRow();
            r[0] = 0;
            r[1] = "Select Employee ";
            dtActs.Rows.InsertAt(r, 0);
            return dtActs;
        }

        DataTable Listcategory1()
        {
            SqlDataAdapter daAccounts = new SqlDataAdapter(@"
            SELECT asset_id, CONCAT(unique_number, '-', asset_name) AS unique_number_name
            FROM Asset
            WHERE status = 'Available'", con);
            DataTable dtActs = new DataTable();
            daAccounts.Fill(dtActs);
            DataRow r = dtActs.NewRow();
            r[0] = 0;
            r[1] = "Select the Asset Number";
            dtActs.Rows.InsertAt(r, 0);
            return dtActs;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DropDownList2.DataSource = Listcategory1(Convert.ToInt32(DropDownList1.SelectedValue));
            //DropDownList2.DataBind();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DropDownList2.DataSource = Listcategory1(Convert.ToInt32(DropDownList1.SelectedValue));
            //DropDownList2.DataBind();
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if (DropDownList1.SelectedValue == "0" || DropDownList2.SelectedValue == "0")
        //    {
        //        lbl.InnerHtml = "Please select a valid employee and Asset Number.";
        //        return;
        //    }

        //    try
        //    {
        //        string uniqueNumber = DropDownList2.SelectedItem.Text.Split('-')[0]; // Extract unique_number
        //        int employeeId = int.Parse(DropDownList1.SelectedValue);

        //       // DateTime allocationDate = DateTime.Parse(assetpdate.Value);
        //        string inputDate = assetpdate.Value;
        //        DateTime allocationDate = DateTime.ParseExact(inputDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);


        //        string note = note1.Value; // Adjust control name if different
        //        int allottedByEmployeeId = int.Parse(Session["id"].ToString());

        //        string allocationQuery = @"
        //        INSERT INTO asset_allocation (
        //            employee_id, unique_number, allocation_date, note, alloted_by_employee_id
        //        ) VALUES (
        //            @employeeId, @uniqueNumber, @allocationDate, @note, @allottedByEmployeeId
        //        )";

        //        string updateAssetStatusQuery = @"
        //        UPDATE asset
        //        SET status = 'Allocated'
        //        WHERE unique_number = @uniqueNumber";

        //        con.Open();
        //        using (SqlTransaction transaction = con.BeginTransaction())
        //        {
        //            try
        //            {
        //                using (SqlCommand cmd = new SqlCommand(allocationQuery, con, transaction))
        //                {
        //                    cmd.Parameters.AddWithValue("@employeeId", employeeId);
        //                    cmd.Parameters.AddWithValue("@uniqueNumber", uniqueNumber);
        //                    cmd.Parameters.AddWithValue("@allocationDate", allocationDate);
        //                    cmd.Parameters.AddWithValue("@note", note);
        //                    cmd.Parameters.AddWithValue("@allottedByEmployeeId", allottedByEmployeeId);
        //                    cmd.ExecuteNonQuery();
        //                }

        //                using (SqlCommand cmd = new SqlCommand(updateAssetStatusQuery, con, transaction))
        //                {
        //                    cmd.Parameters.AddWithValue("@uniqueNumber", uniqueNumber);
        //                    cmd.ExecuteNonQuery();
        //                }

        //                transaction.Commit();
        //                lbl.InnerHtml = "<span style='color: green;'>Asset allocated successfully.</span>";

        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                lbl.InnerHtml = "Error during allocation: " + ex.Message;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lbl.InnerHtml = "Database connection error: " + ex.Message;
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
                lbl.InnerHtml = "Please select a valid employee and Asset Number.";
                return;
            }

            try
            {
                string uniqueNumber = DropDownList2.SelectedItem.Text.Split('-')[0]; // Extract unique_number
                int employeeId = int.Parse(DropDownList1.SelectedValue);

                string inputDate = assetpdate.Value;
                DateTime allocationDate = DateTime.ParseExact(inputDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                string note = note1.Value; // Adjust control name if different
                int allottedByEmployeeId = int.Parse(Session["id"].ToString());

                // Check if the asset is already allocated
                string checkAssetStatusQuery = @"
        SELECT status FROM asset WHERE unique_number = @uniqueNumber";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(checkAssetStatusQuery, con))
                {
                    cmd.Parameters.AddWithValue("@uniqueNumber", uniqueNumber);
                    object statusObj = cmd.ExecuteScalar();

                    if (statusObj != null && statusObj.ToString() != "Available")
                    {
                        lbl.InnerHtml = "<span style='color: red;'>This asset is already allocated to someone else.</span>";
                        return;
                    }
                }

                // Proceed with allocation if the asset is available
                string allocationQuery = @"
        INSERT INTO asset_allocation (
            employee_id, unique_number, allocation_date, note, alloted_by_employee_id
        ) VALUES (
            @employeeId, @uniqueNumber, @allocationDate, @note, @allottedByEmployeeId
        )";

                string updateAssetStatusQuery = @"
        UPDATE asset
        SET status = 'Allocated'
        WHERE unique_number = @uniqueNumber";

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(allocationQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@employeeId", employeeId);
                            cmd.Parameters.AddWithValue("@uniqueNumber", uniqueNumber);
                            cmd.Parameters.AddWithValue("@allocationDate", allocationDate);
                            cmd.Parameters.AddWithValue("@note", note);
                            cmd.Parameters.AddWithValue("@allottedByEmployeeId", allottedByEmployeeId);
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd = new SqlCommand(updateAssetStatusQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@uniqueNumber", uniqueNumber);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        lbl.InnerHtml = "<span style='color: green;'>Asset allocated successfully.</span>";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        lbl.InnerHtml = "Error during allocation: " + ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                lbl.InnerHtml = "Database connection error: " + ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}
