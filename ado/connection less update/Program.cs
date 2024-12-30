using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connection_less_update
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=LAPTOP-CVVD6RP5;Initial catalog=school;User Id=sa;Password=Kodiyala@123 ";


            //connection less insertion 

            //    SqlDataAdapter da = new SqlDataAdapter("select * from Subjects", con);
            //    SqlCommandBuilder build = new SqlCommandBuilder(da);
            //    DataSet ds = new DataSet();
            //    da.Fill(ds, "Emp");
            //    Display(ds);

            //Add:
            //    DataRow r = ds.Tables[0].NewRow();

            //    Console.WriteLine("enter the subid");
            //    r[0] = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("enter the subname");
            //    r[1] = Console.ReadLine();
            //    ds.Tables[0].Rows.Add(r);
            //    Console.WriteLine("One row is added ; Do u want add more records : ");

            //    if (Console.ReadLine().ToLower().Equals("y"))
            //    {
            //        Console.WriteLine("-------------------------------------------");
            //        goto Add;
            //    }
            //    else
            //    {
            //        Display(ds);
            //        Console.WriteLine("Do u want to update the database : ");

            //        if (Console.ReadLine().ToLower().Equals("y"))
            //        {
            //            da.Update(ds.Tables[0]);
            //            Console.WriteLine("Your Database is upto date");
            //        }
            //        else
            //        {
            //            Console.WriteLine("The changes have been discarded");
            //        }
            //    }
            //    Console.ReadLine();
            //}
            //private static void Display(DataSet ds)
            //{
            //    Console.WriteLine("------------------------------------------------");
            //    foreach (DataRow r in ds.Tables[0].Rows)
            //    {
            //        foreach (DataColumn c in ds.Tables[0].Columns)
            //        {
            //            Console.WriteLine(r[c] + "\t");
            //        }
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine("-------------------------------------------------");
            //}

            //connection less update


            SqlDataAdapter da = new SqlDataAdapter("select * from Subjects", con);
            SqlCommandBuilder build = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Emp");
            Display(ds);

        Update:
            Console.WriteLine("enter the subid to update");
            int idtoupdate = Convert.ToInt32(Console.ReadLine());
            DataRow[] employeefound = ds.Tables[0].Select("subid=" + idtoupdate);
            if (employeefound.Length > 0)
            {
                Console.WriteLine("subid:" + employeefound[0][0]);
                Console.WriteLine("subname:" + employeefound[0][1]);
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("enter the subname");
                employeefound[0][1] = Console.ReadLine();
                Console.WriteLine("One row is added ; Do u want add more records : ");

                if (Console.ReadLine().ToLower().Equals("y"))
                {
                    Console.WriteLine("-------------------------------------------");
                    goto Update;
                }
                else
                {
                    Display(ds);
                    Console.WriteLine("Do u want to update the database : ");

                    if (Console.ReadLine().ToLower().Equals("y"))
                    {
                        da.Update(ds.Tables[0]);
                        Console.WriteLine("Your Database is upto date");
                    }
                    else
                    {
                        Console.WriteLine("The changes have been discarded");
                    }

                }



            }
            else
            {
                Console.WriteLine("enter the subid not found : "+idtoupdate);
                Console.WriteLine("do you contineue again :");
                if (Console.ReadLine().ToLower().Equals("y"))
                {
                    Console.WriteLine("-------------------------------------------");
                    goto Update;
                }
                else
                {
                    Console.WriteLine("thank you");
                    Display(ds);
                    Console.WriteLine("Do u want to update the database : ");

                    if (Console.ReadLine().ToLower().Equals("y"))
                    {
                        da.Update(ds.Tables[0]);
                        Console.WriteLine("Your Database is upto date");
                    }
                    else
                    {
                        Console.WriteLine("The changes have been discarded");
                    }
                }


            }
        }

            
            private static void Display(DataSet ds)
            {
                Console.WriteLine("------------------------------------------------");
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    foreach (DataColumn c in ds.Tables[0].Columns)
                    {
                        Console.WriteLine(r[c] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-------------------------------------------------");
            }
        }


    }
    

