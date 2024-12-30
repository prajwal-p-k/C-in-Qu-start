using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops_concepts_
{
    struct AICT
    {
        int passmark;
        string name;
        void Norms()
        {
            Console.WriteLine("Following are the norms of the AICET");
        }
        AICT(string add)
        {
            passmark = 40;
            name="";
            Console.WriteLine("AICET located at : " + add);
        }
        public string Department
        {
            get {
                return "ADMISSION";
                    }
        }
        static void Main(string[] args) // in a program can have only one main methode
        {
            AICT a=new AICT("Mandya");
            object obj = a; //boxing converting value type to refernce type
            a = (AICT)obj; //agin unboxing it boxes tyes are only unbox not all reffernce type

            Employee e=new Employee();
            // int cc = e; //not work because all reffernce are converted to box

            int x = 10;
            object v = x; //boxing
            int y =(int)v; //unboxing
            a.Norms();
            Console.WriteLine();
            Collage collage = new Collage(); //structure can call any class with the main methode
            collage.certification();
            Console.ReadLine();
        }
    }
}
