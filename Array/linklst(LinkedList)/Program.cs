using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linklst_LinkedList_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            list.AddFirst("a");
            list.AddFirst("b");
            list.AddFirst("c");
            list.AddFirst("d");
            list.AddFirst("e");
            list.AddFirst("f");
            list.AddFirst("e");

            list.AddLast("g");
            list.AddLast("h");
            list.AddLast("i");
            list.AddLast("j");

             LinkedListNode<string> node=list.Find("e1");
            if (node != null)
            {
                list.AddAfter(node, "added first e after");
                //list.AddBefore(node, "added before e ");
            }
            else
            {
                Console.WriteLine("there is no the parent node like " +node.Value);
                
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
