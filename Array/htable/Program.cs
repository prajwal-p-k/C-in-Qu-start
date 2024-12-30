using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add(1, "p k");
            ht.Add(2, "RDBMS");
            ht["ans"] = true;
            ht[3] = 10;
            ht[2] = "prajwal";
            Console.WriteLine("No of itemes in collection are:"+ht.Count);
            ICollection k= ht.Keys;
            foreach (object o in k)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine("--------------------------------------------");
            foreach (object o in ht.Values)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine("--------------------------------------------");
            foreach(DictionaryEntry de in ht)
            {
                Console.WriteLine(de.Key+" : "+de.Value);
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("collection containes a key called 3:" + ht.Contains(3));
            Console.WriteLine("collection containes a key called 3:" + ht.ContainsKey(3));
            Console.WriteLine("collection containes a value called 1prajwal:" + ht.Contains("RDBMS"));
            Console.ReadLine();
        }
    }
}
