using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops_concepts_
{
    internal class Collage : Univercity
    {
        int intmark;

        static Collage()
        {
            Console.WriteLine("well come");
            Console.WriteLine("*****************************");
        }
        //public Collage():base("ait")  //it will call parameterize constructore in base class at the time of this constructore call
        //{
        //    Console.WriteLine("welcome to ait");
        //    Console.WriteLine("------------------------------");
        //}
        public Collage() {

            intmark = 20;
            Console.WriteLine("student internal marks is"+intmark);
            Console.WriteLine("------------------------------");

        }
        public Collage(Collage c)
        {
            Console.WriteLine("student internal marks is Rahul" + c.intmark);

        }
        public Collage(string add):base("ait","mysore")
        {
            Console.WriteLine("welcome to ait in "+add);
            Console.WriteLine("------------------------------");
        }


        public void ListofSUB()
        {
            foreach (string s in base.syllabus()) //we use base.  ,,it will give first preference
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("------------------------------");
        }


           public override  List<string> syllabus()  //methode hiding
            {
                List<string> sub = new List<string>();
                sub.Add("Ms SQL Server");
                sub.Add("DOT.Net");
                sub.Add("recat");
                sub.Add("css");
                sub.Add("HTML");
                sub.Add("boostrap");
                return sub;
            }
         
        
        public sealed override void Library() //sealed connot allow for forther overhide
        {
            Console.WriteLine("welcome to qu-strat library");
        }
       
        public override string Princepal
        {
            set
            {

            }
            get
            {
                return "Dr Kari Siddappa";
            }
        }
        public static int passmark
        {
            get
            {
                return 40;
            }
        }
    }
}
