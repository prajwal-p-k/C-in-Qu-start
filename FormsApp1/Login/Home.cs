using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Home : Form
    {
        SqlConnection con;
        string name;
        int id;
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        public int Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public Home()
        {
            con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=Banking; User Id = sa; Password = Kodiyala@123");
            con.Open();
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            labelname.Text = name;
            labelid.Text = "Well come";
            lblAccNo.Text = NextAccountNumber().ToString();

            // List Accounts

            cmbAccounts.DataSource = ListAccounts();

            cmbAccounts.DisplayMember = "Account";

            cmbAccounts.ValueMember = "Id";

        }
        int NextAccountNumber()
        {
            int accno = 0;
            SqlCommand cmdAccno = new SqlCommand("Select max(accno)+1 from customers", con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            accno = Convert.ToInt32(cmdAccno.ExecuteScalar());
            cmdAccno.Dispose();
            con.Close();
            return accno;

        }
        DataTable ListAccounts()
        {
            DataTable dtAccounts = new DataTable();
            SqlDataAdapter daActs = new SqlDataAdapter("Select Id, Account from Accounts", con);
            daActs.Fill(dtAccounts);
            daActs.Dispose();
            DataRow r = dtAccounts.NewRow();
            r[0] = -1;
            r[1] = "Choose Preferred Account";
            dtAccounts.Rows.InsertAt(r, 0);
            return dtAccounts;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtName, "Enter Name");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            if (txtAddress.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtAddress, "Enter Address");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            if (cmbAccounts.SelectedIndex == 0)
            {
                errorProvider1.SetError(cmbAccounts, "Choose Preferred Account");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            // Save
            int status = 0;
            if (cbStatus.Checked)
                status = 1;
            SqlCommand cmdSave = new SqlCommand();
            cmdSave.Connection = con;
            cmdSave.CommandText = "insert into Customers values(@accno, @name, @address, @account, @status)";
            SqlParameter paramAccno = new SqlParameter("@accno", SqlDbType.Int);
            SqlParameter paramName = new SqlParameter("@name", SqlDbType.VarChar, 40);
            SqlParameter paramAdd = new SqlParameter("@address", SqlDbType.VarChar, 40);
            SqlParameter paramAccount = new SqlParameter("@account", SqlDbType.Int);
            SqlParameter paramStatus = new SqlParameter("@status", SqlDbType.Int);

            cmdSave.Parameters.Add(paramAccno);
            cmdSave.Parameters.Add(paramName);
            cmdSave.Parameters.Add(paramAdd);
            cmdSave.Parameters.Add(paramAccount);
            cmdSave.Parameters.Add(paramStatus);

            paramAccno.Value = Convert.ToInt32(lblAccNo.Text);
            paramName.Value = txtName.Text;
            paramAdd.Value = txtAddress.Text;
            paramAccount.Value = Convert.ToInt32(cmbAccounts.SelectedValue);
            paramStatus.Value = status;

            if (con.State == ConnectionState.Closed)
                con.Open();
            if (cmdSave.ExecuteNonQuery() > 0)
            {
                lblMessage.Text = "Account has been opened for : " + txtName.Text + "\nAccount Number is : " + lblAccNo.Text;
                btnSave.Enabled = false;
            }
            else
            {
                lblMessage.Text = "Failed to open the account";
            }
            cmdSave.Dispose();
            con.Close();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            txtAddress.Text = "";
            txtName.Text = "";
            cmbAccounts.SelectedIndex = 0;
            lblAccNo.Text = NextAccountNumber().ToString();
            lblMessage.Text = "";
        }
    }
}
