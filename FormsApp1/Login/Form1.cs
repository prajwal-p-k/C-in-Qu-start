using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
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
        public Form1()
        {
            con=new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=Banking; User Id = sa; Password = Kodiyala@123");
            con.Open();
            InitializeComponent();
        }

        bool IsValidUser(string email, string pwd)
        {
            bool isUserValid = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.CommandText = "Select Id, name from AppUser where email = '" + email + "' and password = '" + pwd + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                Name = dr[1].ToString();
                dr.Close();
                isUserValid = true;
            }
            con.Close();
            return isUserValid;
        }


        

        private void btnsave_Click(object sender, EventArgs e)
        {

            if (txtemail.Text.Length == 0)
            {
                errorProvider1.SetError(txtemail, "Enter the mail ID");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (txtpassword.Text.Length == 0)
            {
                errorProvider1.SetError(txtpassword, "Enter the Password");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (IsValidUser(txtemail.Text.Trim(), txtpassword.Text.Trim()))
            {
                Home hm = new Home();
                hm.Name = name;
                hm.Id = id;
                hm.Show();
                this.Hide();
            }
            else
            {
                labelerror.Text = "Login Failed";
                labelerror.ForeColor = Color.Red;
            }


        }

        private void btncancle_Click_1(object sender, EventArgs e)
        {
            txtemail.Text = "";
            txtpassword.Text = "";
            txtemail.Focus();
            errorProvider1.Clear();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
