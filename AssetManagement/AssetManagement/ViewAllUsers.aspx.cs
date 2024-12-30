using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssetManagement
{
    public partial class ViewAllUsers : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial Catalog=AssetsManagement; User Id=sa; Password=Kodiyala@123");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        private DataTable GetRoles()
        {
            DataTable dtRoles = new DataTable();
            try
            {
                string query = "SELECT role_name FROM roles"; // Query to fetch roles
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dtRoles);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error fetching roles: " + ex.Message + "');</script>");
            }
            return dtRoles;
        }


        private void BindGridView()
        {
            try
            {
                string query = "SELECT employee_id, name, role, email, phone, password, created_time FROM employee";
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
            // Set the row in edit mode.
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView(); // Re-bind to display the dropdown in the edit mode.

            // Access the row being edited.
            GridViewRow row = GridView1.Rows[e.NewEditIndex];

            // Find the Label containing the current role in the ItemTemplate.
            Label lblRole = row.FindControl("lblRole") as Label;

            if (lblRole != null)
            {
                string currentRole = lblRole.Text; // Get the role value.

                // Find the DropDownList in the EditItemTemplate.
                DropDownList ddlRole = row.FindControl("ddlRole") as DropDownList;
                if (ddlRole != null)
                {
                    // Bind the dropdown to available roles.
                    DataTable dtRoles = GetRoles(); // Fetch roles from the database or list.
                    ddlRole.DataSource = dtRoles;
                    ddlRole.DataTextField = "role_name";
                    ddlRole.DataValueField = "role_name";
                    ddlRole.DataBind();

                    // Set the current role as selected in the dropdown.
                    ddlRole.Items.Insert(0, new ListItem("Select role", ""));
                    ddlRole.SelectedValue = currentRole;
                }
            }
            else
            {
                //Response.Write("<script>alert('Error: lblRole not found.');</script>");
            }
        }





        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int employeeId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                GridViewRow row = GridView1.Rows[e.RowIndex];

                string name = ((TextBox)row.Cells[1].Controls[0]).Text;
                DropDownList ddlRole = (DropDownList)row.FindControl("ddlRole");
                string role = ddlRole.SelectedValue;
                string email = ((TextBox)row.Cells[3].Controls[0]).Text;
                string phone = ((TextBox)row.Cells[4].Controls[0]).Text;
                string password = ((TextBox)row.Cells[5].Controls[0]).Text;
                int updated_by_employee_id = Convert.ToInt32(Session["id"]);

                string updateQuery = @"UPDATE employee 
                               SET name = @Name, 
                                   role = @Role, 
                                   email = @Email, 
                                   phone = @Phone, 
                                   password = @Password, 
                                   updated_by_employee_id = @UpdatedBy, 
                                   updated_time = GETDATE() 
                               WHERE employee_id = @EmployeeID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@UpdatedBy", updated_by_employee_id);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                GridView1.EditIndex = -1;
                BindGridView();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
            {
                // Find the DropDownList in the EditItemTemplate.
                DropDownList ddlRole = e.Row.FindControl("ddlRole") as DropDownList;
                if (ddlRole != null)
                {
                    // Fetch the roles and bind to the dropdown.
                    DataTable dtRoles = GetRoles(); // Fetch roles from the database.
                    ddlRole.DataSource = dtRoles;
                    ddlRole.DataTextField = "role_name";
                    ddlRole.DataValueField = "role_name";
                    ddlRole.DataBind();

                    // Get the current role from the row's data item.
                    string currentRole = DataBinder.Eval(e.Row.DataItem, "role").ToString();
                    ddlRole.Items.Insert(0, new ListItem("Select role", ""));
                    ddlRole.SelectedValue = currentRole;
                }
            }
        }





        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}
