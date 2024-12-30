using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accessmodifier;

namespace Assembly2
{
    class Program:Department
    {
        static void Main(string[] args)
        {
            Program pg=new Program();
            pg.ListDepartment();

            Department dep=new Department();
            dep.ListDepartment();
        }
    }
}
