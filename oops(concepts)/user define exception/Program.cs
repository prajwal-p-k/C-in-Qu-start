using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_define_exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter your name :");
            string name = Console.ReadLine();
            Console.WriteLine("enter your reg no :");
            int reg = Convert.ToInt32(Console.ReadLine());
            if (reg % 2 == 0 && DateTime.Now.Hour < 13 || reg % 2 != 0 && DateTime.Now.Hour > 13)
            {
                try
                {
                    throw new InvalidSlotException();
                }
                catch (InvalidSlotException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("error at :" + e.StackTrace);
                    Console.WriteLine("---------------------------");
                    e.Reason();
                }
            }
            else
            {
                 Console.WriteLine("All the Best : " + name);
                Console.WriteLine("********************************");
            }
        }
    }
}
