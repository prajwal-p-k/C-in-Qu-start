using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace oops_concepts_
{
    abstract internal class Univercity
    {
        public Univercity() {
            Console.WriteLine("WELCOME TO VTU");
            Console.WriteLine("------------------------------");
        }

        public Univercity(string name)
        {
            Console.WriteLine("WELCOME TO VTU "+name+" college"  );
            Console.WriteLine("------------------------------");
        }

        public Univercity(string name,string add)
        {
            Console.WriteLine("WELCOME TO VTU " + name + " college in " + add);
            Console.WriteLine("------------------------------");
        }
        public  virtual List<string> syllabus() { 
             List<string> sub = new List<string>();
            sub.Add("web technology");
            sub.Add("maths");
            sub.Add("python");
            sub.Add("oops");
            sub.Add("dsa");
            sub.Add("IOT");
            return sub;
    }
        
        public abstract void Library(); //abstract methode
        public abstract string Princepal //abstract properties
        {
            set;
            get;
        }
        public void certification()
        {
            Console.WriteLine("the following subject to be certified");
            Console.WriteLine("----------------------------------------");
            foreach (string  a in syllabus())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("------------------------------");
            {
                
            }
        }
        
    }
}
