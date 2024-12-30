using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssetManagement
{
    public partial class Aset : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRolesDropdown();
            }
        }

        private void BindRolesDropdown()
        {
            string connectionString = @"Data Source=LAPTOP-CVVD6RP5; Initial catalog=AssetsManagement; User Id = sa; Password = Kodiyala@123";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT role_id, role_name FROM roles";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DropDownList1.Items.Clear();
                            DropDownList1.Items.Add(new ListItem("Select Role", ""));

                            while (reader.Read())
                            {
                                DropDownList1.Items.Add(new ListItem(
                                    reader["role_name"].ToString(),
                                    reader["role_id"].ToString()
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error fetching roles: " + ex.Message + "');</script>");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = userName.Text.Trim();
            string roleId = DropDownList1.SelectedItem.Text;
            string email = userEmail.Text.Trim();
            string phone = userPhone.Text.Trim();
            string password = userPassword.Text.Trim();

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(roleId) &&
                !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(password))
            {
                AddUser(name, roleId, email, phone, password);
            }
            else
            {
                Response.Write("<script>alert('All fields are required.');</script>");
            }
        }

        private void AddUser(string name, string roleId, string email, string phone, string password)
        {
            string connectionString = @"Data Source=LAPTOP-CVVD6RP5; Initial catalog=AssetsManagement; User Id = sa; Password = Kodiyala@123";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO employee (name, role, email, phone, password) VALUES (@Name, @Role, @Email, @Phone, @Password)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Role", roleId); // Storing role_id as role
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('User added successfully!');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Failed to add user.');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}

