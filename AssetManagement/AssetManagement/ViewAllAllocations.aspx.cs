using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssetManagement
{
    public partial class ViewAllAllocations : Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=AssetsManagement; User Id=sa; Password=Kodiyala@123");

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
                //string query = @"SELECT 
                //                    allocation_id, 
                //                    employee_id, 
                //                    unique_number, 
                //                    allocation_date, 
                //                    return_date, 
                //                    status, 
                //                    note 
                //                 FROM asset_allocation";

                string query = @"SELECT  allocation_id, e.name, unique_number, 
                                    allocation_date, 
                                    return_date, 
                                    status, 
                                    note 
                                 FROM asset_allocation a inner join employee e on e.employee_id=a.employee_id";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    // Display an empty row if no data is found
                    dt.Rows.Add(dt.NewRow());
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    GridView1.Rows[0].Cells.Clear();
                    GridView1.Rows[0].Cells.Add(new TableCell
                    {
                        ColumnSpan = dt.Columns.Count,
                        Text = "No Records Found",
                        HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center
                    });
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during data retrieval
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}
