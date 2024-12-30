using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

public class AssetService
{
    // Connection string
    private static string connectionString = @"Data Source=LAPTOP-CVVD6RP5; Initial catalog=AssetsManagement; User Id = sa; Password = Kodiyala@123";

    [WebMethod]
    public static string GetAllAssets()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT asset_id, unique_number, asset_name, asset_type, purchase_date, warranty_period, price, status FROM asset";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    return "{\"error\": \"No data found\"}";  // Return an error if no data is found
                }

                string result = "[";
                foreach (DataRow row in dt.Rows)
                {
                    result += "{";
                    result += $"\"asset_id\": \"{row["asset_id"]}\",";
                    result += $"\"unique_number\": \"{row["unique_number"]}\",";
                    result += $"\"asset_name\": \"{row["asset_name"]}\",";
                    result += $"\"asset_type\": \"{row["asset_type"]}\",";
                    result += $"\"purchase_date\": \"{row["purchase_date"]}\",";
                    result += $"\"warranty_period\": \"{row["warranty_period"]}\",";
                    result += $"\"price\": \"{row["price"]}\",";
                    result += $"\"status\": \"{row["status"]}\"";
                    result += "},";
                }

                if (result.EndsWith(","))
                {
                    result = result.Substring(0, result.Length - 1); // Remove last comma
                }

                result += "]";
                return result;
            }
        }
        catch (Exception ex)
        {
            return "{\"error\": \"" + ex.Message + "\"}";
        }
    }

}
