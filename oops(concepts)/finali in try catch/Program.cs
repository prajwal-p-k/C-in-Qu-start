using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace finali_in_try_catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isValid = false;
            try
            {
                Console.WriteLine("mobile number : ");
                long mob = Convert.ToInt64(Console.ReadLine());
                isValid = true;
                return;
            }
            catch (Exception ex) {
                //Console.WriteLine("mobile number : ");
                //long mob = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("invalid mobile number");
                return;

            }
            finally  //finally is mainly used for import part in code .for example closeing file,compalsory excicution .if after the cath block  function not garenty of exictution but finaly is garenty of exictution .if its error in catch /return in try or catch also it exicuted
            {
                Console.WriteLine("code clean up is happend");
            }
            if (isValid)
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" Your registration is successful!!!");
                
                Console.WriteLine("-------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Registration Failed");
            }
            Console.ReadLine();

        }
    }
}
