using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class Program

    {
        void List()
        {
            //single dimentional array


            //string[] nameList = { "a", "b", "c", "prajwal" };
            //int[] marks = new int[] { 1, 2, 3, 4, 5 };
            //int[] mark = new int[6] { 1, 2, 3, 4, 5, 6 }; //if give a size its must be full element
            //int[] slNos = new int[10];
            //slNos[0] = 10;
            //slNos[2] = 20;
            //slNos[3] = 30;
            //slNos[4] = 60;
            //slNos[5] = 50;
            //slNos[6] = 90;
            //slNos[7] = 80;
            //slNos[8] = 550;
            //slNos[9] = 70;
            ////slNos[10] = 110;
            //Console.WriteLine("No of array elements " + slNos.Length);
            //Console.WriteLine("No of array dimention :" + slNos.Rank);
            //for (int i = 0; i < slNos.Length; i++)
            //{ Console.WriteLine(slNos[i]); }
            //Console.WriteLine("-----------------------------------------------------------------------");
            //Array.Reverse(slNos);
            //Array.Sort(slNos);
            //for (int i = 0; i < slNos.Length; i++)
            //{
            //    Console.WriteLine(slNos[i]);
            //}
            //Console.WriteLine("-----------------------------------------------------------------------");
            //foreach (string i in nameList)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine("-----------------------------------------------------------------------");

            //two demension array

            // int[,] slNos = { { 3, 4, 5, 6 }, { 7, 8, 9, 10 } };
            // string[,] subjects = new string[,] { { "HTML", "css" }, { "java", "python" }, { "js", "c#" } };
            // int[,] vals = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

            // string[,] nameList = new string[3, 4];
            // nameList[0, 0] = "a";
            // nameList[0, 1] = "b";
            // nameList[0, 2] = "c";
            // nameList[0, 3] = "d";

            // nameList[1, 0] = "e";
            // nameList[1, 1] = "b";
            // nameList[1, 2] = "c";
            // nameList[1, 3] = "f";

            // nameList[2, 0] = "a";
            // nameList[2, 1] = "b";
            // nameList[2, 2] = "c";
            // nameList[2, 3] = "d";

            ////sort and reverse are not possible

            // Console.WriteLine("No of array elements" + nameList.Length);
            // Console.WriteLine("No of array dimention:" + nameList.Rank);
            // for(int i = 0; i < 3; i++)
            // {
            //     for(int j = 0; j < 4; j++)
            //     {
            //         Console.WriteLine(nameList[i,j] +"\t");
            //     }
            //     Console.WriteLine();
            // }
            // Console.WriteLine("---------------------------------------------------------------");

            // foreach (string name in nameList)
            // {
            //     Console.WriteLine(name);
            // }
            // Console.WriteLine("---------------------------------------------------------------");

            // int[][] //jaggk array /interges arraya
            int[][] lst = new int[5][];
            int[] a1 = {1, 2, 3, 4};
            int[] a2 = {1,2, 3, 4,9,10};
            int[] a3 = { 1, 2, };
            int[] a4 = {1,2,3, 4,12,23};
            int[] a5 = {1,2,4,5,6,7};

            lst[0] = a1;
            lst[1] = a2;
            lst[2] = a3;
            lst[3] = a4;
            lst[4] = a5;

            foreach (int[] array in lst)
            {
                foreach(int i in array)
                {
                    Console.Write(i+"\t");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.List();
            Console.ReadLine();
        }
    }
}
