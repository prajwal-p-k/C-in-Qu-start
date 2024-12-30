using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashst_hashset_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            set.Add("India");
            set.Add("srilanka");
            set.Add("australlia");
            set.Add("west Indis");
            set.Add("Pakisthan");
            set.Add("south korea");
            set.Add("england");
            set.Add("newziland");
            set.Add("bangladhesh");
            set.Add("India");
            Console.WriteLine("No of count : "+set.Count); //the items are 10 the count is 9 beacuse india is repiting it does not take repetaed items
            
            List<string> list = new List<string>();
            list.Add("India");
            list.Add("srilanka");
            list.Add("west Indis");
            list.Add("Pakisthan");
            list.Add("south korea");
            list.Add("england");
            list.Add("madlives");
            list.Add("chaina");
            foreach (string item in set.Intersect(list))
                { 
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------------------------------------");
            foreach (string item in set.Union(list))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------------------------------------");

            SortedList<int,string> lst1 = new SortedList<int,string>();
            SortedList<string,char> lst2 = new SortedList<string,char>(); //we can use both string and char
            Console.ReadLine();
        }
    }
}
