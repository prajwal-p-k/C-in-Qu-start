using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dropdwon
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string vendor { get; set; }
        public string category { get; set; }

        public int Quantity {  get; set; }
        public decimal price { get; set; }
    }
}