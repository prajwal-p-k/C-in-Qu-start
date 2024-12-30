using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Simplecode
{
    internal class Program
    {
        int id = 90;
        string name;
        bool isProject;
        double salary;

        public int Id
        {
            set;
            get;
        }
        public string EmployeeName
        {
            set
            {
                name = value;


            }
            get
            {
                return name;
            }
        }
        public bool ISproject
        {
            set
            {
                isProject = value;
            }
            get
            {
                return isProject;
            }
        }
        public double Salary
        {
            get { return salary; }
            set
            {
                Salary = value;
            }
        }
        public int Noofcausalleav //read only property
        {
            get
            {
                return 7;
            }
        }
        public int seackleaves
        {
            get
            {
                return seackleaves;
            }
            private set
            {
                seackleaves = value;
            }
        }
        Program()
        {
            Console.WriteLine("enri media");
        }
        Program(string org)
        {
            Console.WriteLine("the employee belong to" + org);
        }
        Program(string org,string name)
        {
            Console.WriteLine("the employee belong to" + org+" name is "+name);
        }
        void login(string org)
        {
            Console.WriteLine("the employee belong to" + org);
        }
        double login(double salary)
        {
            return salary;
        }
        ~Program()
        {
            Console.WriteLine("deallacting with destroctor" );

        }

        static void Main(string[] args)
        {
            Console.WriteLine("hello word");
        }
    }
}
