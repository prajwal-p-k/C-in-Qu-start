using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortLst_sorted_list_
{
    internal class Program
    {
        static void Main(string[] args)
        {
          SortedList lst = new SortedList();
            lst.Add(23, "HTML");
            lst.Add(25, "c#");
            lst.Add(24, true);
            lst.Add(28, "java");
            lst.Add(26, "peehalli");
            lst.Add(29, 'a');

            Console.WriteLine("total count : "+lst.Count);
            foreach (int i in lst.Keys)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("----------------------------------------------------------");
            lst.SetByIndex(3, "prajwal P K"); //if index is not present then outof range error
            //lst.Remove(29); //based on key
            //lst.RemoveAt(lst.Count-1); //based on index
            //lst.TrimToSize();//it will make same count and capacity
            foreach (int k in lst.Keys)
            {
                Console.WriteLine(k+" : " + lst[k]);
            }
            Console.WriteLine("the total capacity : "+lst.Capacity);
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("the get the element by index  : " + lst.GetByIndex(3));
            Console.WriteLine("the index of key 4:" + lst.IndexOfKey(24));
            Console.WriteLine("the index of key 4:" + lst.IndexOfKey(400));
            Console.WriteLine("the index of value prajwal P K:" + lst.IndexOfValue("prajwal P K"));


            Object[] a = new object[lst.Count+1];
            
            lst.CopyTo(a, 0);
            Console.WriteLine("---------------- copy the sorted list to an array indexing ---------------");
            foreach(DictionaryEntry i in a)
            {
                Console.WriteLine(i.Key  + " : "+i.Value);
            }

            Console.ReadLine();

        }
    }
}
