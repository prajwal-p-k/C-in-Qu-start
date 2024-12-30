using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssetManagement
{
    public partial class AddRole : Page
    {
        private string connectionString = @"Data Source=LAPTOP-CVVD6RP5; Initial catalog=AssetsManagement; User Id=sa; Password=Kodiyala@123";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string roleName1 = roleName.Text.Trim();

            if (!string.IsNullOrEmpty(roleName1))
            {
                AddRoleToDatabase(roleName1);
                roleName.Text = "";
                BindGrid();
            }
            else
            {
                Response.Write("<script>alert('Role name is required.');</script>");
            }
        }

        private void AddRoleToDatabase(string roleName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO roles (role_name) VALUES (@RoleName)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@RoleName", roleName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        private void BindGrid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT role_id, role_name FROM roles";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvRoles.DataSource = dt;
                    gvRoles.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void gvRoles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvRoles.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvRoles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int roleId = Convert.ToInt32(gvRoles.DataKeys[e.RowIndex].Value);
            string roleName = (gvRoles.Rows[e.RowIndex].FindControl("txtEditRoleName") as TextBox).Text;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE roles SET role_name = @RoleName WHERE role_id = @RoleId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@RoleName", roleName);
                        cmd.Parameters.AddWithValue("@RoleId", roleId);
                        cmd.ExecuteNonQuery();
                    }
                }
                gvRoles.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void gvRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int roleId = Convert.ToInt32(gvRoles.DataKeys[e.RowIndex].Value);

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM roles WHERE role_id = @RoleId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@RoleId", roleId);
                        cmd.ExecuteNonQuery();
                    }
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void gvRoles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvRoles.EditIndex = -1;
            BindGrid();
        }
    }
}
