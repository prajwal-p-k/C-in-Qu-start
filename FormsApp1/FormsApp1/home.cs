using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp1
{
    public partial class home : Form
    {
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

        public home()
        {
            InitializeComponent();
        }

        private void home_Load(object sender, EventArgs e)
        {
            lblname.Text = name;
        }


    }
}
