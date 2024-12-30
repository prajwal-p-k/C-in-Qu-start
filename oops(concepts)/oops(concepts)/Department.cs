using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops_concepts_
{
    internal class Department:Collage
    {
        public void Info()
        {
            Console.WriteLine("welcome to department of computer science and enginerring");
        }

        //public override void Library() //sealed connot allow for forther overhide
        //{
        //    Console.WriteLine("welcome to qu-strat library");
        //}
    }
}
