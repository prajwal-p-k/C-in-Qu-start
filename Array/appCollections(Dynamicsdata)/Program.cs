using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCollections_Dynamicsdata_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList lst = new ArrayList();
            lst.Add("c sharp ");
            lst.Add(1);
            lst.Add(true);
            lst.Add(false);
            lst.Add(3);

            string[] names = { "prajwal", "rahul", "manoj" };
            lst.AddRange(names);  //added at the end of lst to names
            int[] slNm = { 1, 2, 3 };

            //lst.InsertRange(4, slNm); //it will added slNm elements to the 4 index onwords and contineu element of lst next but not replace with index
            //lst[4] = 10;
            //string[] tech = { "MVC", "core", "React", "database" };

            //lst.SetRange(6, tech); //it will replace with the index

            //// ArrayList mylist = lst.GetRange(7, 5); //7 is strat index 5 is no of elements

            ////lst.Remove("MVC"); //remove items from elelemnts
            ////lst.RemoveAt(0); //remove items by index
            //lst.RemoveRange(2, 5);

            ////lst.RemoveAt(1);
            //// lst.Clear(); //clear all items

            //lst.TrimToSize();
            //lst.Add("enri media");

            Console.WriteLine("No od items in collection:" + lst.Count);
            Console.WriteLine("No od items in collection:" + lst.Capacity);
            Console.WriteLine("----------------------------------------------------------");


            foreach (object item in lst)  //object will used for any type of data
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------------------------------------");


            ////foreach (object i in mylist)  //object will used for any type of data
            ////{
            ////    Console.WriteLine(i);
            ////}
            ////Console.WriteLine("----------------------------------------------------------");

            //Console.ReadLine();


            ArrayList lst2 = new ArrayList();

            lst2.Add("a");
            lst2.Add("b");
            lst2.Add("c");
            lst2.Add("d");
            lst2.Add("e");
            lst2.Add("f");
            lst2.Add("g");
            object[] objects = lst2.ToArray();
            string[] name1 = {
                "prajwal","rahul","krishna","manoj","arjun"
            };
            foreach (object item in objects)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------------------");
            foreach(object item in name1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------------------");





            //lst2.CopyTo(name1);
            // copy all the elements of arraylist into array calles name1 and paste it in 0th index

            //lst2.CopyTo(name1, 2);
            //copy all the emelemnts of array into th 2nd index of array called name1

            lst2.CopyTo(1, name1, 3, 2);
            //start copying elelmtns from array list at 2nd index
            //copy into name1
            //copy at the 3rd index of array called name1
            //copy 2 elements from lst2 string from 2nd index




            Console.WriteLine("--------------------name list -----------------------");
            foreach (object item in name1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------------");
            Console.ReadLine();




        }
                
    }
}
