using System.Data;
using System.Data.SqlClient;
namespace FormsApp1
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
            con = new SqlConnection(@"Data Source=LAPTOP-CVVD6RP5; Initial catalog=Banking; User Id = sa; Password = Kodiyala@123");
            con.Open();
            InitializeComponent();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    if (emailbox.Text.Length == 0)
        //    {
        //        errorProvider1.SetError(emailbox, "Enter the mail ID");
        //        return;
        //    }
        //    else
        //    {
        //        errorProvider1.Clear();
        //    }
        //    if (passwordbox.Text.Length == 0)
        //    {
        //        errorProvider2.SetError(passwordbox, "Enter the Password");
        //        return;
        //    }
        //    else
        //    {
        //        errorProvider2.Clear();
        //    }
        //    if (IsValidUser(emailbox.Text.Trim(), passwordbox.Text.Trim()))
        //    {
        //        home hm = new home();
        //        hm.Name = name;
        //        hm.Id = id;
        //        hm.Show();
        //        this.Hide();
        //    }
        //    else
        //    {
        //        labelerror.Text = "Login Failed";
        //        labelerror.ForeColor = Color.Red;
        //    }
        //}


        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void ButtonSave(object sender, EventArgs e)
        {
            if (emailbox.Text.Length == 0)
            {
                errorProvider1.SetError(emailbox, "Enter the email Id");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (passwordbox.Text.Length == 0)
            {
                errorProvider1.SetError(passwordbox, "enter the password");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (IsValidUser(emailbox.Text.Trim(), passwordbox.Text.Trim()))
            {
                home hm = new home();
                hm.Name = name;
                hm.Id = id;
                hm.Show();
                this.Hide();
            }
            else
            {
                labelerror.Text = "login failed";
                 labelerror.ForeColor = Color.Red;
            }
        }

        //bool IsValidUser(string email, string pwd)
        //{
        //    bool isUserValid = false;
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    if (con.State == ConnectionState.Closed)
        //        con.Open();
        //    cmd.CommandText = "Select Id, name from AppUser where email = '" + email + "' and password = '" + pwd + "'";
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        dr.Read();
        //        Id = Convert.ToInt32(dr[0]);
        //        Name = dr[1].ToString();
        //        dr.Close();
        //        isUserValid = true;
        //    }
        //    con.Close();
        //    return isUserValid;
        //}

        bool IsValidUser(string email, string pwd)
        {
            bool isUserValid = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.CommandText = "Select Id, name from AppUser where Email = '" + email + "' and password = '" + pwd + "'";
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


    }
}
