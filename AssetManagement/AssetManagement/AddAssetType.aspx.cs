using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssetManagement
{
    public partial class AddAssetType : Page
    {
        // Connection string for your database
        private string connectionString = @"Data Source=LAPTOP-CVVD6RP5; Initial Catalog=AssetsManagement; User Id=sa; Password=Kodiyala@123";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAssetTypes();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string assetTypeNameValue = assetTypeName.Text.Trim();

            if (!string.IsNullOrEmpty(assetTypeNameValue))
            {
                AddAssetTypeToDatabase(assetTypeNameValue);
                LoadAssetTypes(); // Refresh the list of asset types
            }
            else
            {
                Response.Write("<script>alert('Asset Type name is required.');</script>");
            }
        }

        private void AddAssetTypeToDatabase(string assetTypeNameValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO AssetType (type_name) VALUES (@TypeName)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@TypeName", assetTypeNameValue);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        private void LoadAssetTypes()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM AssetType";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        gvAssetTypes.DataSource = dt;
                        gvAssetTypes.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void gvAssetTypes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAssetTypes.EditIndex = e.NewEditIndex;
            LoadAssetTypes();
        }

        protected void gvAssetTypes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvAssetTypes.Rows[e.RowIndex];
            string oldAssetTypeName = gvAssetTypes.DataKeys[e.RowIndex].Value.ToString();
            string newAssetTypeName = ((TextBox)row.Cells[0].Controls[0]).Text.Trim();

            if (!string.IsNullOrEmpty(newAssetTypeName))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "UPDATE AssetType SET type_name = @NewTypeName WHERE type_name = @OldTypeName";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@NewTypeName", newAssetTypeName);
                            cmd.Parameters.AddWithValue("@OldTypeName", oldAssetTypeName);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Asset Type name cannot be empty.');</script>");
            }

            gvAssetTypes.EditIndex = -1;
            LoadAssetTypes();
        }

        protected void gvAssetTypes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAssetTypes.EditIndex = -1;
            LoadAssetTypes();
        }

        protected void gvAssetTypes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string assetTypeName = gvAssetTypes.DataKeys[e.RowIndex].Value.ToString();
            DeleteAssetType(assetTypeName);
            LoadAssetTypes();
        }

        private void DeleteAssetType(string assetTypeName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM AssetType WHERE type_name = @TypeName";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@TypeName", assetTypeName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
    }
}
