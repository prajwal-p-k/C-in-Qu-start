using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace accessmodifier
{
    class Employee : Department //inherting because it protected in base class

    {
        const int x = 10;
        const int y =x; //if x also be static other wise it will error
        const int passMarks = 40; //the constent value assign at the time of declareation and then connot be changed
        readonly int maxmarks=60;
        Employee()
        {
            //passMarks = 40; //not possible
            maxmarks = 50;
           
        }
        void getdetails()
        {
            const int mark= 50; //local constants
            //readonly int internal = 60;  
            Department dep = new Department();
            dep.ListDepartment(); //it connot access the private properties of parent class  and proctected member connot access througth the object of class
            //and above can accessed by the name of internal name
            ListDepartment(); //inherited child class from parentclass througth methode belong to child class
        }
        void getinfo()
        {
            getdetails();
            Leaves();
            Console.WriteLine("payroll management");
        }
        static void Leaves()

        {
            
            Console.WriteLine("the employee can have 20 leaves");
        }
        static void insurance()
        {
            // getdetails() //not acessed 

            Employee emp = new Employee();
            emp.getdetails(); //an instence can be accessed througth the object of the class in static methode
            Leaves(); //static methode is invoked in static
            Console.WriteLine("the application max in three member in family");
        }


        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.ListDepartment();
            Console.ReadLine();

        }
    }
  
}
