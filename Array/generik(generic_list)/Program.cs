using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generik_generic_list_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> lst = new List<string>();
            // lst.Add("welcome");
            // lst.Add("hello");
            // string[] arr = { "oops", "dsa", "python" };
            // lst.AddRange(arr);

            //// lst.GetRange(2, 3); //2 is index and 3 is count
            // foreach (string s in lst)
            // {
            //     Console.WriteLine(s);
            // }
            // Console.ReadLine();
           

            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, Name = "Manoj", Department = "Admin", Slaray = 21000 });
            employees.Add(new Employee { Id = 2, Name = "Bharath", Department = "Productions", Slaray = 30000 });
            employees.Add(new Employee { Id = 3, Name = "Harshitha", Department = "Developer", Slaray = 34000 });
            employees.Add(new Employee { Id = 4, Name = "Indu", Department = "Finance", Slaray = 27000 });
            employees.Add(new Employee { Id = 5, Name = "Hima", Department = "Admin", Slaray = 21000 });
            employees.Add(new Employee { Id = 6, Name = "Prajwal", Department = "Testing", Slaray = 40000 });
            employees.Add(new Employee { Id = 7, Name = "Rahul", Department = "Production", Slaray = 45000 });


            Console.WriteLine("Count : " + employees.Count);
            Console.WriteLine("Capacity : " + employees.Capacity);
            Console.WriteLine("----------------------------------------------------------------");

            foreach (Employee e in employees)
            {
                Console.WriteLine("Id : " + e.Id);
                Console.WriteLine("Name : " + e.Name);
                Console.WriteLine("Department : " + e.Department);
                Console.WriteLine("Salary : " + e.Slaray);
                Console.WriteLine("--------------------------------------------------------------");
            }
            Console.WriteLine("----------------------------------------------------------");

            //Console.WriteLine("Enter the Department Name : ");
            //string dept = Console.ReadLine();
            //List<Employee> deptEmps = employees.Where(e => e.Department == dept).ToList();
            //if (deptEmps.Count > 0)
            //{
            //    foreach (Employee emp in deptEmps)
            //    {
            //        Console.WriteLine("Id : " + emp.Id);
            //        Console.WriteLine("Name : " + emp.Name);
            //        Console.WriteLine("Department : " + emp.Department);
            //        Console.WriteLine("Salary : " + emp.Slaray);
            //        Console.WriteLine("----------------------------------------------");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No Employees found in" + dept + "Department");
            //}

            Console.WriteLine("Enter the ID :");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee emp = employees.Find(e => e.Id == id);
            if (emp != null)
            {
                Console.WriteLine("Id : " + emp.Id);
                Console.WriteLine("Name : " + emp.Name);
                Console.WriteLine("Department : " + emp.Department);
                Console.WriteLine("Salary : " + emp.Slaray);

                Console.WriteLine("-----------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No Employees found in " + id);
            }
            Console.ReadLine();
        }
    }
}