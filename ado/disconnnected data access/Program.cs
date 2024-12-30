using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace disconnnected_data_access
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=LAPTOP-CVVD6RP5;Initial catalog=master;User Id=sa;Password=Kodiyala@123 ";
            //SqlDataAdapter da= new SqlDataAdapter("select * from employee1",con);
            //SqlDataAdapter da1 = new SqlDataAdapter("select * from payments", con);
            //DataSet ds = new DataSet();
            //da.Fill(ds,"Emp");
            //da1.Fill(ds,"Dept"); //dep are datatable

            //Console.WriteLine("connection satate"+con.State);
            //Console.WriteLine("------------------------");

            //foreach (DataRow r in ds.Tables[0].Rows) //we aslo specifiy the name inside of [1] like emp or dept
            //{
            //    foreach (DataColumn c in ds.Tables[0].Columns)  //[1] or [0] if 0 meanes emp and 1 meanes [dept]
            //    {
            //        Console.Write(r[c] + "\t ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine("------------------------");
            //Console.WriteLine("connection satate" + con.State);
            //Console.ReadLine();


            SqlDataAdapter da = new SqlDataAdapter("select * from marks", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Emp");
            Display(ds);

        Add:
            DataRow r = ds.Tables[0].NewRow();
            Console.WriteLine("enter the stdid");
            r[0] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the subid");
            r[1] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the marks");
            r[2] = Convert.ToInt32(Console.ReadLine());

            ds.Tables[0].Rows.Add(r);
            Console.WriteLine("do you want to add one more record");
            if (Console.ReadLine().ToLower() == "yes")
            {
                Console.WriteLine("-----------------");
                goto Add;
            }
            else
            {
                Display(ds);
                Console.WriteLine("do you want to upadete to data base");
                if (Console.ReadLine().ToLower() == "yes")
                {
                    da.Update(ds.Tables[0]);
                    Console.WriteLine("added");
                }
                else
                {
                    Console.WriteLine("your data id discrad");
                }
            }
        }



            private static void Display(DataSet ds)
            {
                Console.WriteLine("---------------------------------");
                foreach (DataRow r in ds.Tables[0].Rows)     //0 for the emp and 1 for pays
                {
                    foreach (DataColumn c in ds.Tables[0].Columns)
                    {
                        Console.Write(r[c] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("----------------------------------------");
            }


        }
    }

