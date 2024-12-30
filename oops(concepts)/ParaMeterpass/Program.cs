using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaMeterpass
{
    internal class Program
    {
        //int calcilate( int a,  int b)
        //int calcilate(ref int a,ref int b) //with refernce keyword ref
         int calcilate(out int a, out int b)  //it is output reference methode
        {
            a = 200;
            b = 100;
            Console.WriteLine("---------------------------------");
            Console.WriteLine("the a value is: " + a);
            Console.WriteLine("the b value is: " + b);
            Console.WriteLine("---------------------------------");
            a = a + b;
            b = 2 * a - b;
            Console.WriteLine("---------------------------------");
            Console.WriteLine("the a value is: " + a);
            Console.WriteLine("the b value is: " + b);
            Console.WriteLine("---------------------------------");
            return a + b;

        }

        static void Main(string[] args)
        {
            Program pro = new Program();
            Console.WriteLine("enter the A value : ");
            int x=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the B value : ");
            int y = Convert.ToInt32(Console.ReadLine());
            //int res=pro.calcilate(ref x,ref y); //not both X and Y are reference type one can be refernce one can be normal
            //int res=pro.calcilate( x, y);//with out refernce
            int res = pro.calcilate(out x, out y);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("the result value is: " + res);
            
            Console.WriteLine("---------------------------------");
            Console.WriteLine("*****************************************");
            Console.WriteLine("the a value is: " + x);
            Console.WriteLine("the b value is: " + y);
            Console.WriteLine("*****************************************");
            Console.ReadLine();


        }
    }
}
