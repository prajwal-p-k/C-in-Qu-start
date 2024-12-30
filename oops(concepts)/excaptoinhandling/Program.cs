using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excaptoinhandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    Console.WriteLine("Write your name : ");
            //    string name = Console.ReadLine();
            //mobile:
            //    try
            //    {
            //        Console.WriteLine("Enter your mobile number : ");
            //        long mobile = Convert.ToInt64(Console.ReadLine());

            //        Console.WriteLine("------------------------------------------");
            //        Console.WriteLine(name + " Your registration is successfull!!!!");
            //        Console.WriteLine("------------------------------------------");
            //    }
            //    catch {
            //        Console.WriteLine("---------------------------------------------");
            //        Console.WriteLine(name + " Your registration is failed );");
            //        Console.WriteLine("Invalid mobile number");
            //        Console.WriteLine("-------------------------------------------");
            //        Console.WriteLine("Do you want to retry : ");
            //        if(Console.ReadLine().ToLower().Equals("y"))
            //        {
            //            goto mobile;
            //        }
            //        else
            //        {
            //            Console.WriteLine("You may try later");
            //        }
            //    }
            //    Console.ReadLine();
            int courseId = -1;
            bool isValid = false;
            string courseChosen = "";
            string[] options = { "Computer Science", "Civil", "Information Science", "Mechanical", "Chemical", "Polymer Science", "Electronics and Communication" };
            Console.WriteLine("Enter your name : ");
            string name = Console.ReadLine();
        mobile:
            try
            {
                Console.WriteLine("Enter your mobile number : ");
                long mobile = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Your preferred course : ");
                courseId = Convert.ToInt32(Console.ReadLine());
                courseChosen = options[courseId];
                isValid = true;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                Console.WriteLine(fe.StackTrace);
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(name + " your registration has failed");
                Console.WriteLine("Invalid mobile number");
                Console.WriteLine("---------------------------------------------");
                
                Console.WriteLine("Do you want to retry ; ");
                if (Console.ReadLine().ToLower().Equals("y"))
                {
                    goto mobile;
                }
                else
                {
                    Console.WriteLine("You may try later");
                }
                isValid = false;
            }
            catch (ArgumentOutOfRangeException ae)
            {
                Console.WriteLine("Invalid course chosen");
                isValid = false;
            }
            if (isValid)
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(name + " Your registration is successful!!!");
                Console.WriteLine(name + " You have registered for " + courseChosen);
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
