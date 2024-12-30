using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;

namespace adding_twounKown_tablws
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=LAPTOP-CVVD6RP5;Initial catalog=Banking;User Id=sa;Password=Kodiyala@123 ";
            //SqlDataAdapter daacts = new SqlDataAdapter("select * from accounts",con);
            //SqlDataAdapter daacust = new SqlDataAdapter("select * from customers", con);

            //DataSet ds=new DataSet();
            //daacts.Fill(ds,"acts");
            //daacust.Fill(ds, "cust");

            //DataRelation drel=new DataRelation("actscust", ds.Tables["acts"].Columns["id"], ds.Tables["cust"].Columns["account"]);
            //ds.Relations.Add(drel);
            //foreach (DataRow row in ds.Tables[0].Rows) //[0] access through index
            //{
            //    Console.WriteLine("account id is : " + row[0]);
            //    Console.WriteLine("account type is : " + row[1]);
            //    foreach (DataRow cr in row.GetChildRows(drel))
            //    {
            //        Console.WriteLine("the name : " + cr[1]);
            //        Console.WriteLine("the address" + cr[2]);
            //        Console.WriteLine("the account : " + cr[3]);
            //    }
            //    Console.WriteLine("-------------------------------");
            //}




            SqlDataAdapter daacts = new SqlDataAdapter("select * from AccountTransactions", con);
            SqlDataAdapter daacust = new SqlDataAdapter("select * from customers", con);

            DataSet ds = new DataSet();
            daacts.Fill(ds, "acts");
            daacust.Fill(ds, "cust");

            DataRelation drel = new DataRelation("actscust", ds.Tables["cust"].Columns["accno"], ds.Tables["acts"].Columns["accno"]);
            ds.Relations.Add(drel);
            foreach (DataRow row in ds.Tables[1].Rows) //[0] access through index
            {
                Console.WriteLine("account no is : " + row[0]);
                Console.WriteLine("account holder name is : " + row[1]);
                long totalAmountwithdraw = 0;
                long totalAmountdeposite = 0;
                long balance = 0;
                
                foreach (DataRow cr in row.GetChildRows(drel))
                {
                    //Console.WriteLine("the withdraw/deposite : " + cr["ttype"]);

                    long amount = Convert.ToInt64(cr["Amount"]);
                    //totalAmount += amount;
                    int ttype = Convert.ToInt32(cr[4]);
                    if (ttype == 1) {
                        totalAmountdeposite += amount;
                    }
                    if (ttype == 2)
                    {
                        totalAmountwithdraw += amount;
                    }
                    Console.WriteLine("the transaction type is " + ttype + " and amount is " + amount);

                }
                Console.WriteLine("total amount withdraw is  : "+ totalAmountwithdraw);
                Console.WriteLine("total amount deposite is  : " + totalAmountdeposite);
                Console.WriteLine("********************************************************");
                balance = totalAmountdeposite- totalAmountwithdraw;
                Console.WriteLine("balance amount is : "+balance);
                Console.WriteLine("-------------------------------");


            }
            Console.ReadLine();

        }
    }
}
