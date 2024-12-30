using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_queue_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue t = new Queue();
            t.Enqueue(1);
            t.Enqueue(2);
            t.Enqueue(3);
            t.Enqueue(4);
            t.Enqueue(5);
            t.Enqueue(6);
            t.Enqueue(7);
            t.Enqueue(8);
            t.Enqueue(9);
            Console.WriteLine("no of collection are :"+t.Count);

            for (int i = 0; i < t.Count; i++)
            {
                Console.WriteLine(t.Peek());
            }
            Console.WriteLine("the collection contain 5 " + t.Contains(5));
            Console.WriteLine("---------------------------------------------------------------------");
            int x = t.Count;
            for (int k = 0; k <= x; k++)
            {
                Console.WriteLine(t.Dequeue()); //it return top element and remove 
                Console.WriteLine("the no of collection: " + t.Count);

            }
            

        }
    }
}
