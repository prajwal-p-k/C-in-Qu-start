using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagement
{
    public class Product
    {
        public int allocation_id { get; set; }
        public string employee_name { get; set; } // Updated to include employee name
        public DateTime allocation_date { get; set; }
        public DateTime? return_date { get; set; }
        public string status { get; set; }
        public string note { get; set; }
    }

}