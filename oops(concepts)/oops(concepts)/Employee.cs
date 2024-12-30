using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops_concepts_
{
    internal class Employee
    {
        int id;
        string name;
        public Employee() {
            Console.WriteLine("employee application managment");
            Console.WriteLine("---------------------------------------");
        }
        public Employee(string name)
        {
            Console.WriteLine("employee name " + name);

        }
        public Employee(int id, string name) //operator overloading
        {
            this.id = id; //the instance value is equal to parameter value this is helps to access out side the constrocture
            Console.WriteLine("employee name " + name);
            Console.WriteLine("employee id is  " + id);
        }
        public void login() {
            Console.WriteLine("the employee logged at time: " + DateTime.Now.ToString());
            Console.WriteLine("employee id is  " + id);

        }
        public void login(string name)
        {
            Console.WriteLine("the employee logged at time: " + DateTime.Now.ToString());
            Console.WriteLine("employee id is  " + id);
            Console.WriteLine("employee name " + name);

        }
        /// <summary>
        /// sumary to login
        /// </summary>
        /// <param name="name"> name of employee </param>
        /// <param name="bactch"> batch of employee </param>
        /// 

        public int login(string name,int bactch)
        {
            Console.WriteLine("the employee logged at time: " + DateTime.Now.ToString());
            Console.WriteLine("employee id is  " + id);
            Console.WriteLine("employee name " + name);
            Console.WriteLine("employee batch is  " + bactch);
            return bactch;

        }

    }
}
