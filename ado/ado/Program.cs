using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Security.Principal;
using System.Data.Common;

namespace ado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=LAPTOP-CVVD6RP5;Initial catalog=Banking;User Id=sa;Password=Kodiyala@123 ";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;


            ////reading from data base

            //cmd.CommandText = "select * from employee1";
            //SqlDataReader dataReader = cmd.ExecuteReader();
            //if (dataReader.HasRows)
            //{
            //    while (dataReader.Read())
            //    {
            //        for (int c = 0; c < dataReader.FieldCount; c++)
            //        {
            //            Console.Write(dataReader[c] + "\t");

            //        }
            //        Console.WriteLine();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No record found");
            //}

            ////write to data base
            ///
            //cmd.CommandText = "insert into employee1 values(@name,@dep,@gender,@dob,@doj,@sal)";
            //SqlParameter paramname = new SqlParameter("@name",SqlDbType.VarChar,30);
            //SqlParameter paramdep = new SqlParameter("@dep", SqlDbType.VarChar, 30);
            //SqlParameter paramgender = new SqlParameter("@gender", SqlDbType.VarChar, 1);
            //SqlParameter paramdob = new SqlParameter("@dob", SqlDbType.VarChar, 30);
            //SqlParameter paramdoj = new SqlParameter("@doj", SqlDbType.VarChar, 30);
            //SqlParameter paramsal = new SqlParameter("@sal", SqlDbType.Money);

            //cmd.Parameters.Add(paramname);
            //cmd.Parameters.Add(paramdep);
            //cmd.Parameters.Add(paramgender);
            //cmd.Parameters.Add(paramdob);
            //cmd.Parameters.Add(paramdoj);
            //cmd.Parameters.Add(paramsal);

            //Console.Write("name : ");
            //paramname.Value =Console.ReadLine();
            //Console.Write("dep : ");
            //paramdep.Value = Console.ReadLine();
            //Console.Write("gender : ");
            //paramgender.Value = Console.ReadLine();
            //Console.Write("dob : ");
            //paramdob.Value = Console.ReadLine();
            //Console.Write("doj : ");
            //paramdoj.Value = Console.ReadLine();
            //Console.Write("sal : ");
            //paramsal.Value = Console.ReadLine();


            //int result=cmd.ExecuteNonQuery();
            //if (result > 0)
            //{
            //    Console.WriteLine("A new employee has been added ");

            //}
            //else
            //{
            //    Console.WriteLine("employee registration is faild ");
            //}



            ///update operation
            ///

            // Console.Write("ID : ");
            //int id = Convert.ToInt32(Console.ReadLine());

            // SqlCommand cmdchuser = new SqlCommand();
            // cmdchuser.Connection = con;
            // cmdchuser.CommandText = "select count(*) from employee1 where id=" + id;
            // object res=cmdchuser.ExecuteScalar();
            // cmdchuser.Dispose();

            // if (Convert.ToInt32(res) > 0)
            // {
            //     SqlCommand cmd = new SqlCommand();
            //     cmd.Connection = con;

            //     cmd.CommandText = "update employee1 set employeename=@name,department=@dep,gender=@gender,dob=@dob,doj=@doj,salary=@sal where id=@id";
            //     SqlParameter paramname = new SqlParameter("@name", SqlDbType.VarChar, 30);
            //     SqlParameter paramdep = new SqlParameter("@dep", SqlDbType.VarChar, 30);
            //     SqlParameter paramgender = new SqlParameter("@gender", SqlDbType.VarChar, 1);
            //     SqlParameter paramdob = new SqlParameter("@dob", SqlDbType.VarChar, 30);
            //     SqlParameter paramdoj = new SqlParameter("@doj", SqlDbType.VarChar, 30);
            //     SqlParameter paramsal = new SqlParameter("@sal", SqlDbType.Money);
            //     SqlParameter paramid = new SqlParameter("@id", SqlDbType.Int);

            //     cmd.Parameters.Add(paramname);
            //     cmd.Parameters.Add(paramdep);
            //     cmd.Parameters.Add(paramgender);
            //     cmd.Parameters.Add(paramdob);
            //     cmd.Parameters.Add(paramdoj);
            //     cmd.Parameters.Add(paramsal);
            //     cmd.Parameters.Add(paramid);

            //     paramid.Value = id;

            //     Console.Write("name : ");
            //     paramname.Value = Console.ReadLine();
            //     Console.Write("dep : ");
            //     paramdep.Value = Console.ReadLine();
            //     Console.Write("gender : ");
            //     paramgender.Value = Console.ReadLine();
            //     Console.Write("dob : ");
            //     paramdob.Value = Console.ReadLine();
            //     Console.Write("doj : ");
            //     paramdoj.Value = Console.ReadLine();
            //     Console.Write("sal : ");
            //     paramsal.Value = Console.ReadLine();


            //     int result = cmd.ExecuteNonQuery();
            //     if (result > 0)
            //     {
            //         Console.WriteLine("A employee has been updated ");

            //     }
            //     else
            //     {
            //         Console.WriteLine("employee update is faild ");
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("user does not exit");
            // }



            ///store proceedure
            ///

            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandText = "splistemp";
            //cmd.CommandType=CommandType.StoredProcedure;


            //SqlParameter paramdep=new SqlParameter("@dep",SqlDbType.VarChar,30);
            //SqlParameter paramsal = new SqlParameter("@sal", SqlDbType.Money);
            //cmd.Parameters.Add(paramdep);
            //cmd.Parameters.Add(paramsal);

            //Console.WriteLine("enter the department");
            //paramdep.Value=Console.ReadLine();
            //Console.WriteLine("enter the salary");
            //paramsal.Value=Convert.ToInt64(Console.ReadLine());
            //SqlDataReader reader = cmd.ExecuteReader();

            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        for (int i = 0; i < reader.FieldCount; i++)
            //        {
            //            Console.Write(reader[i] + "\t");
            //        }
            //        Console.WriteLine();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("no record found");
            //}

            ///procedure with output parameter
            ///

            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandText = "splistemp";
            //cmd.CommandType = CommandType.StoredProcedure;


            //SqlParameter paramdep = new SqlParameter("@dep", SqlDbType.VarChar, 30);
            //SqlParameter paramsal = new SqlParameter("@sal", SqlDbType.Money);
            //SqlParameter paramcout = new SqlParameter("@count", SqlDbType.Int);
            //cmd.Parameters.Add(paramdep);
            //cmd.Parameters.Add(paramsal);
            //cmd.Parameters.Add(paramcout);
            //paramcout.Direction = ParameterDirection.Output; // ReturnValue; //Output; //default its input only


            //Console.WriteLine("enter the department");
            //paramdep.Value = Console.ReadLine();
            //Console.WriteLine("enter the salary");
            //paramsal.Value = Convert.ToInt64(Console.ReadLine());
            //SqlDataReader reader = cmd.ExecuteReader();

            //Console.WriteLine("total count is "+ paramcout.Value);






            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Data Source=QUSTRATMYS013; Initial catalog=banking; User Id=sa; Password=2369";
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;

            cmd.CommandText = "AddNewCust";//name of stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramAccno = new SqlParameter("@accno", SqlDbType.Int);
            SqlParameter paramName = new SqlParameter("@name", SqlDbType.VarChar, 30);
            SqlParameter paramAddress = new SqlParameter("@Address", SqlDbType.VarChar, 30);
            SqlParameter paramAccount = new SqlParameter("@Account", SqlDbType.Int);
            SqlParameter paramstatus = new SqlParameter("@status", SqlDbType.Int);
            SqlParameter paramaction = new SqlParameter("@action", SqlDbType.Int);

            cmd.Parameters.Add(paramAccno);
            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramAddress);
            cmd.Parameters.Add(paramAccount);
            cmd.Parameters.Add(paramstatus);
            cmd.Parameters.Add(paramaction);

            Console.Write("Enter the accno : ");
            paramAccno.Value = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter the  name :");
            paramName.Value = Console.ReadLine();
            Console.Write("Enter the  Address : ");
            paramAddress.Value = Console.ReadLine();
            Console.Write("Enter the Account : ");
            paramAccount.Value = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter the Status : ");
            paramstatus.Value = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter the Action : ");
            paramaction.Value = Convert.ToDecimal(Console.ReadLine());
            

            int rea = cmd.ExecuteNonQuery();

           if(rea > 0)
            {
                Console.WriteLine("one row effected");

            }
            else
            {
                Console.WriteLine("not database updated");
            }

            con.Close();
        }
    }
}
